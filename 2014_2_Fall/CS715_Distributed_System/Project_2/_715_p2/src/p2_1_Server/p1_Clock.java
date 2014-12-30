package p2_1_Server;

/**
 * This Clock class is intended to establish an clock, for 
 * 		indicating the time elapsed from the beginning for each state updated.
 * @author Youchen Ren
 */
public class p1_Clock extends Thread{
	private final static long startTime = System.currentTimeMillis();

	public p1_Clock () {
		super ("clock");
	}
	/**
	 * @return return the current time.
	 */
	public static long age () { 
		return System.currentTimeMillis() - startTime;
	}
}


