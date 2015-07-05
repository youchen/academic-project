package project_2;
import java.util.concurrent.Semaphore;

/**
 * EllisIsland class. This class is to initializing the shared variables (static volatile),
 * 		initializing all the Thread like visitors and to triggered the speaker to start.
 * @author Youchen Ren
 *
 */
public class EllisIsland{
	public static Clock clock;
	public static volatile int MembersInGroup;
	public static volatile boolean showNotStart, presenStart, presenEnd, finish = false;;
	public static final int GROUP_SIZE = 4;
	public static Semaphore leaveOrder, seats, groupMutex, groupPerformed;
	
	public static void main(String[] args){
		/**
		 * initialize the variables.
		 */
		showNotStart = true;
		presenStart = false;
		presenEnd = false;
		MembersInGroup = 0;
		seats = new Semaphore(6, true);
		groupMutex = new Semaphore(1, true);
		groupPerformed = new Semaphore(3, true);
		/**
		 * get groupPerformed drained.
		 */
		groupPerformed.drainPermits();
		/**
		 * Instantiate the clock object.
		 */
		clock = new Clock();
		clock.start();
		/**
		 * Instantiate Thread Visitors. (15 of them)
		 */
		for (int i = 1; i <= 15; i++){
			//creating 15 instances of visitor threads.
			new Visitor(i).start();
		}
		/**
		 * Instantiate Thread speaker.
		 */
		Speaker speaker = new Speaker("Speaker");
		speaker.start();
	}// main
}// class EllisIsland