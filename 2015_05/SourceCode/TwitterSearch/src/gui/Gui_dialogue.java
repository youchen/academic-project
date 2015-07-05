package gui;

import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JTextField;
import javax.swing.JLabel;
import javax.swing.SwingConstants;
import javax.swing.JSeparator;
import javax.swing.JButton;
import javax.swing.JTextArea;

import db_backup_excel.poi_excel;
import driver.Driver;

import java.awt.SystemColor;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;
import java.io.IOException;

import twitr.twt_search;

import java.io.PrintStream;

import javax.swing.JScrollPane;
import javax.swing.JPasswordField;


public class Gui_dialogue {

	private JFrame frmCsFinal;
	private JTextField inputUsername;
	private JTextField inputJdbcConnectionString;
	private JLabel lblNewLabel;
	private JSeparator separator_1;
	private JSeparator separator_2;
	private JSeparator separator_3;
	private JLabel lblStepDatabase;
	private JTextField inputQueryKeyword;
	private JTextField inputRespondCount;
	private JTextField inputOfflineSearchKeyword;
	
	public static String[] gui_DBInput = new String[2];
	@SuppressWarnings("unused")
	private PrintStream standardOut;
	private JPasswordField inputPasswordField;
	
	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Gui_dialogue window = new Gui_dialogue();
					window.frmCsFinal.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the application.
	 */
	public Gui_dialogue() {
		initialize();
	}

	/**
	 * Initialize the contents of the frame.
	 */
	private void initialize() {
		frmCsFinal = new JFrame();
		frmCsFinal.setTitle("Twitter Search - Youchen Ren");
		frmCsFinal.setBounds(100, 100, 1128, 753);
		frmCsFinal.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frmCsFinal.getContentPane().setLayout(null);
		
		inputUsername = new JTextField();
		inputUsername.setBounds(151, 55, 137, 28);
		frmCsFinal.getContentPane().add(inputUsername);
		inputUsername.setColumns(10);
		
		inputJdbcConnectionString = new JTextField();
		inputJdbcConnectionString.setColumns(10);
		inputJdbcConnectionString.setBounds(150, 159, 138, 28);
		frmCsFinal.getContentPane().add(inputJdbcConnectionString);
		
		lblNewLabel = new JLabel("jdbc:mysql://");
		lblNewLabel.setHorizontalAlignment(SwingConstants.RIGHT);
		lblNewLabel.setBounds(49, 165, 103, 16);
		frmCsFinal.getContentPane().add(lblNewLabel);
		
		JSeparator separator = new JSeparator();
		separator.setBounds(229, 31, 73, 12);
		frmCsFinal.getContentPane().add(separator);
		
		JLabel lblUsername = new JLabel("Username");
		lblUsername.setHorizontalAlignment(SwingConstants.RIGHT);
		lblUsername.setBounds(30, 61, 103, 16);
		frmCsFinal.getContentPane().add(lblUsername);
		
		JLabel lblPassword = new JLabel("Password");
		lblPassword.setHorizontalAlignment(SwingConstants.RIGHT);
		lblPassword.setBounds(30, 86, 103, 16);
		frmCsFinal.getContentPane().add(lblPassword);
		
		separator_1 = new JSeparator();
		separator_1.setBounds(15, 214, 294, 12);
		frmCsFinal.getContentPane().add(separator_1);
		
		separator_2 = new JSeparator();
		separator_2.setOrientation(SwingConstants.VERTICAL);
		separator_2.setBounds(307, 35, 12, 191);
		frmCsFinal.getContentPane().add(separator_2);
		
		separator_3 = new JSeparator();
		separator_3.setOrientation(SwingConstants.VERTICAL);
		separator_3.setBounds(6, 35, 12, 191);
		frmCsFinal.getContentPane().add(separator_3);
		
		lblStepDatabase = new JLabel("Step 1: Database Configuration");
		lblStepDatabase.setHorizontalAlignment(SwingConstants.RIGHT);
		lblStepDatabase.setBounds(15, 27, 202, 16);
		frmCsFinal.getContentPane().add(lblStepDatabase);
		
		JButton btnDBConfigurate = new JButton("Configurate");
		btnDBConfigurate.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				gui_DBInput[0] = inputUsername.getText();
				gui_DBInput[1] = String.valueOf(inputPasswordField.getPassword());
				/**
				 * Examine if the JdbcConnection String is empty or not.
				 */
				if(inputJdbcConnectionString.getText().equals(""))
					Driver.DB_URL = "jdbc:mysql://localhost:3306/";
				else
					Driver.DB_URL = "jdbc:mysql://" + inputJdbcConnectionString.getText();
				
				Driver.ini_FileSystem();//=========================
				try {
					Driver.ini_DB(gui_DBInput, "Twitter_Search");//=============
				} catch (Throwable e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				try {
					poi_excel.firstTimeConfig();//=========================
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				System.out.println("Database Configured successful! \n\n\n");
			}
		});
		btnDBConfigurate.setBounds(181, 186, 117, 29);
		frmCsFinal.getContentPane().add(btnDBConfigurate);
		
		inputQueryKeyword = new JTextField();
		inputQueryKeyword.setColumns(10);
		inputQueryKeyword.setBounds(543, 59, 137, 28);
		frmCsFinal.getContentPane().add(inputQueryKeyword);
		
		inputRespondCount = new JTextField();
		inputRespondCount.setColumns(10);
		inputRespondCount.setBounds(543, 127, 137, 28);
		frmCsFinal.getContentPane().add(inputRespondCount);
		
		JSeparator separator_4 = new JSeparator();
		separator_4.setBounds(519, 35, 175, 12);
		frmCsFinal.getContentPane().add(separator_4);
		
		JLabel lblKeyword = new JLabel("Keyword");
		lblKeyword.setHorizontalAlignment(SwingConstants.RIGHT);
		lblKeyword.setBounds(422, 65, 103, 16);
		frmCsFinal.getContentPane().add(lblKeyword);
		
		JLabel lblRespondCount = new JLabel("Respond Count (default: 30) [optional]");
		lblRespondCount.setHorizontalAlignment(SwingConstants.RIGHT);
		lblRespondCount.setBounds(407, 104, 248, 22);
		frmCsFinal.getContentPane().add(lblRespondCount);
		
		JSeparator separator_5 = new JSeparator();
		separator_5.setBounds(407, 218, 294, 12);
		frmCsFinal.getContentPane().add(separator_5);
		
		JSeparator separator_6 = new JSeparator();
		separator_6.setOrientation(SwingConstants.VERTICAL);
		separator_6.setBounds(699, 39, 12, 191);
		frmCsFinal.getContentPane().add(separator_6);
		
		JSeparator separator_7 = new JSeparator();
		separator_7.setOrientation(SwingConstants.VERTICAL);
		separator_7.setBounds(398, 35, 12, 191);
		frmCsFinal.getContentPane().add(separator_7);
		
		JLabel lblStepQuery = new JLabel("Step 2: Query");
		lblStepQuery.setHorizontalAlignment(SwingConstants.RIGHT);
		lblStepQuery.setBounds(407, 31, 103, 16);
		frmCsFinal.getContentPane().add(lblStepQuery);
		
		JButton btnOnlineSearch = new JButton("Search");
		btnOnlineSearch.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(inputRespondCount.getText().equals("") )
					twt_search.queryCount = 30;
				else
					twt_search.queryCount = Integer.parseInt(inputRespondCount.getText());
				
				System.out.println("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"
						+ "=============================== Search for query: " + 
						inputQueryKeyword.getText() + " =======================================\n\n\n\n");
				try {
					twt_search.Twit_search(inputQueryKeyword.getText());
				} catch (Exception e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		btnOnlineSearch.setBounds(579, 190, 117, 29);
		frmCsFinal.getContentPane().add(btnOnlineSearch);
		
		JButton btnReCon = new JButton("Re-construction Database");
		btnReCon.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				try {
					twt_search.reconstruction();
				} catch (Throwable e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
				System.out.println("\n\n\nDatabase Recoverd Successfully!\n\n\n\n");
			}
		});
		btnReCon.setBounds(853, 76, 202, 29);
		frmCsFinal.getContentPane().add(btnReCon);
		
		inputOfflineSearchKeyword = new JTextField();
		inputOfflineSearchKeyword.setColumns(10);
		inputOfflineSearchKeyword.setBounds(925, 135, 137, 28);
		frmCsFinal.getContentPane().add(inputOfflineSearchKeyword);
		
		JButton btnOfflineSearch = new JButton("Offline Search");
		btnOfflineSearch.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				try {
					System.out.println("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"
							+ "==================================== Offline Search for " +
							inputOfflineSearchKeyword.getText() + "=========================================");
					poi_excel.find(inputOfflineSearchKeyword.getText());
				} catch (IOException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
			}
		});
		btnOfflineSearch.setBounds(945, 173, 117, 29);
		frmCsFinal.getContentPane().add(btnOfflineSearch);
		
		JSeparator separator_8 = new JSeparator();
		separator_8.setOrientation(SwingConstants.VERTICAL);
		separator_8.setBounds(790, 35, 12, 191);
		frmCsFinal.getContentPane().add(separator_8);
		
		JSeparator separator_9 = new JSeparator();
		separator_9.setBounds(799, 214, 294, 12);
		frmCsFinal.getContentPane().add(separator_9);
		
		JSeparator separator_10 = new JSeparator();
		separator_10.setOrientation(SwingConstants.VERTICAL);
		separator_10.setBounds(1085, 31, 12, 191);
		frmCsFinal.getContentPane().add(separator_10);
		
		JSeparator separator_11 = new JSeparator();
		separator_11.setBounds(911, 31, 175, 12);
		frmCsFinal.getContentPane().add(separator_11);
		
		JSeparator separator_12 = new JSeparator();
		separator_12.setBounds(798, 117, 295, 12);
		frmCsFinal.getContentPane().add(separator_12);
		
		JLabel lblOtherFeatures = new JLabel("Other features");
		lblOtherFeatures.setHorizontalAlignment(SwingConstants.RIGHT);
		lblOtherFeatures.setBounds(804, 27, 103, 16);
		frmCsFinal.getContentPane().add(lblOtherFeatures);
		
		/**
		 * make JTextArea Scrollable
		 */
		JTextArea Console = new JTextArea();
		JScrollPane scroll = new JScrollPane (Console, 
				JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_ALWAYS);
		scroll.setBounds(15, 265, 1087, 446);
		frmCsFinal.getContentPane().add(scroll);
		
		JTextArea txtrJdbcConnectionString = new JTextArea();
		txtrJdbcConnectionString.setBackground(SystemColor.window);
		txtrJdbcConnectionString.setText("JDBC connection string [optional]\ndefault: jdbc:mysql://localhost:3306/");
		txtrJdbcConnectionString.setBounds(30, 120, 258, 39);
		frmCsFinal.getContentPane().add(txtrJdbcConnectionString);
		
		PrintStream printStream = new PrintStream(new CustomOutputStream(Console));
		
		inputPasswordField = new JPasswordField();
		inputPasswordField.setBounds(151, 80, 137, 28);
		frmCsFinal.getContentPane().add(inputPasswordField);
		
		JTextArea txtrKeywordcaseInsensative = new JTextArea();
		txtrKeywordcaseInsensative.setText("Keyword\n(case INsensitive)");
		txtrKeywordcaseInsensative.setBackground(SystemColor.window);
		txtrKeywordcaseInsensative.setBounds(814, 133, 113, 37);
		frmCsFinal.getContentPane().add(txtrKeywordcaseInsensative);
		// keeps reference of standard output stream
        standardOut = System.out;
         
        // re-assigns standard output stream and error output stream
        System.setOut(printStream);
        System.setErr(printStream);
	}
}
