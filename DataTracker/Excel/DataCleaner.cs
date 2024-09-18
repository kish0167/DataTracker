using OfficeOpenXml;

namespace ExcelParser.Excel
{
    public class DataCleaner
    {
        public void CleanOldData(ExcelWorkbook workbook)
        {
            foreach (var worksheet in workbook.Worksheets)
            {
                if (!ExcelSettings.IsVehicleSheet(worksheet))
                {
                    continue;
                }   
                ExcelSettings.NumericDataCells(worksheet).Value = null;
                ExcelSettings.ConstructionSitesCells(worksheet).Value = "-";
                ExcelSettings.ConsumptionDataCells(worksheet).Value = 0;
            }
        }
    }
}