package twitr;

import twitter4j.*;
import twitter4j.conf.ConfigurationBuilder;

import java.awt.Desktop;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URL;
import java.util.*;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import db_backup_excel.poi_excel;
import driver.Driver;
import url_process.html_image_saving;
import gui.Gui_dialogue;

public class twt_search {
	public static String[] argsCopy = null;
	public static XSSFWorkbook wb;
	public static int queryCount = 30;

	public static void main(String[] args) throws Throwable {
		//ini DB
		/**
		 * 		args[0]: database user name. (String)
		 * 		args[1]: database password. (String)
		 * 
		 * 		args[2] and beyond are the query strings.
		 */
		argsCopy = args;

		//button "Configure"
		Driver.ini_FileSystem();
		Driver.ini_DB(args, "TwitterSearch");
		poi_excel.firstTimeConfig();

		//button "Search"
		for (int i = 2; i < args.length; i++) {
			System.out.println("\n\n\n\n======================================Search for query: " + args[i] + "======================================\n\n\n\n");
			Twit_search(args[i]);
		}

		/**
		 * Read the excel file
		 * 		and re-construct the DB.
		 */
		//button "Re-Construction"
		//		reconstruction();

		//button "Offline Search"
		//		poi_excel.find("RT");
	}
	public static void Twit_search(String queryStr) throws Exception {
		/**
		 * Twitter Credentials.
		 */
		ConfigurationBuilder cb = new ConfigurationBuilder();
		cb.setDebugEnabled(true)
		.setOAuthConsumerKey("")//you may claim the 4 free credentials below at https://apps.twitter.com
		.setOAuthConsumerSecret("")
		.setOAuthAccessToken("")
		.setOAuthAccessTokenSecret("");
		TwitterFactory tf = new TwitterFactory(cb.build());
		Twitter twitter = tf.getInstance();
		try {
			Query query = new Query(queryStr);

			query.setCount(queryCount);
			QueryResult result;
			result = twitter.search(query);
			List<Status> tweets = result.getTweets();
			/**
			 * Save html file
			 */
			 html_image_saving.saveHtmlorPics(queryStr);
			 /**
			  * Create new Sheet in Excel
			  */
			 String dirPath = System.getProperty("user.dir") + "/Excel_Backup";
			 FileInputStream file = new FileInputStream(new File(dirPath + "/Backup.xlsx"));
			 @SuppressWarnings("resource")
			 XSSFWorkbook wb = new XSSFWorkbook(file);

			 Sheet sh =  wb.createSheet(queryStr);
			 sh.createFreezePane(1,1);
			 String[] rowFill = {"Username", "Fullname", "Date_time", "Tweet", "Image_1", "Image_2", "Image_3", "Image_4"};
			 Row rowAttribution = sh.createRow(0);
			 for(int i = 0; i < rowFill.length; i++) {
				 Cell cell = rowAttribution.createCell(i);
				 cell.setCellValue(rowFill[i]);
			 }
			 /**
			  * Database Creation
			  */
			 String tableName = queryStr.replaceAll(" ", "_").toLowerCase();
			 String tableAttributes = 
					 "Username VARCHAR(20) NOT NULL, Fullname VARCHAR(15) NOT NULL, "
							 + "Date_time CHAR(28) NOT NULL, Tweet VARCHAR(250) NOT NULL, "
							 + "Image_1 CHAR(250), Image_2 CHAR(250), Image_3 CHAR(250), Image_4 CHAR(250)";
			 Driver.sql = "create table " + tableName + "(" + tableAttributes + ")";
			 Driver.stmt.executeUpdate(Driver.sql);

			 int createRowCount = 1;
			 for (Status tweet : tweets) {
				 String Username = tweet.getUser().getName();
				 String Fullname = tweet.getUser().getScreenName();
				 Date Date_time = tweet.getCreatedAt();
				 String Tweet = tweet.getText();

				 /**
				  * put them into an array.
				  */
				  String[] nonPicVal = new String[4];
				  nonPicVal[0] = Username;
				  nonPicVal[1] = Fullname;
				  nonPicVal[2] = Date_time.toString();
				  nonPicVal[3] = Tweet;

				  MediaEntity[] media = tweet.getMediaEntities(); //get the media entities from the status
				  String[] mediaURL = new String[media.length];
				  for(int i = 0; i < media.length; i++) {
					  mediaURL[i] = media[i].getMediaURL();
				  }


				  /**
				   * Database update
				   */
				  String integretedValue = "";
				  for (int i = 0; i <= 3; i++) {
					  integretedValue += "\'" + nonPicVal[i].replace("'", "''") + "\'";
					  integretedValue += ",";
				  }
				  /**
				   * Add picNameCode
				   */
				  if(media.length != 0) {//have pics in it!
					  String URLline = media[0].getMediaURL();
					  String URLtypeIdentifier = URLline.substring(URLline.length() - 5);
					  String dotFileType = URLtypeIdentifier.substring(URLtypeIdentifier.indexOf('.'));
					  String picCode = media[0].getMediaURL().substring(27,42);
					  String imageFileName = "Image_" + picCode + dotFileType;
					  String picPath = Driver.getCurrentDirectroy() + "/" + "Images/" + imageFileName;
					  integretedValue += "\'" + picPath + "\'";
				  }else {
					  integretedValue += "NULL";
				  }
				  Driver.sql = "INSERT INTO " + tableName + " (Username, Fullname, Date_time, Tweet, Image_1)" +
						  " VALUES (" + integretedValue + ");";
				  Driver.stmt.executeUpdate(Driver.sql);

				  Row row = sh.createRow(createRowCount++);
				  for(int i = 0; i <= 3; i++) {
					  Cell cell = row.createCell(i);
					  cell.setCellValue(nonPicVal[i]);
					  sh.autoSizeColumn(i);
				  }
				  /**
				   */
				  if(media.length != 0) {//have pics in it!
					  //integretedValue = 'XIENCmfiweOIJndv-djv'
					  integretedValue += "\'" + media[0].getMediaURL().substring(27,42) + "\'";

					  Cell cell = row.createCell(4);
					  String picCode = media[0].getMediaURL().substring(27,42);

					  String URLline = media[0].getMediaURL();
					  String URLtypeIdentifier = URLline.substring(URLline.length() - 5);
					  String dotFileType = URLtypeIdentifier.substring(URLtypeIdentifier.indexOf('.'));
					  String imageFileName = "Image_" + picCode + dotFileType;

					  cell.setCellValue(Driver.getCurrentDirectroy() + "/" + "Images/" + imageFileName);
					  sh.autoSizeColumn(4);
				  }else {//no images in this tweet.
					  Cell cell = row.createCell(4);
					  cell.setCellValue("NULL");
				  }

				  for(MediaEntity m : media){ //search trough your entities
					  /**
					   * Skip the embedded video
					   */
					  if(m.getMediaURL().length() > 46)
						  continue;

					  System.out.println("\n**Image URL: " + m.getMediaURL()); //get your url!
					  /**
					   * Save photo or GIF
					   */
					  if(m.getType().equals("photo") || m.getType().equals("animated_gif") ) {
						  savePic(m.getMediaURL());
					  }

				  }

				  /**
				   * Write data to the workbook.
				   */
				  FileOutputStream outFile = new FileOutputStream(new File(dirPath + "/Backup.xlsx"));
				  wb.write(outFile);
				  outFile.close();

				  System.out.println("-------------------------------------- new Tweet ------------------------------------------------------");
				  System.out.println(Username + " @ " + Fullname + " -- " + Date_time.toString() + "\n\n"
						  + "\t" + Tweet + "\n\n");

			 }
		} catch (TwitterException te) {
			te.printStackTrace();
			System.out.println("Failed to search tweets: " + te.getMessage());
			System.exit(-1);
		}
	}
	private static void savePic(String URLline) throws IOException {

		//save the file locally
		String URLtypeIdentifier = URLline.substring(URLline.length() - 5);

		String dotFileType = URLtypeIdentifier.substring(URLtypeIdentifier.indexOf('.'));
		String picNameCode = URLline.substring(27, 42);

		/**
		 * if the URL is image-type
		 * 		save the file
		 *		output name of the file
		 */
		if( (URLtypeIdentifier.contains(".jpg") || 
				URLtypeIdentifier.contains(".jpeg") ||
				URLtypeIdentifier.contains(".gif") ||
				URLtypeIdentifier.contains(".png")
				)) {
			//save the file
			//output name of the file
			String imageFileName = "Image_" + picNameCode + dotFileType;
			saveImage(URLline, imageFileName);

			/**
			 * Update the database
			 */

		}
	}
	public static void saveImage(String imageUrl, String destinationFile) throws IOException {

		URL url = new URL(imageUrl);
		InputStream is = url.openStream();
		OutputStream os = new FileOutputStream(new File(Driver.getCurrentDirectroy() + "/Images/" + destinationFile));

		byte[] b = new byte[2048];
		int length;

		while ((length = is.read(b)) != -1) {
			os.write(b, 0, length);
		}

		is.close();
		os.close();
	}

	public static void reconstruction() throws Throwable {

		Driver.ini_DB_for_reConstruction(Gui_dialogue.gui_DBInput, "TwitterSearch");

		/**
		 * Grab the .xlsx file.
		 */
		File myFile = new File(Driver.getCurrentDirectroy() + "/Excel_Backup/Backup.xlsx");
		FileInputStream fis = new FileInputStream(myFile);

		// Finds the workbook instance for XLSX file
		@SuppressWarnings("resource")
		XSSFWorkbook wb = new XSSFWorkbook (fis);

		Iterator<XSSFSheet> sheetIterator = wb.iterator();

		int sheetIndex = 0;
		while(sheetIterator.hasNext()) {
			XSSFSheet sheet = sheetIterator.next();

			/**
			 * Create table based on the name of the sheet.
			 */
			//not sure if the following replaceAll is correct or not.
			String sheetName = wb.getSheetName(sheetIndex++).replaceAll(" ", "_");
			String tableAttributes = 
					"Username VARCHAR(20) NOT NULL, Fullname VARCHAR(15) NOT NULL, "
							+ "Date_time CHAR(28) NOT NULL, Tweet VARCHAR(250) NOT NULL, "
							+ "Image_1 CHAR(250), Image_2 CHAR(250), Image_3 CHAR(250), Image_4 CHAR(250)";
			Driver.sql = "create table " + sheetName + "(" + tableAttributes + ")";
			Driver.stmt.executeUpdate(Driver.sql);

			String[] attributes = {"Username", "Fullname", "Date_time", "Tweet", "Image_1"};

			Iterator<Row> rowIterator = sheet.iterator();
			//omit the first row.
			Row row = rowIterator.next();

			while (rowIterator.hasNext()) {
				row = rowIterator.next();

				// For each row, iterate through each columns
				Iterator<Cell> cellIterator = row.cellIterator();

				int cellIndex = 0;

				while (cellIterator.hasNext()) {
					int i = 4;
					String cellValue = "";
					while(i >= 0) {
						Cell cell = cellIterator.next();
						cellValue += "\', \'" + cell.getStringCellValue().replaceAll("'", "-").replaceAll("\n", "");

						i--;
					}
					/**
					 * INSERT INTO Customers (CustomerName, City, Country)
							VALUES ('Cardinal', 'Stavanger', 'Norway');
					 */
					cellValue = cellValue.substring(4);
					Driver.sql = "INSERT INTO " + sheetName + " ("+ attributes[cellIndex++] + ", " + 
							attributes[cellIndex++] + ", " + attributes[cellIndex++] + ", " 
							+ attributes[cellIndex++] + ", " + attributes[cellIndex++] +")" 
							+ " VALUES (\'" + cellValue + "\');";
					Driver.stmt.executeUpdate(Driver.sql);
				}//while (cellIterator.hasNext())
			}//while (rowIterator.hasNext())
		}//while(sheetIterator.hasNext())
	}//reconstruction

	public static void openFile(String path) throws IOException {
		//text file, should be opening in default text editor
		File file = new File(path);
		Desktop desktop = Desktop.getDesktop();
		if(file.exists())
			desktop.open(file);
	}
}
