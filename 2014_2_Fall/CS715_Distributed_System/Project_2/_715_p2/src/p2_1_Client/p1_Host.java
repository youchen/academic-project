package p2_1_Client;


import java.io.*;
import java.net.*;


public class p1_Host extends Thread{
	private Socket socket = null;
	
	public p1_Host(Socket s, String str) {
		super(str);
		this.socket = s;
	}


	public void run() {
		begin_run();
	}
	public void begin_run() {
		
		try {
			PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
			BufferedReader in = new BufferedReader(
					new InputStreamReader(socket.getInputStream()));
		
			String fromServer;
			while ((fromServer =  in.readLine()) != null) {
				
				if(fromServer.equals("Server is Ready.")) {
					printInfo("receive \"Server is Ready.\"");
					out.println("Host");
					printInfo("sent \"Host\"");
				}//if
				else if(fromServer.equals("Host is Ready.")) {
					printInfo("receive \"Host is Ready.\"");
					out.println("_iniHost");
					printInfo("sent \"_iniHost\"");
				}
				else if(fromServer.equals("_iniHost")) {
					printInfo("receive \"_iniHost\"");
					
					out.println("_hostQuestionSession");
					printInfo("sent \"_hostQuestionSession\"");
				}
				else if(fromServer.equals("_hostQuestionSession")) {
					printInfo("receive \"_hostQuestionSession\"");
					
					out.println("_hostFinalQuestionSession");
					printInfo("sent \"_hostFinalQuestionSession\"");
				}
				else if(fromServer.equals("_hostFinalQuestionSession")) {
					printInfo("receive \"_hostFinalQuestionSession\"");
					
					//Announcer exit.
					socket.close();
					printInfo("my socket is closed.");
					//break the while loop;
					break;
				}
				
				
			}
			
		}
		catch (UnknownHostException e) {
			System.err.println("Don't know about host. ");
			System.exit(1);
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection");
			System.exit(1);
		}
	}//run
	public String msg(String info) {
		return "Host " + info;
	}
	public void printInfo(String str) {
		System.out.println("Host: " + str);
	}
}//class






