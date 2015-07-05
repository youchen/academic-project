package p2_Submit;
/**
 * Project 2 - Plot the Binary Search Tree.
 * @author Youchen Ren
 */
import java.io.*;
public class Project2 {
	public static void main(String[] args) {
		if(args.length == 0)System.out.println("No file specified.");
		else{
			FileReader theFile;
			BufferedReader inFile;
			String oneLine;
			try{//FileNotFoundException must be caught
				theFile = new FileReader(args[0]);
				inFile = new BufferedReader(theFile);
				/**
				 * now read the text file line by line.
				 */
				while ((oneLine = inFile.readLine()) != null){
					String numbers[] = oneLine.split(" ");
					BinaryTree temp1 = new BinaryTree();	
					char [][] arr = new char [9][40];
					/**
					 * Assign every element of char Array to WhiteSpace.
					 */
					for(int i = 0; i <= 8; i++) {
						for(int j = 0; j <= 39; j++) {
							arr[i][j] = ' ';
						}
					}
					/**
					 * insert all the numbers in the line to the BinaryTree.
					 */
					for(int i = 0; i < numbers.length; i++) {
						temp1 = BinaryTree.insert(temp1, Integer.parseInt(numbers[i]));
					}
					/**
					 * A BST is established. Plot the tree into char Array.
					 */
					plotToCharArr(temp1, arr, 0, 20, 0);
					//Print out the Char Array			
					for(int i = 0; i <= 8; i++) {
						for(int j = 0; j <= 39; j++) {
							System.out.print(Character.toString(arr[i][j]));
						}
						System.out.println();
					}
					//read another line.
					inFile.readLine();
				}//while
			}//try
			catch (Exception e){System.out.println(e);}
		}//else
	}//main
	public static void plotToCharArr(BinaryTree t, char[][] arr, int rowStart, int colStart, int reduceOffSet) {
		int spaceOffSet = 17;

		if(!(t.isEmpty())) {
			/**
			 * Store the integer into char array;
			 * 	access to the 1st digit by dividing 10;
			 * 	access to the 2nd digit by modulus 10 since char only can store 1 digit.
			 */
			arr[rowStart][colStart] = (char)('0' + t.getRootObj()/10);
			arr[rowStart][colStart + 1] =  (char)('0' + t.getRootObj()%10);
			/**
			 * The line below is to designing the tree "branches" ("\" & "/");
			 */
			//each time of recursion, the offSet is decreasing by 1/2.
			reduceOffSet = reduceOffSet + 2;
			int nextLineOffSet = spaceOffSet/reduceOffSet;
			/**
			 * Therefore, if the root has the left (or right) child, draw "/"(or "\")
			 * 		on next line at the proper location;
			 */
			if(!(t.getLeft().isEmpty())) arr[rowStart+1][colStart - nextLineOffSet/2] = '/';
			if(!(t.getRight().isEmpty())) arr[rowStart+1][colStart + nextLineOffSet/2] = '\\';
			/**
			 * Plot the rest of the Binary nodes into char array recursively.
			 */
			plotToCharArr(t.getLeft(), arr, rowStart+2, colStart - nextLineOffSet, reduceOffSet);
			plotToCharArr(t.getRight(), arr, rowStart+2, colStart + nextLineOffSet, reduceOffSet);
		}
	}//plotToCharArr
}//Class
