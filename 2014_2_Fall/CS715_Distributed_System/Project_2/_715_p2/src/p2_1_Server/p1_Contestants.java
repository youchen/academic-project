package p2_1_Server;


import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Random;



public class p1_Contestants extends Thread{
	public int Id;
	public int ExamScore;
	public boolean IamTopFour = false;
	private boolean isRunning = true;
	public int showScore;
	public boolean stay = true;
	private Socket soc = null;
	
	public p1_Contestants (int id, Socket Csoc) {
		super ("Contestant-" + id);
		Id = id;
		ExamScore = 0;
		showScore = 0;
		this.soc = Csoc;
	}

	protected void message (String m) {
		System.out.println("[" + p1_Clock.age() + "] " + getName() + m);
	}

	public void run() {}
	
	public void begin_run() {
		try {
			PrintWriter out = new PrintWriter(soc.getOutputStream(), true);
			BufferedReader in = new BufferedReader(
					new InputStreamReader(soc.getInputStream()));
			
			
			String fromClient;
			out.println("Contestant is Ready.");
			
			
				while((fromClient = in.readLine()) != null) {
				
					if(fromClient.equals("_formGroup")) {
						_formGroup();
						out.println("_formGroup");
					}
					else if(fromClient.equals("_grabSeat")) {
						_grabSeat();
						out.println("_grabSeat");		
					}
					else if(fromClient.equals("_getScore")) {
						_getScore();
						out.println("_getScore");
					}
					else if(fromClient.equals("_IamTopFour")) {
						_IamTopFour();
						out.println("_IamTopFour");
					}
					
					//join the show or not
					/**
					 * If this contestant is in the top Four.
					 * 		He(this thread) should be alive for the show.
					 * The best 4 Contestants will wait to start the game, the others will exit.
					 */
					else if(isRunning) {
						if(fromClient.equals("_QuestionSession")) {
							_QuestionSession();
							out.println("_QuestionSession");
						}
						else if(fromClient.equals("_finalQuestionSession")) {
							_finalQuestionSession();
							out.println("_finalQuestionSession");
						}
					}//if isRunning
					else {
						break;
					}
			}//while
		}//try
		catch (UnknownHostException e) {
			System.err.println("Don't know about host.");
			System.exit(1);
			e.printStackTrace();
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection.");
			System.exit(1);
			e.printStackTrace();
		}
	}//run()
	
	public void _formGroup() {
		//formGroup
				message(" initialized.");
				Server_Thread.AnnouncerTrd.formGroup();
				message(" going to enter the classroom.");
	}
	
	public void _grabSeat() {
		//grab seat
				try {
					Server_Thread.AnnouncerTrd.grabSeat();
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				message(" I've finished the exam, I am gonna wait for my score.");
	}
	
	public void _getScore() {
		//getScore
				try {
					ExamScore = Server_Thread.AnnouncerTrd.getScore(Id);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				message(" I've got " + ExamScore + " in Exam. I'm gonna be told if I'm in the top Four.");
	}
	
	public void _IamTopFour() {
		//IamTopFour
				try {
					IamTopFour = Server_Thread.AnnouncerTrd.checkWinner(Id);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				if(IamTopFour)
					message(" I'am one of top four!");
				else {
					message(" I did not get chance, I will back home.");
					//kill this thread.
					isRunning = false;
				}
	}
	
	
	public int randNum(int Low, int High) {
		Random r = new Random();
		return r.nextInt(High-Low) + Low;
	}
	public void _QuestionSession() {

		/**
		 * wait to start the game
		 */
		try {
			Server_Thread.AnnouncerTrd.wait4GetIntroduced();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		message(" Hi, Host! I am contestant " + Id + 
				".\n\tI'm ready and waiting for the Host to begin the game.");

		while(!(Server_Thread.HostTrd.questionRound == Server_Thread.numRounds && Server_Thread.HostTrd.questionNum == Server_Thread.numQuestions)) {
			/**
			 * Answer the host's question.
			 */
			try {
				Server_Thread.HostTrd.QuestionAnswer(Id);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			message(" I'm thinking Question.");

			/**
			 * Thinking (Sleep for random time) 
			 * 		range: 1 ~ 100 ms
			 */
			try {
				Thread.sleep(randNum(1, 101));
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			synchronized (this) {
				if (Server_Thread.HostTrd.questionAnswered == false) {
					Server_Thread.HostTrd.questionAnswered = true;
					message(" I have the answer!");
					synchronized (Server_Thread.HostTrd.wait4Answer) {
						Server_Thread.HostTrd.wait4Answer.notify();
						Server_Thread.HostTrd.wait4Answer.clear();
					}

					try {
						Server_Thread.HostTrd.waitForCorrectnessChecking();
					} catch (InterruptedException e) {
						// TODO Auto-generated catch block
						e.printStackTrace();
					}

					if(Server_Thread.HostTrd.correctness == true) {
						showScore += 10;
						message(" I got it right! My current score is " + showScore + ".");
					}else {
						showScore -= 5;
						message(" Oh, I was wrong. My current score is " + showScore + ".");
					}
				}else {
					/**
					 * question is answered by others, wait for next question.
					 */
					message(" I lost the chance, others answerd question.");

					
				}
			}//synchronized (this) 

		}//while
	}//_QQ
	
	public void _finalQuestionSession() {
		/**
		 * wait for Final Guess What or Who
		 */
		try {
			Server_Thread.HostTrd.waitForFinal();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		message(" I'm done for answering the question.");
		Server_Thread.HostTrd.NotifyHostFinishAnswering();
		stay = Server_Thread.HostTrd.stayOrLeave(Id, showScore);
		if(stay == false) {
			message(" Oh, I've got negative score, I'll back home. Good-bye.");
		}else {
			/**
			 * wait for Host status printing.
			 */
			try {
				Thread.sleep(150);
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			/**
			 * Final Question
			 */
			synchronized (this) {
				Server_Thread.HostTrd.finalQ(Id, showScore);
			}
			message(" Final is done, I am going home.");
			
		}
	}
	

}
