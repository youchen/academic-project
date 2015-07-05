1. Overview
	This project is supported by using API from:
	Apache POI
		https://poi.apache.org
	Twitter4j
		http://twitter4j.org/en/index.html

	This program is to get the tweets from the search response on https://twitter.com and
		 parse the response stream by using Twitter4j API, store the data to 2 place:
		- Local database server(the database "online") and
		- the Excel file on hard disk (for the purpose of database backup);

	Furthermore, all the images will be saved locally, and the response html will be saved as
		the form of "html_query words - <key word>" locally as well.






2. Compile the program:
	No need to compile.
	Runnable jar file - "Runnable jar file" has been created since so many API involved.









3. Run:
	1> With legal Arguments:

			0> $ java -jar TwitterSearch.jar
				(OR Simply double-click the jar file)



			Supppose your Database Credentials are as follwing:

				Username: root
				Password: 12345

			1> First, please enter your credentials in the input box after "Username" and "Password" on the GUI.
				If the JDBC connection is different than the default one. Please input yours.
				Then click "Configurate".

			2> You may enter whatever you want to search on Twitter in "Keyword" input box.
				The Default "Respond Count" is 30 tweets. if you want more or less, you may input yours, Integers please.
				Then click "Search".

			3> You may clear your database test-Server to test if my program could recover the Database.
				Click "Re-construction Database".
				You may check in the database if it's recovered.

			4> For testing the offline Search, Turn off the database connection first.
				Enter whatever you want to search in the database.
				then hit "Offline Search".

			All the results or actions made will be reflected in the big text area which located in the bottom of the GUI.


4. Local File:
			You may find in the directory of the java source code(../src);
			Image folder(../Images);
			Html folder(../Html).

			and the Excel file stored all the people tweets.
			The local database server save the same thing as Excel.







5. Testing:
		Input the database localhost credentials:
				the console output is in file Sample Running Result_Database.txt

		By using the top 3 most searched movie names on Google in May 2015, I created
				3 test case as following:

				Avengers Age of Ultron (default 30 responses)
				Pitch Perfect 2		   (customized 43 responses)
				Mad Max				   (customized 16 responses)


		Then I searched offline key word "Cover".
		The program return the exact position of the occurrence of the keyword in database Backup (Excel file).








		Sample Runing Result: (in JTextArea):
							



		<SAVED IN THE FILE - Sample Running Result_GUI Console.txt>






					