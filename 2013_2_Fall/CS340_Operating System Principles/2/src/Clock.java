package project_2;
import java.util.concurrent.Semaphore;
/**
 * This Clock class is intended to establish an clock, 
 * 		for indicating the time elapsed from the beginning for each state updated.
 * All the time schedule is defined by this class.
 * @author Youchen Ren
 */
public class Clock extends Thread{
	private final static long startTime = System.currentTimeMillis();
	public static Semaphore notOpen, firstMovieSession, secondMovieSession, secondMovieSessionFinish;
	/**
	 * constructor.
	 */
	public Clock () {
		super ("clock");
	}
	/**
	 * @return return the current time.
	 */
	public static long age () { 
		return System.currentTimeMillis() - startTime;
	}
	/**
	 *	Clock run method.
	 *	here, all the schedule of the museum is defined.
	 *		Semaphore used (as mutex semaphore) for controlling:
	 *			notOpen
	 *			sessionNotStart
	 *
	 *		Scheme(#s is indicating sleeping time):
	 *			50
	 *				museum open
	 *			1500
	 *				MS 1 (Movie Session 1)
	 *			1500
	 *				//MS 1 end
	 *			1500
	 *				MS 2
	 *			1500
	 *				//MS 2 end
	 *			1000
	 *				museum closed
	 *			
	 */
	public void run() {
		/**
		 * mutex semaphore, equal to the former boolean variable:
		 * 		1 for true;
		 * 		0 for false;
		 */
		notOpen = new Semaphore(16, true);
		notOpen.drainPermits();
		/**
		 * firstMoiveSession and secondMovieSession Semaphore is designated to
		 * 		signaling the 1st and 2nd movie session starts or ends.
		 */
		firstMovieSession = new Semaphore(16, true);
		firstMovieSession.drainPermits();

		secondMovieSession = new Semaphore(7, true);
		secondMovieSession.drainPermits();
		
		secondMovieSessionFinish = new Semaphore(6, true);
		secondMovieSessionFinish.drainPermits();

		/**
		 * sleep for a while and later open the museum.
		 */
		try {
			Clock.sleep(50);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		/**
		 * Museum Open.
		 */
		msg("The Museum is Open!" );
		notOpen.release(16);
		/**
		 * sleep for a while and later start the movie session.
		 */
		try {
			Clock.sleep(1500);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		firstMovieSession.release(16);
		//MS 1 Start		
		msg("Movie Session 1.");
		/**
		 * 1st Movie session is in progress.
		 */
		try {
			Clock.sleep(1500);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		/**
		 * 1st Movie session is finished.
		 * 		release 7 permits include:
		 * 			1 for speaker;
		 * 			6 for audience;
		 */
		firstMovieSession.release(7);
		//MS 1 ends.
		/**
		 * Gap between 1st and 2nd Movie Session.
		 */
		try {
			Clock.sleep(1500);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		//MS 2 starts
		/**
		 * 2nd Movie session is start.
		 * 		release 7 permits include:
		 * 			1 for speaker;
		 * 			6 for audience;
		 */
		msg("Movie Session 2.");
		secondMovieSession.release(1);	
		/**
		 * 2nd Movie session is in progress.
		 */
		try {
			Clock.sleep(1500);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		/**
		 * 2nd Movie session is finished.
		 * 		signal 6 audience + 1 speaker.
		 */
		//MS 2 ends		
		secondMovieSessionFinish.release(7);		
		/**
		 * Gap between 2nd Movie Session and Museum Closing.
		 */
		try {
			Clock.sleep(1000);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		/**
		 * Museum Closed.
		 */
		notOpen.release(16);
		msg("The Museum is Closed!" );	
		/**
		 * waiting for speaker and visitor leave;
		 * 		then terminate the program.
		 */
		try {
			Clock.sleep(100);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		System.exit(0);
	}//run()

	private void msg(String s) {
		System.out.println ("[" + Clock.age() + "] " + s);
	}
}//class