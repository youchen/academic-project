


import java.util.ArrayList;
import java.util.Random;


public class Host extends Thread{

	public int questionRound = 0;
	public int questionNum = 0;

	public ArrayList<Object> wait4Asking = new ArrayList<Object>();
	public ArrayList<Object> wait4Answer = new ArrayList<Object>();
	public boolean questionAnswered = false;
	public boolean correctness = false;

	public ArrayList<Object> wait4CorrectnessChecking = new ArrayList<Object>();

	public boolean roundFinished = false;

	public ArrayList<Object> wait4Final = new ArrayList<Object>();
	public ArrayList<Object> wait4startFinal = new ArrayList<Object>();

	public ArrayList<Object> wait4notifyAnswering = new ArrayList<Object>();
	public ArrayList<Object> notifyArr = new ArrayList<Object>();
	
	public ArrayList<Object> wait4LastQ = new ArrayList<Object>();

	public int[][] finalScore = new int [4][2];
	public int finalScoreIndex = 0;
	
	public int winnerID;
	
	
	public Host(String str) {
		super(str);
	}

	protected void message (String m) {
		System.out.println ("[" + Clock.age() + "] " + getName() + ": " + m);
	}

	public void run() {
		/**
		 * initialize all cell of finalScore to 0;
		 */
		for (int i = 0; i < finalScore.length; i++) {
			for (int j = 0; j < finalScore[i].length; j++) {
				finalScore[i][j] = 0;
			}
		}
		message("Hello, I am the host of the show tonight. Welcome!");
		Main.ancr.hostWaitForShowStart();
		message("Show is started!");
		

		try {
			Question();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		/**
		 * wait for contestants to signal that they are ready for Final.
		 */
		try {
			startFinal();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

//		System.out.println("*********");
		/**
		 * signal Contestants in order.
		 */
		for (int i = 0; i <= 3; i++) {
			synchronized (wait4Final.get(0)) {

				wait4Final.get(0).notify();
				wait4Final.remove(0);
			}
		}

		/**
		 * wait for contestant to notify they have finished answering.
		 */
		try {
			waitForNotifyAnswering();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
//		System.out.println("@@@@@@");
		
		
		
		/**
		 * wait for last Question finish
		 */
		try {
			waitLastQuestion();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		message(" I'm updating the score, winner will be revealed soon.");
		/**
		 * updating the scores.
		 */
		try {
			message(" Score updating...");
			Thread.sleep(150);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		int hs = highestScore(finalScore);
		message(" The winner is contestant-" + winnerID +", his score is " + hs 
				+".\n\t\tThank you for watching the show, I am going home.");
		
		
		
	}//run()



	

	public void Question() throws InterruptedException {
		++questionRound;
		while( questionRound <= Main.numRounds) {



			++questionNum;
			while( questionNum <= Main.numQuestions) {
				correctness = false;
				questionAnswered = false;
				message("This is Round " + questionRound + ", I am asking Question #" + questionNum + ".");
				//could wait for printing here*****
				synchronized (wait4Asking) {
					wait4Asking.notifyAll();
					wait4Asking.clear();
				}
				//wait for contestants' answer.
				waitForAnswer();
				//check correctness of the answer.
				int ans = randNum(1, 101);
				if(ans <= Main.rightPercent * 100) {
					correctness = true;
					message("Your answer is right!");
					synchronized (wait4CorrectnessChecking) {
						wait4CorrectnessChecking.notifyAll();
						wait4CorrectnessChecking.clear();
					}
				}
				else {
					message("Your answer is wrong!");
					synchronized (wait4CorrectnessChecking) {
						wait4CorrectnessChecking.notifyAll();
						wait4CorrectnessChecking.clear();
					}
				}
				/**
				 * wait for contestants' status printing.
				 */
				try {
					Thread.sleep(100);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				++questionNum;
			}//while( questionNum
			questionNum = 0;
			++questionRound;
		}//while( questionRound 

	}

	public void QuestionAnswer(int id) throws InterruptedException {
		Object waitToken = new Object();
		synchronized (wait4Asking) {
			wait4Asking.add(waitToken);
		}
		synchronized (wait4Asking) {
			wait4Asking.wait();
		}
	}

	public void waitForAnswer() throws InterruptedException {
		Object waiting = new Object();	
		synchronized (wait4Answer) {
			wait4Answer.add(waiting);
		}
		synchronized (wait4Answer) {
			wait4Answer.wait();
		}
	}

	public int randNum(int Low, int High) {
		Random r = new Random();
		return r.nextInt(High-Low) + Low;
	}

	public void waitForCorrectnessChecking() throws InterruptedException {
		Object waiting = new Object();	
		synchronized (wait4CorrectnessChecking) {
			wait4CorrectnessChecking.add(waiting);
		}
		synchronized (wait4CorrectnessChecking) {
			wait4CorrectnessChecking.wait();
		}
	}

	public void waitForFinal()  throws InterruptedException {
		Object waiting = new Object();	
		synchronized (wait4Final) {
			wait4Final.add(waiting);
		}
		synchronized (wait4Final.get(wait4Final.size() - 1)) {
			if(wait4Final.size() == 4) {
				try {
					Thread.sleep(100);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
//				System.out.println("hhh======");
				synchronized (wait4startFinal) {

					wait4startFinal.notifyAll();
				}
			}//if

			wait4Final.get(wait4Final.size() - 1).wait();
		}
	}

	public void startFinal() throws InterruptedException {
		Object waiting = new Object();	
		synchronized (wait4startFinal) {
			wait4startFinal.add(waiting);
		}
		synchronized (wait4startFinal) {
			wait4startFinal.wait();
		}
	}



	public void waitForNotifyAnswering() throws InterruptedException {
		Object waiting = new Object();
		synchronized (wait4notifyAnswering) {
			wait4notifyAnswering.add(waiting);
		}
		synchronized (wait4notifyAnswering) {
			wait4notifyAnswering.wait();
		}
	}

	public void NotifyHostFinishAnswering() {
		Object noti = new Object();
		synchronized (notifyArr) {
			notifyArr.add(noti);
			if(notifyArr.size() == 4) {
				synchronized (wait4notifyAnswering) {
					wait4notifyAnswering.notifyAll();
				}
			}
		}
	}

	public boolean stayOrLeave(int id, int showScore) {
	
		if(showScore < 0) {
			message(" Sorry, Contestant-" + id +", Your score is negative.");
			return false;
		}else 
		return true;
	}

	public void waitLastQuestion() throws InterruptedException{
		Object waiting = new Object();
		synchronized (wait4LastQ) {
			wait4LastQ.add(waiting);
		}
		synchronized (wait4LastQ) {
//			System.out.println("&&&&&&");
			wait4LastQ.wait();
		}
	}
	
	public void finalQ(int Id, int score) {
		int wager = randNum(0, score + 1);
		int correct = randNum(1, 101);
		//right answer
		if(correct <= 50) {
			score += wager;
			finalScore[finalScoreIndex][0] = Id;
			finalScore[finalScoreIndex++][1] = score;
			//In either scenario, notify the host.
			synchronized (wait4LastQ) {
//				System.out.println("^^^");
				wait4LastQ.notify();
				wait4LastQ.clear();
			}
 		}else {//wrong answer.
			score -= wager;
			finalScore[finalScoreIndex][0] = Id;
			finalScore[finalScoreIndex++][1] = score;
			//In either scenario, notify the host.
			synchronized (wait4LastQ) {
//				System.out.println("^^^-----");
				wait4LastQ.notify();
				wait4LastQ.clear();
			}
		}
	}
	
	public int highestScore(int[][] arr) {
		int temp = Integer.MIN_VALUE;
		for (int i = 0; i < arr[0].length; i++) {
			if(arr[i][0] != 0 && arr[i][1] > temp) {
				temp = arr[i][1];
				winnerID = arr[i][0];
			}
		}
		return temp;
	}
}
