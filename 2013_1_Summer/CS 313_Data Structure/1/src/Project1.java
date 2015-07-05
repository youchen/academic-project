
/**
 * CS313 Summer 2013
 * Project 1
 * 
 * @author Youchen Ren
 */
import java.util.StringTokenizer;

public class Project1 {
	public static TextFileInput myFile;
	public static StringTokenizer myTokens;
	public static StringTokenizer myTokens2;
	public static String line;

	public static void main(String[] args) {
		myFile = new TextFileInput("DataFile.txt");
		line = myFile.readLine();
		boolean flagWhile = true;
		String myTokens_Str;
		Polynomial resultSum;
		Polynomial resultProduct;
//while Loop for capture each pair of data and
//compute the sum and product**********************************************************		
		while(flagWhile) {//Consider the \n situation.

			Polynomial temp1 = new Polynomial();
			Polynomial temp2 = new Polynomial();

			temp1.getFront().setNext(null);
			temp2.getFront().setNext(null);
			temp1.getFront().setElement(0);
			temp2.getFront().setElement(0);

			myTokens = new StringTokenizer(line, " ");
			myTokens_Str = myTokens.nextToken();//myTokens_Str = "1";

			boolean flag = true;
			while(flag) {
				temp1.append(Integer.parseInt(myTokens_Str));
				if(!(myTokens.hasMoreTokens())) flag = false;
				else myTokens_Str = myTokens.nextToken();
			}//while

			line = myFile.readLine();

			myTokens2 = new StringTokenizer(line, " ");
			String myTokens_Str2 = myTokens2.nextToken();

			boolean flag2 = true;

			while(flag2) {
				temp2.append(Integer.parseInt(myTokens_Str2));
				if(!(myTokens2.hasMoreTokens())) flag2 = false;

				else myTokens_Str2 = myTokens2.nextToken();
			}
			resultSum = new Polynomial();
			resultSum = Polynomial.sum(temp1, temp2);
//Test for output*************************************************************
			System.out.print("Sum is: ");
			Polynomial.print(resultSum);
			System.out.println();
			resultProduct = new Polynomial();
			resultProduct = Polynomial.product(temp1, temp2);

			System.out.print("Product is: ");			
			Polynomial.print(resultProduct);
			System.out.println("\n\n");			

			line = myFile.readLine();
			if (line == null){
				System.out.println("*******All lines are Done in the Text File!*******");
				flagWhile = false;
			}
			else if(line.isEmpty()) {
				line = myFile.readLine();
			}
		}//while
	}//main
}//class Project1