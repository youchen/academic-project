import java.io.BufferedReader;
import java.io.FileReader;
public class fingerPrint_Match {
	public static void main(String[] args) {
		if(args.length == 0)System.out.println("No file specified.");
		else{
			FileReader theFile1, theFile2;
			BufferedReader inFile1, inFile2;
			String oneLine1, oneLine2;
			double a[][] = new double [100][3];
			double b[][] = new double [100][3];
			/**
			 * Read the input and store all the data into 2 arrays, they are 2D arrays a and b.
			 * 		Store data set 1 into 2D Array a.
			 */
			try{//FileNotFoundException must be caught
				theFile1 = new FileReader(args[0]); 
				inFile1 = new BufferedReader(theFile1); 
				/** now read the text file line by line.*/
				oneLine1 = inFile1.readLine();
				int n = 0;
				while( !( oneLine1.isEmpty() ) ) {
					String numbers[] = oneLine1.split(" ");			
					for (int i = 0; i < numbers.length; i++) {
						if (n == 0 && i == 2) {
							a[n][i] = 0;
						}
						else
							a[n][i] = Integer.parseInt(numbers[i]);
					}
					oneLine1 = inFile1.readLine();
					n++;
				}//While					
			}//try
			catch (Exception e){}
			/**
			 * Store Data Set 2 into Array b.
			 */
			try{//FileNotFoundException must be caught
				theFile2 = new FileReader(args[1]); 
				inFile2 = new BufferedReader(theFile2); 
				/** now read the text file line by line.*/
				oneLine2 = inFile2.readLine();
				int n = 0;
				while( !( oneLine2.isEmpty() ) ) {
					String numbers[] = oneLine2.split(" ");
					for (int i = 0; i < numbers.length; i++) {
						if (n == 0 && i == 2) {
							b[n][i] = 0;
						}
						else
							b[n][i] = Integer.parseInt(numbers[i]);
					}
					oneLine2 = inFile2.readLine();
					n++;
				}//While					
			}//try
			catch (Exception e){}
			double temp[][] = new double [6][4];
			double tempB[][] = new double [6][4];
			boolean f1 = false, f2 = false, f3 = false, f4 = false, f5 = false, f6 = false;
			/**
			 * Assign Value to 12 x 4 array.
			 * 		Data Set 1 first.
			 */
			make_6x4_table(a, temp, f1, f2, f3, f4, f5, f6);
			f1 = false; f2 = false; f3 = false; f4 = false; f5 = false; f6 = false; 
			make_6x4_table(b, tempB, f1, f2, f3, f4, f5, f6);
			/**
			 *  the two 6 x 4 table which recorded the nearest and farthest distance from Nucleus are ESTABLISHED.
			 */
			for (int i = 0; i < temp.length; i++) {
				for (int k = 0; k < temp[0].length; k++) {
					System.out.println("temp[" + i + "][" + k + "]" + temp[i][k] + " ");
				}
				System.out.println("\n");
			}
			System.out.println("=====================================");
			for (int i = 0; i < tempB.length; i++) {
				for (int k = 0; k < tempB[0].length; k++) {
					System.out.println("tempB[" + i + "][" + k + "]" + tempB[i][k] + " ");
				}
				System.out.println("\n");
			}
			/**
			 *  Modify the data for testing the algorithm below.
			 */
			int Nearest_Match = 0, Farthest_Match = 0;
			for (int k = 1; k <= 3; k += 2 ) {
				for (int i = 0; i < tempB.length; i++) {
					for (int j = 0; j < temp.length; j++) {
						if ( ( tempB[i][k] == temp[j][k] ) && (tempB[i][k-1] - temp[j][k-1] == 0) ) {
							if 		(k == 1) Nearest_Match++;
							else if (k == 3) Farthest_Match++;
						}
					}
				}
			}
			System.out.println("Based on the two 6 x 4 table and comparison: there are\n\t" + Nearest_Match + 
					" matches for Nearest Points and \n\t" + Farthest_Match + " matches for Farthest Points.");
			if (Nearest_Match != 6 && Farthest_Match != 6) {
				System.out.println("\nConclusion: These two fingerprints are DIS-MATCH!");
			}
			else if (Nearest_Match == 6 && Farthest_Match == 6) {
				System.out.println("\nConclusion: These two fingerprints are MATCH!");
			}
		}//else (if input file exists)
	}//main
	public static double Dis ( double[][] a, double[][] a2, int j){
		/**
		 *  as Nucleus is fixed, we know that θ2 is fixed.
		 * 			θ2 = arctan ( a[0][1] / a[0][0] );
		 *  and based on Hough Transform:
		 *  		θ3 = arctan ( a[j][1] / a[j][0] );
		 *  we need to get θ and r based on the line which the Nucleus and the point defined:
		 *  		the Line:
		 *  			( y - a[0][1] ) / ( a[j][1] - a[0][1] ) = ( x - a[0][0] ) / ( a[j][0] - a[0][0] )
		 *  therefore:
		 *  		when x = 0, y is the y-intercept of the line;
		 *  			y-i = ( (-a[0][0]) / (a[j][1] - a[0][1]) ) / ( a[j][0] - a[0][0] ) ) + a[0][1]
		 *  		when y = 0, x is the x-intercept of the line;
		 *  			x-i = ( (-a[0][1]) / (a[j][0] - a[0][0]) ) / ( a[j][1] - a[0][1] ) ) + a[0][0]
		 *  
		 *  			θ = arctan( x-i / y-i )
		 *  			r = cos θ * x-i
		 *  
		 *  T represents Theta.
		 */
		double T2 = Math.atan( ( (double)a[0][1] ) / ( (double)a[0][0] ) );
		double T3 = Math.atan( ( (double)a2[j][1] )/  ( (double)a2[j][0] ) );
		double yi = ( (-a[0][0]) / (a2[j][1] - a[0][1]) ) / ( a2[j][0] - a[0][0] ) + a[0][1];
		double xi = ( (-a[0][1]) / (a2[j][0] - a[0][0]) ) / ( a2[j][1] - a[0][1] ) + a[0][0];
		double T  = Math.atan ( xi / yi );
		double r  = Math.cos(T) * xi;
		double returnValue = r * Math.tan (T - T3 ) - r * Math.tan (T - T2);
		returnValue = Math.abs(returnValue);				
		return returnValue;
	}
	public static void findMaxMinDis(boolean f, int i, int j, double [][] a, double [][]temp){
		if (f == false) {
			/**
			 * if it's the case that the 1st point fall in this Region.
			 */
			temp[i][0] = Dis(a, a, j);
			temp[i][1] = a[j][2];
			temp[i][2] = Dis(a, a, j);
			temp[i][3] = a[j][2];
			f = true;
		}
		/**
		 * the following points fall into this Region will compare with the previous value.
		 */
		else if ( ( temp[i][0] > Dis(a, a, j) ) && ( f == true) ) {
			temp[i][0] = Dis(a, a, j);
			temp[i][1] = a[j][2];
		}
		else if ( ( temp[i][2] < Dis(a, a, j) ) && ( f == true) ) {
			temp[i][2] = Dis(a, a, j);
			temp[i][3] = a[j][2];
		}
	}
	public static void make_6x4_table(double [][]a, double [][] temp, boolean f1, boolean f2, boolean f3, boolean f4, boolean f5, boolean f6) {
		for (int j = 1; j < a.length; j++) {
			/**	a[0][0] = x
			 * 	a[0][1] = y
			 * 	a[0][2] = Type
			 * 
			 * 	row a[1] compare row a[0];
			 */
			if ( a[j][0] > a[0][0] ) {
				/**
				 * 	the point (which row a[j] is represented) is on RIGHT hand side
				 * 		of Nucleus.
				 * 	Then to classify that this point is in which region.
				 * 	I decided to divide the whole first quadrant into 6 regions 
				 * 		as the center is the Nucleus Point.
				 * 	Therefore, 3 straight lines divide the first quadrant into 6 regions.
				 * 	The equation of the 3 lines are:
				 * 		x = a[0][0]
				 * 		y = tan(π/6) * ( x - a[0][0] ) + a[0][1]
				 * 		y = tan(-π/6) * ( x - a[0][0] ) + a[0][1]
				 * 	I named 1 region is the one which is on the RIGHT hand side of the 
				 * 		perpendicular line to the x-axis and on the uppermost side of the 
				 * 		line y = tan(π/6) * ( x - a[0][0] ) + a[0][1], and then as the order
				 * 		of clock-wise, name the succeding region as region 2, 3, 4, 5 and 6.
				 * 	As this figure shows:
				 * 				\      |      /
				 *			      \  6 |  1 /
				 *			       \   |   /
				 *			         \ | /
				 *			     5   / | \      2
				 *			        /  |  \
				 *			      /    |   \
				 *			     /  4  |  3  \
				 *			   /       |      \
				 *  
				 * 
				 */
				if ( a[j][1] >= ( Math.tan(Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1] ) ) {
					/**
					 * 	it's in Region 1.
					 * 
					 * 	After knowing the region, We need to calculate the nearest and farthest
					 * 		distance from the Nucleus by using the Hough transform Formula:
					 * 			c = r * tan( θ - θ3 ) - r * tan( θ - θ2)
					 *  See the method below:
					 *  		public static double Dis ( int [][]a, int [][] p, int j)
					 */
					if (f1 == false) {
						/**
						 * if it's the case that the 1st point fall in this Region.
						 */
						temp[0][0] = Dis(a, a, j);
						temp[0][1] = a[j][2];
						temp[0][2] = Dis(a, a, j);
						temp[0][3] = a[j][2];
						f1 = true;
					}
					/**
					 * the following points fall into this Region will compare with the previous value.
					 */
					else if ( ( temp[0][0] > Dis(a, a, j) ) && ( f1 == true) ) {
						temp[0][0] = Dis(a, a, j);
						temp[0][1] = a[j][2];
					}
					else if ( ( temp[0][2] < Dis(a, a, j) ) && ( f1 == true) ) {
						temp[0][2] = Dis(a, a, j);
						temp[0][3] = a[j][2];
					}
				}
				else if ( (a[j][1] < ( Math.tan(Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1]) ) &&
						(a[j][1] >= ( Math.tan(-Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1]))  ) {
					/**
					 *  it's in Region 2.
					 */
					if (f2 == false) {
						/**
						 * if it's the case that the 1st point fall in this Region.
						 */
						temp[1][0] = Dis(a, a, j);
						temp[1][1] = a[j][2];
						temp[1][2] = Dis(a, a, j);
						temp[1][3] = a[j][2];
						f2 = true;
					}
					/**
					 * the following points fall into this Region will compare with the previous value.
					 */
					else if ( ( temp[1][0] > Dis(a, a, j) ) && ( f2 == true) ) {
						temp[1][0] = Dis(a, a, j);
						temp[1][1] = a[j][2];
					}
					else if ( ( temp[1][2] < Dis(a, a, j) ) && ( f2 == true) ) {
						temp[1][2] = Dis(a, a, j);
						temp[1][3] = a[j][2];
					}
				}
				else if ( (a[j][1] <  ( Math.tan(-Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1]))  ) {
					/**
					 * 	it's in Region 3
					 */
					if (f3 == false) {
						/**
						 * if it's the case that the 1st point fall in this Region.
						 */
						temp[2][0] = Dis(a, a, j);
						temp[2][1] = a[j][2];
						temp[2][2] = Dis(a, a, j);
						temp[2][3] = a[j][2];
						f3 = true;
					}
					/**
					 * the following points fall into this Region will compare with the previous value.
					 */
					else if ( ( temp[2][0] > Dis(a, a, j) ) && ( f3 == true) ) {
						temp[2][0] = Dis(a, a, j);
						temp[2][1] = a[j][2];
					}
					else if ( ( temp[2][2] < Dis(a, a, j) ) && ( f3 == true) ) {
						temp[2][2] = Dis(a, a, j);
						temp[2][3] = a[j][2];
					}
				}
			}
			else {// ≤
				/**
				 * 	the point (which row a[j] is represented) is on LEFT hand side
				 * 		of Nucleus.
				 */
				if ( a[j][1] <= ( Math.tan(Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1] ) ) {
					/**
					 *  it's in Region 4
					 */
					if (f4 == false) {
						/**
						 * if it's the case that the 1st point fall in this Region.
						 */
						temp[3][0] = Dis(a, a, j);
						temp[3][1] = a[j][2];
						temp[3][2] = Dis(a, a, j);
						temp[3][3] = a[j][2];
						f4 = true;
					}
					/**
					 * the following points fall into this Region will compare with the previous value.
					 */
					else if ( ( temp[3][0] > Dis(a, a, j) ) && ( f4 == true) ) {
						temp[3][0] = Dis(a, a, j);
						temp[3][1] = a[j][2];
					}
					else if ( ( temp[3][2] < Dis(a, a, j) ) && ( f4 == true) ) {
						temp[3][2] = Dis(a, a, j);
						temp[3][3] = a[j][2];
					}
				}
				else if ( (a[j][1] > ( Math.tan(Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1]) ) &&
						(a[j][1] <= ( Math.tan(-Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1]))  ) {
					/**
					 *  it's in Region 5
					 */
					if (f5 == false) {
						/**
						 * if it's the case that the 1st point fall in this Region.
						 */
						temp[4][0] = Dis(a, a, j);
						temp[4][1] = a[j][2];
						temp[4][2] = Dis(a, a, j);
						temp[4][3] = a[j][2];
						f5 = true;
					}
					/**
					 * the following points fall into this Region will compare with the previous value.
					 */
					else if ( ( temp[4][0] > Dis(a, a, j) ) && ( f5 == true) ) {
						temp[4][0] = Dis(a, a, j);
						temp[4][1] = a[j][2];
					}
					else if ( ( temp[4][2] < Dis(a, a, j) ) && ( f5 == true) ) {
						temp[4][2] = Dis(a, a, j);
						temp[4][3] = a[j][2];
					}
				}
				else if ( a[j][1] > ( Math.tan(-Math.PI/6) * ( a[j][0] - a[0][0] ) + a[0][1] ) ) {
					/**
					 *  it's in Region 6
					 */
					if (f6 == false) {
						/**
						 * if it's the case that the 1st point fall in this Region.
						 */
						temp[5][0] = Dis(a, a, j);
						temp[5][1] = a[j][2];
						temp[5][2] = Dis(a, a, j);
						temp[5][3] = a[j][2];
						f6 = true;
					}
					/**
					 * the following points fall into this Region will compare with the previous value.
					 */
					else if ( ( temp[5][0] > Dis(a, a, j) ) && ( f6 == true) ) {
						temp[5][0] = Dis(a, a, j);
						temp[5][1] = a[j][2];
					}
					else if ( ( temp[5][2] < Dis(a, a, j) ) && ( f6 == true) ) {
						temp[5][2] = Dis(a, a, j);
						temp[5][3] = a[j][2];
					}
				}
			}
		}
	}
}//class