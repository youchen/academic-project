package HW_2_BackPropagation;

import java.io.BufferedReader;
import java.io.FileReader;
import java.text.DecimalFormat;
import java.util.Random;

public class Ren_YC_HW2 {
	public static void main(String[] args) {
		/**
		 *  Read file and store data into array.
		 */
		String[][] raw_Data = ReadFile_StoreDataIntoArray(args, 209, 10);
		/**
		 * Remove the first 2 and last 1 data from the original.
		 */
		double[][] data = new double[209][7];
		for (int i = 0; i < data.length; i++) {
			for (int j = 0; j < data[0].length; j++) {
				data[i][j] = Double.parseDouble( raw_Data[i][j+2] );
			}
		}
		/**
		 * Find the Max of each column.
		 */
		double[] max = new double[7];
		for (int i = 0; i < data[0].length; i++) {
			max[i] = data[0][i];
		}
		for (int i = 1; i < data.length; i++) {
			for (int j = 0; j < data[0].length; j++) {
				if( data[i][j] > max[j] ) {
					max[j] = data[i][j];
				}
			}
		}
		/**
		 * Step 1:
		 * Normalize each variable. That is, divide the values of each variable by its maximum value.
		 */
		for (int i = 0; i < data.length; i++) {
			for (int j = 0; j < data[0].length; j++) {
				data[i][j] /= max[j];
				data[i][j] = roundFourDecimals(data[i][j]);
			}
		}
		/**
		 * Step 2:
		 * Back propagation & 5-fold cross validation.
		 * 		g(x) = 1 / ( 1 + exp(-x) );
		 * 		INj = Oj = g ( SIGMA_i (INi x Wij) );
		 * 		INk = Ok = g ( SIGMA_j ( Oj x Wjk) );
		 * 	
		 */
		/**
		 * Randomly generate weight for each data point.
		 */
		double[][] weight_bottom = new double[3][6];
//		for (int i = 0; i < weight_bottom.length; i++) {
//			for (int j = 0; j < weight_bottom[0].length; j++) {
//				weight_bottom[i][j] = roundFourDecimals( randomGeneration() );
//			}
//		}
		double[] weight_top = new double[3];
//		for (int i = 0; i < weight_top.length; i++) {
//			weight_top[i] = roundFourDecimals( randomGeneration() );
//		}
		double[] hidden_Layer = new double[3];
		double output = 0.0, learning_Rate = 0.1, hidden_errorMeasure_Sum_part = 0.0, error, error_Sum = 0.0;
		int verification_index_StartAt = 0, iteration, dataStartIndexForTraining = 0;
		boolean flag = false;
		double[][] trainingSet168 = new double[168][7];
		double[][] trainingSet167 = new double[167][7];
		/**
		 * Training for Weight
		 */
		//5-fold
		/**
		 * u = 41, 83, 125, 167, 209(208) ;
		 */
		for(int u = 209 / 5; u <= 210; u = u + 42) {
			if (u == 209) u -= 1;
			System.out.println("Cross Validation break point is: " + u);
			/**
			 * Training:=======================================================================================
			 * 		every time initialize everything.
			 */
			iteration = 0;
			for (int i = 0; i < weight_bottom.length; i++) {
				for (int j = 0; j < weight_bottom[0].length; j++) {
					weight_bottom[i][j] = roundFourDecimals( randomGeneration() );
				}
			}
			for (int i = 0; i < weight_top.length; i++) {
				weight_top[i] = roundFourDecimals( randomGeneration() );
			}
			for (int i = 0; i < hidden_Layer.length; i++) {
				hidden_Layer[i] = 0.0;
			}
			/**
			 * initialize the training set data;
			 */
			for (int i = 0; i < trainingSet167.length; i++) {
				for (int j = 0; j < trainingSet167[0].length; j++) {
					trainingSet167[i][j] = 0.0;
				}
			}
			for (int i = 0; i < trainingSet168.length; i++) {
				for (int j = 0; j < trainingSet168[0].length; j++) {
					trainingSet168[i][j] = 0.0;
				}
			}
			/**
			 * Duplicate the training data points into the array "trainingSet167" depend on 
			 * 		the split point(variable u decide this split point).
			 */
			if( u == 41) {//data 42-208 (167 rows) for training;
				dataStartIndexForTraining = 42;
				for (int i = 0; i < trainingSet167.length; i++) {
					for (int j = 0; j < trainingSet167[0].length; j++) {
						trainingSet167[i][j] = data[ dataStartIndexForTraining ][j];
					}
					dataStartIndexForTraining++;
				}
			}
			else if( u == 83) {//data 84-208 && 0-41 (167 rows) for training;
				dataStartIndexForTraining = 84;
				for (int i = 0; i < trainingSet167.length; i++) {
					for (int j = 0; j < trainingSet167[0].length; j++) {
						trainingSet167[i][j] = data[ dataStartIndexForTraining ][j];
					}
					dataStartIndexForTraining++;
					if(dataStartIndexForTraining == 209) dataStartIndexForTraining = 0;
				}
			}
			else if( u == 125) {//data 126-208 && 0-83 (167 rows) for training;
				dataStartIndexForTraining = 126;
				for (int i = 0; i < trainingSet167.length; i++) {
					for (int j = 0; j < trainingSet167[0].length; j++) {
						trainingSet167[i][j] = data[ dataStartIndexForTraining ][j];
					}
					dataStartIndexForTraining++;
					if(dataStartIndexForTraining == 209) dataStartIndexForTraining = 0;
				}
			}
			else if( u == 167) {//data 168-208 && 0-125 (167 rows) for training;
				dataStartIndexForTraining = 168;
				for (int i = 0; i < trainingSet167.length; i++) {
					for (int j = 0; j < trainingSet167[0].length; j++) {
						trainingSet167[i][j] = data[ dataStartIndexForTraining ][j];
					}
					dataStartIndexForTraining++;
					if(dataStartIndexForTraining == 209) dataStartIndexForTraining = 0;
				}
			}
			else if( u == 208) {//data 0-167 (168 rows) for training;
				dataStartIndexForTraining = 0;
				for (int i = 0; i < trainingSet168.length; i++) {
					for (int j = 0; j < trainingSet168[0].length; j++) {
						trainingSet168[i][j] = data[ dataStartIndexForTraining ][j];
					}
					dataStartIndexForTraining++;
					if(dataStartIndexForTraining == 209) dataStartIndexForTraining = 0;
				}
			}
			for (int k = 0; k < trainingSet167.length; k++) {
				output = 0.0;
				/**
				 * update weight after each round in the entire training data set (4/5 of data set).
				 */
				/**FORWARD-PROPAGATION==================================
				 * a. Compute for Hidden Layer.
				 */
				for (int i = 0; i < hidden_Layer.length; i++) {
					for (int j = 0; j < 6; j++) {
						hidden_Layer[i] += ( trainingSet167[k][j] * weight_bottom[i][j] );
					}
					hidden_Layer[i] = Sigmoid( hidden_Layer[i] );
				}
				/**
				 * b. Compute for Output Layer.
				 */
				for (int i = 0; i < hidden_Layer.length; i++) {
					output += ( hidden_Layer[i] * weight_top[i] );
				}
				output = Sigmoid( output );
				/**BACK-PROPAGATION======================================
				 * c. update the weight.
				 */
				//Assume that the learning rate is 0.1;
				learning_Rate = 0.1;
				//update top weight;
				for (int i = 0; i < weight_top.length; i++) {
					weight_top[i] += ( learning_Rate * output * ( 1 - output ) * ( trainingSet167[k][6] - output ) * hidden_Layer[i] );
				}
				//update bottom weight;
				/**
				 * compute for ∑ δ(k) * W(jk);
				 */
				for (int i = 0; i < hidden_Layer.length; i++) {
					hidden_errorMeasure_Sum_part += ( output * ( 1 - output ) * ( trainingSet167[k][6] - output ) * weight_top[i] );
				}
				for (int i = 0; i < hidden_Layer.length; i++) {
					for (int j = 0; j < 6; j++) {
						weight_bottom[i][j] += ( learning_Rate * hidden_Layer[i] * ( 1 - hidden_Layer[i] ) * 
								hidden_errorMeasure_Sum_part * trainingSet167[k][j]);
					}
				}
				/**
				 * Verification.===================================================================================================
				 * If the total error is within the threshold value, stop training the neural network.
				 */
				error_Sum = 0.0;
				output = 0.0;
				for (int i = 0; i < hidden_Layer.length; i++) {
					hidden_Layer[i] = 0.0;
				}
				/**
				 * u = 41, 83, 125, 167, 209(208) ;
				 */
				if( u == 41) verification_index_StartAt = 0;
				if( u == 83) verification_index_StartAt = 42;
				if( u == 125) verification_index_StartAt = 84;
				if( u == 167) verification_index_StartAt = 126;
				if( u == 208) verification_index_StartAt = 168;
				/**
				 * verificatoin_index_StartAt = 0, 42, 84, 126, 167(168);
				 */
				for (int ii = verification_index_StartAt; ii <= verification_index_StartAt + 41; ii++) {
					if( ii == 209 ) break;
					/**
					 * ii = 0, 42, 84, 126, 167(168);
					 */
					/**FORWARD-PROPAGATION==================================
					 * a. Compute for Hidden Layer.
					 */
					for (int i = 0; i < 3; i++) {
						for (int j = 0; j < data[0].length - 1; j++) {
							hidden_Layer[i] += ( data[ii][j] * weight_bottom[i][j] );
						}
						hidden_Layer[i] = Sigmoid( hidden_Layer[i] );
					}
					/**
					 * b. Compute for Output Layer.
					 */
					//double output = 0.0;
					for (int i = 0; i < hidden_Layer.length; i++) {
						output += ( hidden_Layer[i] * weight_top[i] );
					}
					output = Sigmoid( output );
					error = 0.5 * Math.pow( (data[ii][6] - output), 2);
					error_Sum += error;
					error = 0.0;
				}//for verification
				iteration++;
				/**
				 * stop training the neural network if the total output error is below some threshold value.
				 */
				if( error_Sum / 42 <= 0.1) {
					flag = true;
					k = u + 200;
				}
				if( flag == false && k == trainingSet167.length - 1) k = 0;
			}//for k = 0; k < trainingSet167.length
			if(flag == true) {
				System.out.println("iteration time is: " + iteration);
				System.out.println("The average total output error is: " + error_Sum/42 + "\n");
				flag = false;
				/**
				 * delete and re-initialize the weight value and hidden layer value for new training;
				 */
				for (int i = 0; i < weight_bottom.length; i++) {
					for (int j = 0; j < weight_bottom[0].length; j++) {
						weight_bottom[i][j] = roundFourDecimals( randomGeneration() );
					}
				}
				for (int i = 0; i < weight_top.length; i++) {
					weight_top[i] = roundFourDecimals( randomGeneration() );
				}
				for (int i = 0; i < hidden_Layer.length; i++) {
					hidden_Layer[i] = 0.0;
				}
			}//if(flag == true)
		}//for u
	}//main
	@SuppressWarnings("resource")
	public static String [][] ReadFile_StoreDataIntoArray(String[] args, int row, int col) {
		if(args.length == 0) {
			System.out.println("No file specified");
			return null;
		}
		else {
			FileReader theFile;
			BufferedReader inFile;		
			String oneLine;
			String [][] data = new String [row][col];
			try {
				theFile = new FileReader(args[0]);
				inFile = new BufferedReader(theFile);
				oneLine = inFile.readLine();
				int i = 0;
				while( !(oneLine.isEmpty()) ) {
					String numbers[] = oneLine.split(",");
					for(int j = 0; j < numbers.length; j++) {
						data[i][j] = numbers[j];
						//						data[j][1] = numbers[1];
					}
					oneLine = inFile.readLine();
					i++;
				}
			} catch (Exception e) {
				// TODO: handle exception
			}//catch
			return data;
		}//else
	}//ReadFile
	public static double roundFourDecimals(double d) {
		DecimalFormat twoDForm = new DecimalFormat("#.####");
		return Double.valueOf(twoDForm.format(d));
	}
	public static double randomGeneration() {
		Random x = new Random();
		return x.nextDouble();
	}
	public static double Sigmoid(double a) {
		return 1 / ( 1 + Math.exp(-a) );
	}
}//class