using System.Collections.Generic;
using System.Reflection;
using OfficeOpenXml;

namespace ExcelParser.Excel
{
    public class StatisticsFiller
    {
        private string _sourceFile;

        public StatisticsFiller(string sourceFile)
        {
            _sourceFile = sourceFile;
        }

        public void FillStatistics()
        {
            Logger.Log("Loading excel file...");
            ExcelFileManager fileManager = new ExcelFileManager(_sourceFile);
            ExcelPackage package = fileManager.LoadExcelFile();
            ExcelWorkbook workbook = package.Workbook;
            List<VehicleFuelStatistics> stats = new List<VehicleFuelStatistics>();
            
            foreach (var worksheet in workbook.Worksheets)
            {
                if (!ExcelSettings.IsVehicleSheet(worksheet))
                {
                    continue;
                }

                VehicleFuelStatistics vehicle = new VehicleFuelStatistics();
                TransferDataFromWorksheet(worksheet, vehicle);
                
                vehicle.CalculateTheoryConsumption();
                WriteConsumptionsToWorksheet(worksheet, vehicle);
                Logger.Log(vehicle.Name + " successfully written");
            }
            
            fileManager.SaveExcelFile(package);
        }

        private void TransferDataFromWorksheet(ExcelWorksheet worksheet, VehicleFuelStatistics statistics)
        {
            statistics.Name = (string)ExcelSettings.NameCell(worksheet).Value;
            
            for (int i = 0; i < ExcelSettings.Rows; i++)
            {
                var temp = ExcelSettings.RefuelsDataCells(worksheet).GetCellValue<object>(i,0);
                if (temp==null)
                {
                    statistics.AddRefuel(0);
                }
                else
                {
                    statistics.AddRefuel((double)temp);
                }
                
                temp = ExcelSettings.TravelsDistancesCells(worksheet).GetCellValue<object>(i,0);
                
                if (temp==null)
                {
                    statistics.AddTravel(0);
                }
                else
                {
                    statistics.AddTravel((double)temp);
                }
            }
        }

        private void WriteConsumptionsToWorksheet(ExcelWorksheet worksheet, VehicleFuelStatistics statistics)
        {
            for (int i = 0; i < ExcelSettings.Rows && i<statistics.TheoryConsumptions.Count; i++)
            {
                ExcelSettings.ConsumptionDataCells(worksheet).TakeSingleCell(i,0).Value = statistics.TheoryConsumptions[i];
            }
        }
    }
}