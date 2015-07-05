package CS340_P1_Youchen;
/**
 * This Clock class is intended to establish an clock, for indicating the time elapsed from the beginning for each state updated.
 * @author Youchen Ren
 */
public class Clock extends Thread{
	private final static long startTime = System.currentTimeMillis();
	
	public Clock () {
		super ("clock");
	}
	/**
	 * @return return the current time.
	 */
	public static long age () { 
		return System.currentTimeMillis() - startTime;
	}
}