using System.IO;
using OfficeOpenXml;

namespace ExcelParser.Excel
{
    public class ExcelFileManager
    {
        private string _sourceFilePath;
        private string _archiveFilePath;

        public ExcelFileManager(string sourcePath, string archivePath)
        {
            _sourceFilePath = sourcePath;
            _archiveFilePath = archivePath;
        }

        public ExcelFileManager(string sourcePath)
        {
            _sourceFilePath = sourcePath;
            _archiveFilePath = "none";
        }

        // Loads the Excel file
        public ExcelPackage LoadExcelFile()
        {
            var package = new ExcelPackage(new FileInfo(_sourceFilePath));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            return package;
        }

        // Archives the data to a new file
        public void ArchiveData(ExcelPackage sourcePackage)
        {
            using (var archivePackage = new ExcelPackage(new FileInfo(_archiveFilePath)))
            {
                foreach (var sourceWorksheet in sourcePackage.Workbook.Worksheets)
                {
                    // Clone the worksheet into the archive package
                    archivePackage.Workbook.Worksheets.Add(sourceWorksheet.Name, sourceWorksheet);
                }
                // Save the archive file
                archivePackage.Save();
            }
        }

        public void SaveExcelFile(ExcelPackage package)
        {
            package.Save();
        }
    }
}