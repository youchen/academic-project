package p2_1_Server;

import java.io.*;
import java.net.Socket;

public class Server_Thread extends Thread {
	private Socket socket = null;
	public static int numRounds, numQuestions, questionValues, room_capacity, num_contestants;
	public static double rightPercent;
	public static p1_Announcer AnnouncerTrd;
	public static p1_Contestants ContestantTrd;
	public static p1_Host HostTrd;
	
	public Server_Thread(Socket socket) {
		super("KKMultiServerThread");
		this.socket = socket;
	}

	public void run() {

		try (
				PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
				BufferedReader in = new BufferedReader(
						new InputStreamReader(socket.getInputStream()));
				) {
			String inputLine;
			/**
			 * send "Server is Ready." once the connection is established.
			 */
			out.println("Server is Ready.");
			while ((inputLine = in.readLine()) != null) {
				if(inputLine.equals("Configure")) {
					out.println("OK");
				}
				else if(inputLine.equals("Annoucer")) {
					//start ann thread.
					AnnouncerTrd = new p1_Announcer(socket, "Announcer");
					
					AnnouncerTrd.begin_run();
					/**
					 * wait for connection, then break this
					 * 		communication Stream.
					 */
					try {
						Thread.sleep(20);
					} catch (InterruptedException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					
					break;
				}
				else if(inputLine.contains("Contestant")) {
					//start contes. thread.
					ContestantTrd = new p1_Contestants(
							Integer.parseInt(
									inputLine.substring(10, inputLine.length())
									), socket);
					ContestantTrd.begin_run();
					/**
					 * wait for connection, then break this
					 * 		communication Stream.
					 */
					try {
						Thread.sleep(20);
					} catch (InterruptedException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					break;
				}
				else if(inputLine.equals("Host")) {
					//start host thread.
					HostTrd.soc = socket;
					HostTrd.begin_run();
					/**
					 * wait for connection, then break this
					 * 		communication Stream.
					 */
					try {
						Thread.sleep(20);
					} catch (InterruptedException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}
					break;
					
				}
				else if(inputLine.charAt(0) >= '0' &&  inputLine.charAt(0) <= '9') {
					/**
					 * Transmit parameters info.
					 */
					String[] arr = inputLine.split(" ");
					numRounds = Integer.parseInt(arr[0]);
					numQuestions = Integer.parseInt(arr[1]);
					questionValues = Integer.parseInt(arr[2]);
					rightPercent = Double.parseDouble(arr[3]);
					room_capacity = Integer.parseInt(arr[4]);
					num_contestants = Integer.parseInt(arr[5]);
					System.out.println("Parameter Transmitted Successfully!");
					/**
					 * After all set, just start the clock thread for time recording.
					 * 
					 * Initializing Thread clock.
					 */
					p1_Clock clock = new p1_Clock();
					clock.start();
					HostTrd = new p1_Host(null, "Host");
					break;
				}
			}//while


			
		} catch (IOException e) {
			e.printStackTrace();
		} 
		catch (Exception ex) {
			ex.printStackTrace();
		}
	}
}