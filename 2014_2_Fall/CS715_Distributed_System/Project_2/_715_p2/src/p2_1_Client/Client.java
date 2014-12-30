package p2_1_Client;

import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;



public class Client {

	/**
	 * Declaration from Project 1 main
	 */
	public static int numRounds, numQuestions, questionValues, room_capacity, num_contestants;
	public static double rightPercent;
	public static int howManyGroup = 0;
	public static volatile int curGroup = 0;

	public static p1_Announcer ancr;
	public static p1_Host HostTrd;

	public static String hostName;
	public static int portNumber;


	public static void main(String[] args) throws IOException {
		/**
		 * 3 threads from Project 1 main
		 */
		numRounds 		= (args.length == 0 )? 2 		: Integer.parseInt(args[0]);
		numQuestions 	= (args.length == 0 )? 5 		: Integer.parseInt(args[1]);
		questionValues 	= (args.length == 0 )? 200 		: Integer.parseInt(args[2]);
		rightPercent	= (args.length == 0 )? 0.65 	: Double.parseDouble(args[3]);
		room_capacity 	= (args.length == 0 )? 4 		: Integer.parseInt(args[4]);
		num_contestants = (args.length == 0 )? 13	 	: Integer.parseInt(args[5]);
		/**
		 * Compute for how many groups for Preliminary Exam.
		 */
		howManyGroup = num_contestants / room_capacity + 1;
		
		/**
		 * 
		 * If these two variables are unspecified,
		 * 	default value for
		 * 		host name: localhost
		 * 		port number: 2222
		 */

		hostName 	= (args.length == 0 )? "localhost"	 	: args[6];
		portNumber	= (args.length == 0 )? 2222	 			: Integer.parseInt(args[7]);
		
		
		
		try {

			Socket kkSocket = new Socket(hostName, portNumber);
						PrintWriter out = new PrintWriter(kkSocket.getOutputStream(), true);
						BufferedReader in = new BufferedReader(
								new InputStreamReader(kkSocket.getInputStream()));

			String fromServer;

			printInfo("Try to establish Connection to Server, "
					+ "\n\tand transmit the parameters...");

			while ((fromServer = in.readLine()) != null) {

				if(fromServer.equals("Server is Ready.")) 
					out.println("Configure");
				else if(fromServer.equals("OK")) {
					out.println(numRounds + " "
							+ numQuestions + " "
							+ questionValues + " "
							+ rightPercent + " "
							+ room_capacity + " "
							+ num_contestants + " "
							);
					printInfo("Parameter transmitted successfully.");
					break;
				}//else if

			}//while
			kkSocket.close();
		}//try
		catch (UnknownHostException e) {
			System.err.println("Don't know about host " + hostName);
			System.exit(1);
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection to " +
					hostName);
			System.exit(1);
		} 
		
		
		try {
			/**
			 * Initializing Thread Announcer
			 */
			printInfo("Request for Initialize Announcer.");
			Socket Asoc = new Socket(hostName, portNumber);
			p1_Announcer AnnouncerTrd = new p1_Announcer(Asoc, "Announcer");
			AnnouncerTrd.start();
		}
		catch (UnknownHostException e) {
			System.err.println("Don't know about host " + hostName);
			System.exit(1);
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection to " +
					hostName);
			System.exit(1);
		}
		
		
		try {
			Thread.sleep(70);
		} catch (InterruptedException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}


		try {
			
			/**
			 * Initializing Thread Contestants. (num_contestants of them)
			 */
			for (int i = 1; i <= num_contestants; i++){
				printInfo("Request for Initialize Contestant - " + i);
				Socket Csoc = new Socket(hostName, portNumber);
				p1_Contestants ContestantTrd = new p1_Contestants(i, Csoc);
				ContestantTrd.start();
			}
		}
		catch (UnknownHostException e) {
			System.err.println("Don't know about host " + hostName);
			System.exit(1);
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection to " +
					hostName);
			System.exit(1);
		}


		try {
			/**
			 * Initializing Thread Host
			 */
			printInfo("Request for Initialize Host.");
			Socket Hsoc = new Socket(hostName, portNumber);
			HostTrd = new p1_Host(Hsoc, "Host");
		}
		catch (UnknownHostException e) {
			System.err.println("Don't know about host " + hostName);
			System.exit(1);
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection to " +
					hostName);
			System.exit(1);
		}


	}//main
	public static void printInfo(String str) {
		System.out.println(str);
	}
}//class
