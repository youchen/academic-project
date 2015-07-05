package driver;

import java.io.*;
import java.util.*;
import java.sql.*;

import db_backup_excel.poi_excel;

public class Driver {
	// JDBC driver name and database URL
	static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";  
	public static String DB_URL = "jdbc:mysql://localhost:3306/";

	//  Database credentials
	static String USER;
	static String PASS;

	static Scanner DataSetScanr = null;
	static File input, output;

	static String tableName;
	static String databaseName;
	static String tableAttributes;

	//	public static boolean illegalArguments = false;

	public static Statement stmt = null;
	public static String sql = null;
	public static Connection conn = null;

	public static Scanner s2 = null;
	/**
	 * Command line arguments:
	 * 					args[0]: data set file.(.txt)
	 * 		args[0]: log file. (.txt)
	 * 		args[1]: database user name. (String)
	 * 		args[2]: database password. (String)
	 * @param args
	 * @throws Throwable 
	 */
	public static void ini_DB(String[] args, String db_Name) throws Throwable {

		USER = args[0];
		PASS = args[1];

		/**
		 * Excel
		 */
		poi_excel.iniTest();



		try{
			//STEP 2: Register JDBC driver
			Class.forName("com.mysql.jdbc.Driver");

			//STEP 3: Open a connection
			//			Logger.recording("Connecting to database...");
			conn = DriverManager.getConnection(DB_URL,USER,PASS);

			//STEP 4: Execute a query
			//			Logger.recording("Creating statement...");
			stmt = conn.createStatement();

			//read the 1st line for database name;
			databaseName = db_Name;//DataSetScanr.nextLine();

			//to aviod collision, drop the database which has the same name.
			clearDB();

			sql = "create database " + databaseName;
			stmt.executeUpdate(sql);
			//			Logger.recording(sql);

			sql = "use " + databaseName;
			stmt.executeQuery(sql);
			//			Logger.recording(sql);

		}catch(SQLException se){
			//Handle errors for JDBC
			se.printStackTrace();
		}catch(Exception e){
			//Handle errors for Class.forName
			e.printStackTrace();
		}

	}//end main

	public static void ini_DB_for_reConstruction(String[] args, String db_Name) throws Throwable {


		//		Logger.setLogFileName(args[0]);
		USER = args[0];
		PASS = args[1];

		//		System.out.println("--" + DB_URL);


		try{
			//STEP 2: Register JDBC driver
			Class.forName("com.mysql.jdbc.Driver");

			//STEP 3: Open a connection
			//		Logger.recording("Connecting to database...");
			conn = DriverManager.getConnection(DB_URL,USER,PASS);

			//STEP 4: Execute a query
			//		Logger.recording("Creating statement...");
			stmt = conn.createStatement();

			//read the 1st line for database name;
			databaseName = db_Name;//DataSetScanr.nextLine();

			//to aviod collision, drop the database which has the same name.
			clearDB();

			sql = "create database " + databaseName;
			stmt.executeUpdate(sql);
			//		Logger.recording(sql);

			sql = "use " + databaseName;
			stmt.executeQuery(sql);
			//		Logger.recording(sql);

		}catch(SQLException se){
			//Handle errors for JDBC
			se.printStackTrace();
		}catch(Exception e){
			//Handle errors for Class.forName
			e.printStackTrace();
		}

	}//end main



	/**
	 * This method is intended to initilize the file system.
	 * 		Including the makin the folder that going to store the image and html file.
	 */
	public static void ini_FileSystem() {
		Driver.mkdirInCurDirectory("Images");
		Driver.mkdirInCurDirectory("Html");
	}
	/**
	 * ***************** Deprecated ***********************
	 * @param stmt
	 * @param tableName
	 * @throws SQLException
	 */
	public static void showTable(Statement stmt, String tableName) throws SQLException {

		String sql;


		System.out.println("\n================================== show table "+ tableName + " start ===================================");

		sql = "SELECT * FROM " + tableName;
		ResultSet rs = stmt.executeQuery(sql);

		System.out.println("Inv_ID \t Sup_ID \t Pro_Name \t\t\t Price \t "
				+ "CostPrice \t Quantity \t Threshold \t LastTimeOrdered");
		while(rs.next()){
			//Retrieve by column name
			int Inv_id  = rs.getInt("Inv_id");
			int Sup_ID = rs.getInt("Sup_ID");
			String Pro_Name = rs.getString("Pro_Name");
			float Price = rs.getFloat("Price");
			float CostPrice = rs.getFloat("CostPrice");
			int Quantity = rs.getInt("Quantity");
			int Threshold = rs.getInt("Threshold");
			String LastTimeOrdered = rs.getString("LastTimeOrdered");

			//Display values
			System.out.println(Inv_id + " \t " + Sup_ID + " \t\t " + Pro_Name + "   \t\t " 
					+ Price + " \t " + CostPrice + " \t\t " + Quantity + " \t\t " + Threshold + " \t\t "
					+ LastTimeOrdered + " \t ");

		}
	}

	public static void clearDB() throws SQLException {
		/**
		 * Safty Drop with the command:
		 * 		DROP DATABASE IF EXISTS <db name>;
		 */
		sql = "DROP DATABASE IF EXISTS " + databaseName;
		stmt.executeUpdate(sql);
	}

	public static String getCurrentDirectroy() {
		return System.getProperty("user.dir");
	}
	public static void mkdirInCurDirectory(String DirName) {
		String Path = System.getProperty("user.dir") + "/" + DirName;
		File theDir = new File(Path);
		try {
			theDir.mkdir();
		}catch(SecurityException se){}
	}
}
