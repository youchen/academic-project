package project_2;
import java.util.Random;
import java.util.concurrent.Semaphore;
/**
 * Visitor class. All the schedules of visitors' is in run() method.
 * @author Youchen Ren
 *
 */
public class Visitor extends Thread{

	public static volatile boolean notWatchMovie = true, pp = true;
	/**
	 * Id is using when all the visitors leaving the museum.
	 */
	public int Id;
	public static Semaphore groupNum;

	/**
	 * Constructor
	 * @param id the visitor's id number.
	 */
	public Visitor (int id) {
		super ("Visitor-" + id);
		Id = id;
	}

	protected void message (String m) {
		System.out.println ("[" + Clock.age() + "] " + getName() + m);
	}

	public void run() {
		/**
		 * groupNum is used for indicating how many groups are formed.
		 */
		groupNum = new Semaphore(4, true);
		groupNum.drainPermits();
		/**
		 * waiting for entering the museum.
		 */
		Clock.notOpen.acquireUninterruptibly();
		/**
		 * waiting for movie session to start.
		 */
		message(" is waiting in the lobby.");
		Clock.firstMovieSession.acquireUninterruptibly();
		/**
		 * sleep for speaker printing.
		 */
		try {
			Visitor.sleep(100);
		} catch (InterruptedException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}
		/**
		 * try to get the seat.
		 */
		try{
			EllisIsland.seats.acquire();
		}catch(InterruptedException e) {}

		//if not watch.
		if(Speaker.thereAreUnluckyVisitors) {
			message(" was informed no more Movie Sessions today." +
					"\n\t\tHe was not able to get the seat and he leaves the line.");
			/**
			 * signal another visitor on line afterwards.
			 */
			EllisIsland.seats.release();
		}

		//watched.
		else if (pp){
			notWatchMovie = false;
			message(" get an seat, waiting for moive start.");
			/**
			 * sleep for a while, as required:
			 * "They will take a break (sleep of random time) and 
			 * 		next they will wait to watch the movie."
			 */
			Random r = new Random();
			int Low = 1;
			int High = 200;
			int R = r.nextInt(High-Low) + Low;
			try {
				Visitor.sleep(R);
			} catch (InterruptedException e) {}


			if(Speaker.conductMovieSessionCount == 1) {	
				Clock.firstMovieSession.acquireUninterruptibly();
				/**
				 * wait for speaker printing.
				 */
				try {
					Visitor.sleep(20);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				message(" finished watching the movie, move on to visit the museum.");

				/**
				 * 2nd Movie starts, release the seats.
				 */
				EllisIsland.seats.release();

			}
			else if (Speaker.conductMovieSessionCount == 2) {
				/**
				 * watching movie.
				 */
				Clock.secondMovieSessionFinish.acquireUninterruptibly();
				/**
				 * wait for speaker printing.
				 */
				try {
					Visitor.sleep(20);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				message(" finished watching the movie, move on to visit the museum.");
			}
		}

		/**
		 * waiting for museum to close;
		 */
		Clock.notOpen.acquireUninterruptibly();
		/**
		 * leave museum by group;
		 * 
		 */
		EllisIsland.groupMutex.acquireUninterruptibly();

		EllisIsland.MembersInGroup++;		

		/**
		 * if the numbers of visitor waiting is divisible by 4 (GROUP SIZE),
		 * 		this visitor should say "group formed" and leave with the group;
		 * 		or if no more visitors, he may leave with the "incomplete" group (size < 4).
		 */
		if ((EllisIsland.MembersInGroup % EllisIsland.GROUP_SIZE == 0) || 
				(EllisIsland.MembersInGroup == 15)) {
			EllisIsland.groupMutex.release();
			EllisIsland.groupPerformed.release(3);
			groupNum.release();
			message(" Group " + groupNum.availablePermits() + " formed.");
		}
		/**
		 * else the numbers of visitor waiting is not divisible by 4 (GROUP SIZE),
		 * 		they wait for the other visitors to form a group.
		 */
		else if((EllisIsland.MembersInGroup % EllisIsland.GROUP_SIZE != 0)){

			EllisIsland.groupMutex.release();
			EllisIsland.groupPerformed.acquireUninterruptibly();
		}
		//group formed;
		message(" left the museum with group");
	}//run()
}