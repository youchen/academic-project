package p2_1_Server;


import java.io.*;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Random;

public class p1_Announcer extends Thread{

	public static ArrayList<Object> examGroup = new ArrayList<Object>();
	public static volatile int membersInGroup = 0;
	public static int groupFormed = 0;
	public static ArrayList<Object> seat = new ArrayList<Object>();
	public static volatile int membersInRoom = 0;
	public static int examProctored = 0;
	public static int exam_time = 500;
	public static ArrayList<Object> finishExam = new ArrayList<Object>();
	public static int peoplefinishedExam = 0;
	public static int[] Scores = new int[Server_Thread.num_contestants];
	public static ArrayList<Object> checkWinnerArr = new ArrayList<Object>();
	public static int hasChecked = 0;
	public static ArrayList<Object> wait4DecideWinner = new ArrayList<Object>();
	public static int[] winnersID = new int[4];
	public static ArrayList<Object> wait4ShowStart = new ArrayList<Object>();
	public ArrayList<Object> waitToStartShow = new ArrayList<Object>();
	public static ArrayList<Object> contestantWaitForIntro = new ArrayList<Object>();
	private Socket soc = null;
	public static boolean canStart = false;
	
	

	public p1_Announcer(Socket s, String str) {
		super(str);
		this.soc = s;
	}

	protected void message (String m) {
		System.out.println ("[" + p1_Clock.age() + "] " + getName() + " " + m);
	}

	public void run() {
		
	}
	
	public void begin_run() {
		try (
			PrintWriter out = new PrintWriter(soc.getOutputStream(), true);
			BufferedReader in = new BufferedReader(
					new InputStreamReader(soc.getInputStream()));
			){
			String fromClient;
			out.println("Announcer is Ready.");


			while((fromClient =  in.readLine()) != null) {

				if(fromClient.equals("_waitForDecideWinner")) {

					_waitForDecideWinner();
					out.println("_waitForDecideWinner");
				}
				else if(fromClient.equals("_computeTop4HighestScore")) {
					_computeTop4HighestScore();
					out.println("_computeTop4HighestScore");
				}
				else if(fromClient.equals("_wait4ShowStart")) {
					_wait4ShowStart();
					out.println("_wait4ShowStart");
				}
				else if(fromClient.equals("_introHost")) {
					_introHost();
					out.println("_introHost");
				}
				else if(fromClient.equals("_introContestant")) {
					_introContestant();
					out.println("_introContestant");
				}
				else if(fromClient.equals("_waitToStartShow")) {
					_waitToStartShow();
					out.println("_waitToStartShow");

					//break the while loop.
					break;
				}
				
			}//while
		}//try
		catch (UnknownHostException e) {
			System.err.println("Don't know about host.");
			System.exit(1);
		} catch (IOException e) {
			System.err.println("Couldn't get I/O for the connection.");
			System.exit(1);
		} 
		catch (Exception e) {
			e.printStackTrace();
		}
			
		/**
		 * Announcer exit.
		 */
	}//run

	public void _waitForDecideWinner() {
		//_waitForDecideWinner
				message(" initialized.");
				/**
				 * Wait for contestants' score and then decide which 4 are the winners.
				 */
				try {
					synchronized (wait4DecideWinner) {
						wait4DecideWinner.wait();
					}
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
	}
	
	public void _computeTop4HighestScore() {
		//compute top 4 highest score.
				/*
				 * Compute the top 4 highest scores, store the indices into winnersID.
				 */
				indexesOfTopElements();
	}
	
	public void _wait4ShowStart() {
		//wait4ShowStart
				/**
				 * Wait for show Start
				 */
				try {
					synchronized (wait4ShowStart) {
						wait4ShowStart.wait();
					}
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
	}
	
	public void _introHost() {
		//intro Host
				/**
				 * To start the show, the Announcer thread will print an 
				 * 			opening message (something useful, it is up to you) 
				 * 			and create the Host thread.
				 */
				message("Openning Message: Show will Start!");
				_waitToStartShow();
				try {
					Thread.sleep(200);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
	}
	
	public void _introContestant() {
		//intro contestant
				message("Introducing our 4 contestants.");
				/**
				 * Introducing(signal) contestants, Let them print greeting messages.
				 */
				synchronized (contestantWaitForIntro) {
					contestantWaitForIntro.notifyAll();
				}
	}
	
	public void _waitToStartShow() {
		//wait to start show
				/**
				 * Wait for contestants' greetings!
				 */
				try {
					Thread.sleep(20);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				synchronized (waitToStartShow) {
					canStart = true;
					waitToStartShow.notifyAll();
				}
	}
	
	public void formGroup() {
		Object lock = null;
		synchronized(examGroup) {
			examGroup.add(lock);
			membersInGroup++;
			if(membersInGroup == Server_Thread.room_capacity || 
					groupFormed * Server_Thread.room_capacity + membersInGroup == Server_Thread.num_contestants ) {

				membersInGroup = 0;
				groupFormed++;
				examGroup.notifyAll();

				message(" Group " + groupFormed + " formed!\n\tYour group could enter the classroom.");
				examGroup.clear();

			}

		}//syn
		synchronized(examGroup) {
			if(membersInGroup != 0) {
				while(true) {
					try {
						examGroup.wait();
						break;
					} catch (InterruptedException e) {
						// TODO: handle exception
						break;
					}
				}//while
			}
		}//sync
	}//formGroup

	public void grabSeat() throws InterruptedException {
		Object sit = null;

		synchronized(seat){
			seat.add(sit);
			membersInRoom++;
			if(membersInRoom == Server_Thread.room_capacity || 
					examProctored * Server_Thread.room_capacity + membersInRoom == Server_Thread.num_contestants ) {

				membersInRoom = 0;
				examProctored++;
				message(" Exam " + examProctored + " will start.");
				message(" Exam " + examProctored + " stars!");
				Thread.sleep(exam_time);
				message(" Exam " + examProctored + " ends!");
				seat.notifyAll();
				seat.clear();
			}

		}//syn
		synchronized(seat) {

			if(membersInRoom != 0) {
				while(true) {

					try {
						seat.wait();
						break;

					} catch (InterruptedException e) {
						// TODO: handle exception
						break;

					}
				}//while
			}
		}//sync
	}

	public int getScore(int id) throws InterruptedException {
		Object waitForScore = null;

		synchronized (finishExam) {
			++peoplefinishedExam;
			finishExam.add(waitForScore);
			if(peoplefinishedExam == Server_Thread.num_contestants) {
				message(" All contestants finished Exam.");
				/*
				 * Generate num_ contestants random numbers.
				 */
				for (int i = 0; i < Scores.length; i++) {
					Scores[i] = randNum(1, 100);
				}
				//Notify Announcer to compute the winners.
				synchronized (wait4DecideWinner) {
					wait4DecideWinner.notify();
				}
				/**
				 * Give some time for Announcer to compute the winners
				 */
				Thread.sleep(10);
				/*
				 * After generate num_ contestants random numbers,
				 * 		Every contestant will get their score based on
				 * 		their Id number.
				 */
				finishExam.notifyAll();
				finishExam.clear();
			}
		}
		synchronized (finishExam) {
			if(peoplefinishedExam != Server_Thread.num_contestants) {
				while(true) {
					try {
						message(" one contestants waiting for his score.");
						finishExam.wait();
						//message(" I'm out===========");
						break;
					} catch (InterruptedException e) {
						// TODO: handle exception
						break;
					}
				}//while
			}
		}//sync

		/**
		 * First number will relate to Contestant 1, second number to Contestant 2, and so on.
		 */
		return Scores[id - 1];
	}//wait4score

	/*
	 * This returns a random number in between 
	 * 		Low (inclusive) and High (exclusive)
	 */
	public int randNum(int Low, int High) {
		Random r = new Random();
		return r.nextInt(High-Low) + Low;
	}

	public void indexesOfTopElements() {//, int nummax) {
		int[] copy = Arrays.copyOf(Scores, Scores.length);
		Arrays.sort(copy);
		int[] honey = Arrays.copyOfRange(copy, copy.length - 4, copy.length);
		//int[] result = new int[4];
		int resultPos = 0;
		for(int i = 0; i < Scores.length; i++) {
			int onTrial = Scores[i];
			int index = Arrays.binarySearch(honey, onTrial);
			if(index < 0) continue;
			winnersID[resultPos++] = i;
		}
	}

	
	public boolean checkWinner(int id) throws InterruptedException {
		Object winnerPending = new Object();
		synchronized (checkWinnerArr) {
			checkWinnerArr.add(winnerPending);
			++hasChecked;
			
		}
		synchronized (checkWinnerArr.get(0)) {
			for (int item : winnersID) {
				if(id == item + 1) {
					message(" Contestant " + id + ", You are in the top Four!");
					checkWinnerArr.remove(0);
					return true;
				}
			}//for
			checkWinnerArr.remove(0);
			Thread.sleep(50);
			/**
			 * if at this moment, all the contestants know their result,
			 * 		we need to notify the announcer for the next step process.
			 */
			if(hasChecked == Server_Thread.num_contestants) {
				synchronized (wait4ShowStart) {
					wait4ShowStart.notify();
				}
				
			}
		}//sync
		return false;
	}//checkWinner

	public void hostWaitForShowStart() {
		//Object xx = new Object();
		synchronized (waitToStartShow) {
			try {
				//waitToStartShow.add(xx);
				if(!canStart)
					waitToStartShow.wait();
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}//public
	
	public void wait4GetIntroduced() throws InterruptedException {
		
		synchronized (contestantWaitForIntro) {
			contestantWaitForIntro.wait();
		}
	}
}//








