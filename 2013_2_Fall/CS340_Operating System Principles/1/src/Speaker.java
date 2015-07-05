package CS340_P1_Youchen;
/**
 * Speaker class. All the events (presentation, movie and etc.) is triggered by speaker.
 * @author Youchen Ren
 */
public class Speaker extends Thread{
	
	public Speaker(String str) {
		super(str);
	}

	public void run() {
		/**
		 * Speaker arrived the museum, then museum is open and all the visitors could come in.
		 */
		message ("arrived.");
		System.out.println ("[" + Clock.age() + "] The Museum is Open!" );
		/**
		 * release the visitors from busy waiting for "outside the museum".
		 */
		EllisIsland.notOpen = false;
		/**
		 * To count how many sessions the Speaker conducted.
		 */
		int conductMovieSessionCount = 1;
		/**
		 * If movie session is not yet finished (not showed twice), 
		 * 		speaker continuously conducting the movie Session.
		 */
		while( EllisIsland.movieSession <= 2 ) {
			/**
			 * Speaker is waiting 1500 millisec (represent one and half hours) for visitor entering the lobby.
			 */
			try {
				Speaker.sleep(1500);
				if ( EllisIsland.seats == 0 ) {
					this.interrupt();
				}
			} catch (InterruptedException e) {}
			
			if (conductMovieSessionCount == 1 ) {
				System.out.println("\n\n\n");
				message("announced session starts, seats could be occupied.\n\n\n");
				EllisIsland.sessionNotStart = false;
			}
			
			//sleep 100 for visitor occupying the seats.
			try {
				Speaker.sleep(100);
			} catch (InterruptedException e2) {}
			
			System.out.println("\n\n\n\n\n\t\t\t\tSession " + EllisIsland.movieSession +
					".\n\n\n\n\n");
			/**
			 * Presentation
			 */
			while ( EllisIsland.seats != 0 ) {}

			message ("announced that presentation starts.");
			EllisIsland.presenStart = true;
			/**
			 * waiting for vistor's states printing.
			 */
			try {
				Speaker.sleep(20);
			} catch (InterruptedException e1) {}
			/**
			 * presentation is started.
			 */
			try {
				Speaker.sleep(200);
			} catch (InterruptedException e) {}
			EllisIsland.presenEnd = true;
			/**
			 * waiting for vistor's states printing.
			 */
			try {
				Speaker.sleep(20);
			} catch (InterruptedException e) {}
			/**
			 * Movie
			 */
			message ("announced that Movie starts.");
			try {
				EllisIsland.movieSession++;
				EllisIsland.showNotStart = false;
				Speaker.sleep(1500);
				this.interrupt();
			} catch (InterruptedException e) {}
			if (conductMovieSessionCount == 1) {
				System.out.println ("\n\n[" + Clock.age() + "] " + getName() + " " + 
						"announced 1st Movie session is end. " +
						"\n\t\tThe 2nd Movie Session will be Started in 15 minutes.\n\n");
			}
			else if (conductMovieSessionCount == 2) {
				message ("announced 2nd Movie session is end. " +
						"\n\t\tSorry, No more movie sessions today.");
				System.out.println("\n\n\n\n\n\t\t\t\tNo more Movie Sessions for today!\n\n\n\n\n");
			}
			EllisIsland.presenStart = false;
			EllisIsland.presenEnd = false;
			EllisIsland.showNotStart = true;
			/**
			 * Break for 15 millisec between the two sessions.
			 */
			try {
				Speaker.sleep(15);
			} catch (InterruptedException e) {}
			if (EllisIsland.movieSession == 1) {
				message ("announced 2nd Movie session is Started.");
			}
			conductMovieSessionCount = 2;
		}//while( EllisIsland.movieSession <= 2 ) {
		try {
			Speaker.sleep(200);
		} catch (InterruptedException e) {}
		
		System.out.println("\n\n\nThis is end of the day, Museum is closed now.");
		EllisIsland.notOpen = true;
		
		//waiting for visitor existing the museum.
		while (EllisIsland.leaveOrder > 0) {
			if (Visitor.foundMaxVisitor) {
				try {
					if(EllisIsland.leaveOrder == 0) {
						EllisIsland.finish = true;
					}
					
					else {
						Visitor.p.join();
						while(Visitor.p.isAlive()) {}
					}
				} catch (InterruptedException e) {}
			}
		}//while (EllisIsland.leaveOrder > 0) 
	
//w/o join();		
		//while (EllisIsland.leaveOrder > 0) {}
		
		System.out.println("[" + Clock.age() + "] " + 
				"All visitors gone, Speaker left the museum.");
		System.exit(0);
	}
	
	protected void message (String m) {
		System.out.println ("[" + Clock.age() + "] " + getName() + " " + m);
	}
}
