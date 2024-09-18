using System;
using System.Net.Http.Json;
using System.Text.Json;
using ExcelParser.BelTransSat;
using ExcelParser.Excel;
using ExcelParser.Properties;

namespace ExcelParser
{
    static class App
    {
        public static void Main(string[] args)
        {
            ExcelSettings.LoadSettings();
            
            MonthlyFileUpdater updater = new MonthlyFileUpdater(ExcelSettings.SourceFileLocation, ExcelSettings.ArchieveFolder);
            //updater.Update();

            StatisticsFiller statisticsFiller = new StatisticsFiller(ExcelSettings.SourceFileLocation);
            //statisticsFiller.FillStatistics();
            
            
            Console.Beep();
            Console.ReadKey();
        }
    }
    
    public class JsonDeserializer
    {
        public static Root DeserializeJson(string jsonString)
        {
            return JsonSerializer.Deserialize<Root>(jsonString);
        }
    }
}