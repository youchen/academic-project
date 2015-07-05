package project_2;
import java.util.concurrent.Semaphore;
/**
 * Speaker class. All the events (presentation, movie and etc.) is triggered by speaker.
 * @author Youchen Ren
 */
public class Speaker extends Thread{
	public static volatile boolean thereAreUnluckyVisitors = false;
	public static volatile int conductMovieSessionCount = 1;
	/**
	 * constructor
	 * @param str name of this thread.
	 */
	public Speaker(String str) {
		super(str);
	}

	public void run() {
		/**
		 * waiting for museum to open.
		 */
		Clock.notOpen.acquireUninterruptibly();
		/**
		 * Speaker arrived the museum.
		 */
		message ("arrived.");
		/**
		 * If movie session is not yet finished (not showed twice), 
		 * 		speaker continuously conducting the movie Session.
		 */
		while( conductMovieSessionCount <= 2 ) {
			
			if (conductMovieSessionCount == 1) {
				/**
				 * waiting for the firstMoiveSession to be signaled.
				 */
				Clock.firstMovieSession.acquireUninterruptibly();
				message ("announced 1st Movie session is Started.");
			}
			/**
			 * if session == 2, speaker need to inform the visitor on line
			 * 		that no more session will be conducted.
			 */
			else if (conductMovieSessionCount == 2) {
				Clock.secondMovieSession.acquireUninterruptibly();
				message ("announced 2nd Movie session is Started.");
				/**
				 * signal visitors on line by release the seats. 
				 * But with thereAreUnluckyVisitors = true, meaning that it's not 
				 * 		the real seat. Just let all the "unlucky" visitors who 
				 * 		did not get the seats know there is no more Movie Session today.
				 */
				if(EllisIsland.seats.hasQueuedThreads()) {

					thereAreUnluckyVisitors = true;
					/**
					 * the Speaker is signaling one visitor on line 
					 * 		by releasing one seat.
					 */
					EllisIsland.seats.release();
				}
			}//else if conductMovieSessionCount == 2
			/**
			 * Presentation
			 */
			message ("announced that presentation starts.");
			EllisIsland.presenStart = true;
					/**
					 * waiting for vistor's states printing.
					 */
					try {
						Speaker.sleep(20);
					} catch (InterruptedException e1) {}
			/**
			 * presentation is started.
			 */
			try {
				Speaker.sleep(200);
			} catch (InterruptedException e) {}
			EllisIsland.presenEnd = true;
					/**
					 * waiting for vistor's states printing.
					 */
					try {
						Speaker.sleep(20);
					} catch (InterruptedException e) {}
			/**
			 * Movie
			 */
			message ("announced that Movie starts.");
			EllisIsland.showNotStart = false;
			/**
			 * Speaker is watching the movie.
			 */
			if (conductMovieSessionCount == 1) {
				Clock.firstMovieSession.acquireUninterruptibly();
				System.out.println ("[" + Clock.age() + "] " + getName() + " " + 
						"announced 1st Movie session is end. " +
						"\n\t\tThe 2nd Movie Session will be Started in 15 minutes.");
			}
			else if (conductMovieSessionCount == 2) {
				Clock.secondMovieSessionFinish.acquireUninterruptibly();
				message ("announced 2nd Movie session is end. " +
						"Sorry, No more movie sessions today.");
				//System.out.println("\n\n\n\n\n\t\t\t\tNo more Movie Sessions for today!\n\n\n\n\n");
			}
			EllisIsland.presenStart = false;
			EllisIsland.presenEnd = false;
			EllisIsland.showNotStart = true;
			conductMovieSessionCount++;
		}//while( EllisIsland.movieSession <= 2 ) 
		/**
		 * Speaker done all his work for today, waiting for museum to close.
		 */
		Clock.notOpen.acquireUninterruptibly();
		
		System.out.println("[" + Clock.age() + "] " + 
				"Speaker left the museum.");
	}
	
	protected void message (String m) {
		System.out.println ("[" + Clock.age() + "] " + getName() + " " + m);
	}
}
