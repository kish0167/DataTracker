using System;
using OfficeOpenXml;

namespace ExcelParser.Excel
{
    public class MonthlyFileUpdater
    {
        private string _sourceFile;
        private string _archiveFolder;

        public MonthlyFileUpdater(string sourceFile, string archiveFolder)
        {
            _sourceFile = sourceFile;
            _archiveFolder = archiveFolder;
        }
        
        public void Update()
        {
            Logger.Log("Starting updating process...");
            string _archieveFile = _archiveFolder + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xlsx";
            ExcelFileManager fileManager = new ExcelFileManager(_sourceFile, _archieveFile);
            ExcelPackage package = fileManager.LoadExcelFile();
            ExcelWorkbook workbook = package.Workbook;

            // Archive data
            fileManager.ArchiveData(package);
            Logger.Log("Data archived.");

            // Clean old data
            DataCleaner cleaner = new DataCleaner();
            cleaner.CleanOldData(workbook);
            Logger.Log("Old data cleaned.");

            // Update dates
            DateUpdater dateUpdater = new DateUpdater();
            dateUpdater.UpdateDates(workbook);
            Logger.Log("Dates updated.");

            // Save the cleaned and updated file
            fileManager.SaveExcelFile(package);
            Logger.Log("File saved.");

            Logger.Log("Updating complete.");
        }
    }
}