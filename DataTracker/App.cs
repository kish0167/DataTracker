using DataTracker.BelTransSat;
using DataTracker.Excel;
using ExcelParser.BelTransSat;

namespace DataTracker
{
    static class App
    {
        public static async Task Main(string[] args)
        {
            ExcelSettings.LoadSettings();
            ExcelFileManager excelFileManager = new ExcelFileManager(ExcelSettings.SourceFileLocation,ExcelSettings.ArchieveFolder);
            excelFileManager.LoadExcelFile();
            
            excelFileManager.ArchiveData();
            
            MonthlyFileUpdater updater = new MonthlyFileUpdater(excelFileManager);
            updater.Update();

            StatisticsFiller statisticsFiller = new StatisticsFiller(excelFileManager);
            statisticsFiller.FillStatistics();

            SatDataFiller satDataFiller = new SatDataFiller(excelFileManager);
            await satDataFiller.Fill();
            
            excelFileManager.SaveExcelFile();
            Console.Beep();
            Console.ReadKey();
        }
    }
    
}