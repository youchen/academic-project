package CS340_P1_Youchen;
import java.util.Random;
/**
 * Visitor class. All the schedules of visitors' is in run() method.
 * @author Youchen Ren
 *
 */
public class Visitor extends Thread{
	private boolean notWatchMovie = true, canDie = false;;
	public static volatile boolean foundMaxVisitor = false;
	public static volatile Visitor p;
	/**
	 * Id is using when all the visitors leaving the museum.
	 */
	public int Id;
	
	public Visitor (int id) {
		super ("Visitor-" + id);
		Id = id;
	}

	protected void message (String m) {
		System.out.println ("[" + Clock.age() + "]\t" + getName() + m);
	}

	public void run() {

		message(" is waiting for entering the Museum.");
		while(EllisIsland.notOpen) {}

		message(" is waiting in the lobby.");
		while(EllisIsland.sessionNotStart) {};

		while (notWatchMovie && (EllisIsland.movieSession <= 2)) {
			if(EllisIsland.seats >= 1) {
				/**
				 * The visitor who found there has a seat available will wait for a while,
				 * 		9 millisec for avoiding the situation of which two visitors siting
				 * 		on the same seat.		
				 */
				Random r = new Random();
				int Low = 1;
				int High = 20;
				int R = r.nextInt(High-Low) + Low;
				try {
					Visitor.sleep(R);
				} catch (InterruptedException e) {}

				watchMovie();
				notWatchMovie = false;
			}//if

			else if (notWatchMovie && EllisIsland.seats <= 0) {
				//wait for the other visitor printing.
				try {
					Visitor.sleep(5);
				} catch (InterruptedException e) {}
				notWatch_1M();
			}

		}//while (notWatchMovie && (EllisIsland.movieSession <= 2)) {

		while ( !EllisIsland.notOpen) {};
		/**
		 * Use .join() in Speaker Class for organizing the visitors to leave
		 * 		the museum.
		 */
		while(!canDie) {	
			if ( this.Id == EllisIsland.leaveOrder) {
				p = this;
				foundMaxVisitor = true;
				message(" go home.");

				synchronized (this) {
					EllisIsland.leaveOrder--;
				}
				foundMaxVisitor = false;
				canDie = true;
			}
		}//while != 0

		/**w/o join()
		while(this.isAlive()) {
			if ( this.Id == EllisIsland.leaveOrder) {

				message(" go home.");
				synchronized (this) {
					EllisIsland.leaveOrder--;
				}
			}
		}
		 */		
	}//run()

	private void watchMovie() {
		if(EllisIsland.seats <= 0) notWatch_1M();
		else {
			synchronized (this){
				EllisIsland.seats--;
			}
			message(" took the seats and wait for Presentation to Start.");
			while( !EllisIsland.presenStart ) {}
			message(" listening Presentation.");
			while( !EllisIsland.presenEnd ) {}
			//wait for movie to start.
			message(" wait for the movie to start.");
			while(EllisIsland.showNotStart) {}
			message(" watching movie.");
			while(!EllisIsland.showNotStart) {}

			notWatchMovie = false;
			synchronized (this){
				EllisIsland.seats++;
			}
			message(" watched movie and continue to visiting the museum.");
		}//else (outer)
	}//watchMoive()

	private void notWatch_1M() {
		message(" no more seats available, leave the room. Wait for 2nd Movie Session.");
		int p;
		while(notWatchMovie && EllisIsland.movieSession <= 2) {
			p = this.getPriority();
			p++;
			this.setPriority(p);
			if(EllisIsland.seats >= 1) {

				watchMovie();
				p--;
				notWatchMovie = false;
			}//if
			else if (EllisIsland.seats <= 0){
				p--;
				this.setPriority(p);
			}//else if
		}//while
		if (notWatchMovie) {
			Visitor.yield();
			message(" not watched movie, he/she gives up and continue to visiting the museum.");
		}
	}//private void notWatch_1M()
}