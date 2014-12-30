package p2_1_Server;



import java.io.IOException;
import java.net.ServerSocket;

public class Server_Main {
	public static void main(String[] args) throws IOException {
		/**
		 * 
		 * If these <port number> are unspecified,
		 * 	default value for
		 * 		port number: 2222
		 */
		int portNumber	= (args.length == 0 )? 2222	: Integer.parseInt(args[0]);
	
		boolean listening = true;

		try (ServerSocket serverSocket = new ServerSocket(portNumber)) { 
			while (listening) {
				new Server_Thread(serverSocket.accept()).start();
			}
		} catch (IOException e) {
			System.err.println("Could not listen on port " + portNumber);
			System.exit(-1);
		} catch (Exception e) { 
			e.printStackTrace();
			
		}
	}
}