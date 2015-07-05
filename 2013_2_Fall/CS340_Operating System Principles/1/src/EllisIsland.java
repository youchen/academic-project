package CS340_P1_Youchen;
/**
 * EllisIsland class. This class is to initializing the shared variables (static volatile),
 * 		initializing all the Thread like visitors and to triggered the speaker to start.
 * @author Youchen Ren
 *
 */
public class EllisIsland{
	public static Clock clock;
	public static volatile int seats, movieSession, leaveOrder;
	public static volatile boolean sessionNotStart, showNotStart, presenStart, presenEnd;
	public static volatile boolean notOpen = true;

public static volatile boolean finish = false;
	
	public static void main(String[] args){

		seats = 6;
		movieSession = 1;
		showNotStart = true;
		presenStart = false;
		presenEnd = false;
		sessionNotStart = true;
		leaveOrder = 15;
		/**
		 * Initializing Thread Visitors. (15 of them)
		 */
		for (int i = 1; i <= 15; i++){
			//creating 15 instances of visitor threads.
			new Visitor(i).start();
		}
		/**
		 * Initializing Thread clock.
		 */
		clock = new Clock();
		clock.start();
		/**
		 * Initializing Thread speaker.
		 */
		Speaker speaker = new Speaker("Speaker");
		speaker.start();
		
	}// main
}// class EllisIsland