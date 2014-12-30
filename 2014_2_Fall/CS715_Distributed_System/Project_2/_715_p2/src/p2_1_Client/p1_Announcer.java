package p2_1_Client;

import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;

public class p1_Announcer extends Thread{

	private Socket soc = null;

	public p1_Announcer(Socket s, String str) {
		super(str);
		this.soc = s;
	}

	public void run() {
		try {
			PrintWriter out = new PrintWriter(soc.getOutputStream(), true);
			BufferedReader in = new BufferedReader(
					new InputStreamReader(soc.getInputStream()));
			
			String fromServer;
			printInfo("Annoucner is started.");
			
			while ((fromServer = in.readLine()) != null) {

				if(fromServer.equals("Server is Ready.")) {
					printInfo("receive \"Server is Ready.\"");
					out.println("Annoucer");
					printInfo("sent \"Announcer\"");
					
				}//if
				else if(fromServer.equals("Announcer is Ready.")) {
					printInfo("receive \"Announcer is Ready.\"");
					out.println("_waitForDecideWinner");
					printInfo("sent \"_waitForDecideWinner\"");

				}
				else if(fromServer.equals("_waitForDecideWinner")) {
					printInfo("receive \"_waitForDecideWinner\"");
					out.println("_computeTop4HighestScore");
					printInfo("sent \"_computeTop4HighestScore\"");
				}
				else if(fromServer.equals("_computeTop4HighestScore")) {
					printInfo("receive \"_computeTop4HighestScore\"");
					out.println("_wait4ShowStart");
					printInfo("sent \"_wait4ShowStart\"");
				}
				else if(fromServer.equals("_wait4ShowStart")) {
					printInfo("receive \"_wait4ShowStart\"");

					Client.HostTrd.start();
					out.println("_introHost");
					printInfo("sent \"_introHost\"");
					
				}
				else if(fromServer.equals("_introHost")) {
					printInfo("receive \"_introHost\"");
					out.println("_introContestant");
					printInfo("sent \"_introContestant\"");
				}
				else if(fromServer.equals("_introContestant")) {
					printInfo("receive \"_introContestant\"");
					out.println("_waitToStartShow");
					printInfo("sent \"_waitToStartShow\"");
				}
				else if(fromServer.equals("_waitToStartShow")) {
					printInfo("receive \"_waitToStartShow\"");
					//Announcer exit.
					soc.close();
					printInfo("my socket is closed.");
					//break the while loop
					break;
				}//else if
			}//while
		}
		catch (UnknownHostException e) {
			System.err.println("Don't know about host.");
			System.exit(1);
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection.");
			System.exit(1);
		} 
	}//run
	
	public String msg(String info) {
		return "Announcer " + info;
	}
	
	public void printInfo(String str) {
		System.out.println("Announcer: " + str);
	}

}
