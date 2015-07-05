package p3_submit;
/**
 * Project 3 - Maze
 * @author Youchen Ren
 */
import java.io.*;
public class Project3 {
	public static int [][] maze = new int[10][10];
	public static int [][] temp = new int [10][10];
	public static boolean found = false;
	public static int nr; //new row
	public static int nc; //new column
	public static int count = 0;

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
					for(int i = 0; i <= 9; i++) {
						for(int j = 0; j <= 9; j++) {
							maze[i][j] = Integer.parseInt(numbers[j]);
							temp[i][j] = Integer.parseInt(numbers[j]);
						}
						if (i <= 8) {
							oneLine = inFile.readLine();
							numbers = oneLine.split(" ");
						}
					}//for
					Findway(0, 0, 9, 9);
					if (found == true) {
						for(int i = 0; i <= 9; i++) {
							for(int j = 0; j <= 9; j++) {
								System.out.print(maze[i][j]+" ");
							}
							System.out.println();
						}
					}//if
					else {
						System.out.println("\nSorry! No path was founded for this Maze.");
					}
					inFile.readLine();//This line is Empty new line
					System.out.println("\n\n\n\n\n\n");
					found = false;
					count = 0;
				}//while
			}//try
			catch (Exception e){System.out.println(e);}
		}//else
	}//main

	public static void Findway(int sr, int sc, int dr, int dc){//s: start, d: destination
		if(sr == dr && sc == dc) found = true;
		else{
			temp[sr][sc] = 1;//mark the position
			while(!found && PossibleToMove(sr, sc)) {
				count = 0;
				Findway(nr, nc, dr, dc);
				if(!found) {
					System.out.println("Backtracking from [" + nr + ", " + nc +"] to ["
							+ sr + ", " + sc + "]");
					nr = sr; nc = sc;
				}
			}//while
			if(!PossibleToMove(sr, sc) && count == 0) {
				System.out.println("\nStart backtracking from [" + sr +", " + sc +"]");
				count++;
			}
		}
		if(found) maze[sr][sc] = 2; //mark the path
	}//Findway
	/**	
	 * 		 |?|
	 *	sr |?|x|?|
	 *		 |?|
	 *		 sc
	 *PossibleToMove -> Returns false if there is no place to go from(sr, sc);
	 *		otherwise, returns true and stes(nr, nc) to a new position.
	 *				
	 * The order of Directions of searching for obstacles is
	 * 		East -> South -> West -> North
	 * 
	 * @param sr start row for testing if it's possible to move to either four directions.
	 * @param sc start column for testing if it's possible to move to either four directions.
	 * @return if possible to move, return true, else false.
	 */
	public static boolean PossibleToMove(int sr, int sc) {
		if(sc+1 <= 9 && temp[sr][sc+1] == 0) {nr = sr; nc = sc+1; return true;}
		else if	(sr+1 <= 9 && temp[sr+1][sc] == 0) {nr = sr+1; nc = sc; return true;}
		else if	(sc-1 >= 0 && temp[sr][sc-1] == 0) {nr = sr; nc = sc-1; return true;}
		else if	(sr-1 >= 0 && temp[sr-1][sc] == 0) {nr = sr-1; nc = sc; return true;}
		else return false;
	}
}//Class
