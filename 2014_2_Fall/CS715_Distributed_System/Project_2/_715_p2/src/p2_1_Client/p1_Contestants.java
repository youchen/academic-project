package p2_1_Client;


import java.io.*;
import java.net.*;


public class p1_Contestants extends Thread{
	public int Id;
	private Socket socket = null;
	
	public p1_Contestants (int id, Socket Csoc) {
		super ("Contestant-" + id);
		Id = id;
		this.socket = Csoc;
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
			printInfo("I'm started.");
			
			
			while((fromServer = in.readLine()) != null) {

				if(fromServer.equals("Server is Ready.")) {
					printInfo("receive \"Server is Ready.\"");
					out.println("Contestant" + Id);
					printInfo("sent \"Contestant" + Id + "\"");
				}//if
				else if(fromServer.equals("Contestant is Ready.")) {
					printInfo("receive \"Contestant is Ready.\"");
					out.println("_formGroup");
					printInfo("sent \"_formGroup\"");
				}
				else if(fromServer.equals("_formGroup")) {
					printInfo("receive \"_formGroup\"");
					out.println("_grabSeat");
					printInfo("sent \"_grabSeat\"");
					
				}
				else if(fromServer.equals("_grabSeat")) {
					printInfo("receive \"_grabSeat\"");
					out.println("_getScore");
					printInfo("sent \"_getScore\"");
				}
				else if(fromServer.equals("_getScore")) {
					printInfo("receive \"_getScore\"");
					out.println("_IamTopFour");
					printInfo("sent \"_IamTopFour\"");
					//start host
				}
				else if(fromServer.equals("_IamTopFour")) {
					printInfo("receive \"_IamTopFour\"");
					out.println("_QuestionSession");
					printInfo("sent \"_QuestionSession\"");
				}
				else if(fromServer.equals("_QuestionSession")) {
					printInfo("receive \"_QuestionSession\"");
					
					out.println("_finalQuestionSession");
					printInfo("sent \"_finalQuestionSession\"");
				}
				else if(fromServer.equals("_finalQuestionSession")) {
					printInfo("receive \"_finalQuestionSession\"");
					//Contestant exit.
					socket.close();
					printInfo("my socket is closed.");
					//break the while loop;
					break;
				}//else if
			}//while
		}//try
		catch (UnknownHostException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} 
		
	}//run
	public String msg(String info) {
		return "Contestant " + info;
	}
	
	public void printInfo(String str) {
		System.out.println("Contestant - " + Id + ": " + str);
	}
}//class






