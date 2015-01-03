


public class Main {
	public static Clock clock;
	public static int numRounds, numQuestions, questionValues, room_capacity, num_contestants;
	public static double rightPercent;
	public static int howManyGroup = 0;
	public static volatile int curGroup = 0;
	public static Announcer ancr;
	public static Host hst;
	
	/*
	 * Command line arguments must be implemented to allow changes 
	 * 		to the following parameters: 
	 * 
	 * 		numRounds, numQuestions, questionValues, rightPercent, 
	 * 		room_capacity, num_contestants.
	 */
	public static void main(String[] args) {
		numRounds 		= (args.length == 0 )? 2 		: Integer.parseInt(args[0]);
		numQuestions 	= (args.length == 0 )? 5 		: Integer.parseInt(args[1]);
		questionValues 	= (args.length == 0 )? 200 		: Integer.parseInt(args[2]);
		rightPercent	= (args.length == 0 )? 0.65 	: Integer.parseInt(args[3]);
		room_capacity 	= (args.length == 0 )? 4 		: Integer.parseInt(args[4]);
		num_contestants = (args.length == 0 )? 13	 	: Integer.parseInt(args[5]);
		/**
		 * Compute for how many groups for Preliminary Exam.
		 */
		howManyGroup = num_contestants / room_capacity + 1;
//System.out.println("group: " + howManyGroup);
		
		/**
		 * Initializing Thread clock.
		 */
		clock = new Clock();
		clock.start();
		/**
		 * Initializing Thread Announcer
		 */
		ancr = new Announcer("Announcer");
		ancr.start();
		/**
		 * Initializing Thread Contestants. (num_contestants of them)
		 */
		for (int i = 1; i <= num_contestants; i++){
			//creating num_contestants instances of Contestant threads.
			new Contestants(i).start();
		}
		
		hst = new Host("Host");
		
	}
	
	
}
