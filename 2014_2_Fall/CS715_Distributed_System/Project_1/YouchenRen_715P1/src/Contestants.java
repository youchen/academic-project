

import java.util.Random;


public class Contestants extends Thread{
	public int Id;
	public int ExamScore;
	public boolean IamTopFour = false;
	private boolean isRunning = true;
	public int showScore;
	public boolean stay = true;

	public Contestants (int id) {
		super ("Contestant-" + id);
		Id = id;
		ExamScore = 0;
		showScore = 0;
	}

	protected void message (String m) {
		System.out.println ("[" + Clock.age() + "] " + getName() + m);
	}

	public void run() {
		message(" initialized.");
		Main.ancr.formGroup();
		message(" going to enter the classroom.");
		try {
			Main.ancr.grabSeat();
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		message(" I've finished the exam, I am gonna wait for my score.");

		try {
			ExamScore = Main.ancr.getScore(Id);
		} catch (InterruptedException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}


		message(" I've got " + ExamScore + " in Exam. I'm gonna be told if I'm in the top Four.");
		try {
			IamTopFour = Main.ancr.checkWinner(Id);
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


		/**
		 * If this contestant is in the top Four.
		 * 		He(this thread) should be alive for the show.
		 * The best 4 Contestants will wait to start the game, the others will exit.
		 */
		if(isRunning) {

			/**
			 * wait to start the game
			 */
			try {
				Main.ancr.wait4GetIntroduced();
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			message(" Hi, Host! I am contestant " + Id + 
					".\n\tI'm ready and waiting for the Host to begin the game.");

			while(!(Main.hst.questionRound == Main.numRounds && Main.hst.questionNum == Main.numQuestions)) {
				/**
				 * Answer the host's question.
				 */
				try {
					Main.hst.QuestionAnswer(Id);
				} catch (InterruptedException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}


				message(" I'm thinking Question #" + Main.hst.questionNum + "...");


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
					if (Main.hst.questionAnswered == false) {
						Main.hst.questionAnswered = true;
						message(" I have the answer!");
						synchronized (Main.hst.wait4Answer) {
							Main.hst.wait4Answer.notify();
							Main.hst.wait4Answer.clear();
						}

						try {
							Main.hst.waitForCorrectnessChecking();
						} catch (InterruptedException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}

						if(Main.hst.correctness == true) {
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
			
			/**
			 * wait for Final Guess What or Who
			 */
			try {
				Main.hst.waitForFinal();
			} catch (InterruptedException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

			message(" I'm done for answering the question.");
			Main.hst.NotifyHostFinishAnswering();
			stay = Main.hst.stayOrLeave(Id, showScore);
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
					Main.hst.finalQ(Id, showScore);
				}
				message(" Final is done, I am going home.");
				
			}


		}//if(isRunning)


	}//run()

	public int randNum(int Low, int High) {
		Random r = new Random();
		return r.nextInt(High-Low) + Low;
	}



}
