package db_backup_excel;

import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.ss.usermodel.Sheet;
import org.apache.poi.xssf.streaming.SXSSFWorkbook;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import driver.Driver;

import java.io.*;

public class poi_excel{
	public static String dirPath;
	private static FileOutputStream out;
	
	public static void iniTest() throws Throwable {
		@SuppressWarnings("unused")
		SXSSFWorkbook wb = firstTimeConfig();
		
	}
	public static Sheet createSheets(String SheetName) throws IOException {
		
		FileInputStream file = new FileInputStream(new File(dirPath + "/Backup.xlsx"));
		@SuppressWarnings("resource")
		XSSFWorkbook wb = new XSSFWorkbook(file);

		Sheet sh =  wb.createSheet(SheetName);
		
		String[] rowFill = {"Username", "Fullname", "Date_time", "Tweet", "Image_1", "Image_2", "Image_3", "Image_4"};
		Row row = sh.createRow(0);
		for(int i = 0; i < rowFill.length; i++) {
			Cell cell = row.createCell(i);
			cell.setCellValue(rowFill[i]);
		}
		/**
		 * Write data to the workbook.
		 */
		FileOutputStream outFile = new FileOutputStream(new File(dirPath + "/Backup.xlsx"));
		wb.write(outFile);
		outFile.close();
		return sh;
	}
	public static SXSSFWorkbook firstTimeConfig() throws IOException {
		/**
		 * Make dir which the excel backup workbook will be stored at.
		 */
		dirPath = System.getProperty("user.dir") + "/Excel_Backup";
		File theDir = new File(dirPath);
		try {
			theDir.mkdir();
		}catch(SecurityException se){}
		
		/**
		 * Create workbook in the directory.
		 */
		out = new FileOutputStream(dirPath + "/Backup.xlsx");
		
		SXSSFWorkbook wb = new SXSSFWorkbook(1000); // keep 100 rows in memory, exceeding rows will be flushed to disk
		wb.write(out);
		
		out.close();
		return wb;
	}
	public static void find(String content) throws IOException {
		/**
		 * Grab the .xlsx file.
		 */
	    File myFile = new File(Driver.getCurrentDirectroy() + "/Excel_Backup/Backup.xlsx");
        FileInputStream fis = new FileInputStream(myFile);

        // Finds the workbook instance for XLSX file
        @SuppressWarnings("resource")
		XSSFWorkbook wb = new XSSFWorkbook (fis);
        
		for(Sheet sheet: wb) {
			for (Row row : sheet) {
				for (Cell cell : row) {
					if(cell.getCellType() == Cell.CELL_TYPE_STRING &&
							cell.getStringCellValue().toLowerCase().contains(content.toLowerCase())) {
						System.out.println("Sheet: \t" + sheet.getSheetName() + "\nRow: \t" + row.getRowNum()
								+ "\nColumn: \t" + cell.getColumnIndex());
						System.out.println("Cell content: \t" + cell.getStringCellValue().replaceAll("\n", " ") + "\n\n\n");
					}
				}
			}
		}
	}
}