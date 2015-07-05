package url_process;

import java.net.*;
import java.io.*;

import driver.Driver;
import twitr.twt_search;
/**
 * Type 2 is:
 * 
 * 		URL is html/htm/txt
 * 			read all lines, save as file with file Name <ExampleFileName>;
 * 			output
 * 				# of lines read
 * 				file Name <ExampleFileName>
 * 
 * 		URL is jpg/jpeg/gif
 * 			save image as file with file Name <ExampleImageFileName>;
 * 			output
 * 				file Name <ExampleImageFileName>
 * 
 * @author Youchen
 * 
 */
public class html_image_saving {
	public static void saveHtmlorPics(String queryStr) throws Exception {

		@SuppressWarnings("unused")
		int Saved_file_Series_No = 1;
		try {
			String replaceQuerySpace = queryStr.replace(" ", "%20");
			String line = "https://twitter.com/search?q=" + replaceQuerySpace + "&src=typd";

			System.out.println(".........Downloading file from URL:\n\t" + line + "\n");

			//save the file locally
			String URLtypeIdentifier = line.substring(line.length() - 5);
			String dotFileType = ".html";
			//make dotFileType as .html/.txt/.jpg...
			if(URLtypeIdentifier.indexOf('.') != -1) {
				dotFileType = URLtypeIdentifier.substring(URLtypeIdentifier.indexOf('.'));
			}

			String fileName = "";
			/**
			 * if the URL is image-type
			 * 		save the file
			 *		output name of the file
			 */
			if(URLtypeIdentifier.indexOf('.') != -1 && 
					(URLtypeIdentifier.contains(".jpg") || 
							URLtypeIdentifier.contains(".jpeg") ||
							URLtypeIdentifier.contains(".gif")
							)) {
				//save the file
				//output name of the file
				String imageFileName = "Image_#" + dotFileType;
				saveImage(line, imageFileName);
			}
			/**
			 * if the URL is non-image-type
			 * 		read all lines, save as file with file Name <ExampleFileName>;
			 * 		output
			 * 				# of lines read
			 * 				file Name <ExampleFileName>
			 */
			else {
				fileName = Driver.getCurrentDirectroy() + "/Html/" + "html" + "_query words - " + queryStr +  dotFileType;
				BufferedWriter writer = new BufferedWriter(new FileWriter(fileName));



				URL urlTemp = new URL(line);
				BufferedReader in = new BufferedReader(new InputStreamReader(urlTemp.openStream()));

				String inputLine;
				@SuppressWarnings("unused")
				int NumLinesRead = 0;
				while ((inputLine = in.readLine()) != null){
					try{
						writer.write(inputLine);
						NumLinesRead++;
					}
					catch(IOException e){
						e.printStackTrace();
						writer.close();
						return;
					}
				}//while
					writer.close();
			}//else

			/**
			 * Open the html file with the default web browser.
			 */
			twt_search.openFile(fileName);

			Saved_file_Series_No++;
		}//try
		finally{}

	}//main

	public static void saveImage(String imageUrl, String destinationFile) throws IOException {
		URL url = new URL(imageUrl);
		InputStream is = url.openStream();
		OutputStream os = new FileOutputStream(destinationFile);

		byte[] b = new byte[2048];
		int length;

		while ((length = is.read(b)) != -1) {
			os.write(b, 0, length);
		}

		is.close();
		os.close();
	}
}
