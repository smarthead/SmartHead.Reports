using System.Linq;
using System.Reflection;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SmartHead.Reports.Example.Models;
using SmartHead.Reports.Excel;

namespace SmartHead.Reports.Example.Export
{
    public class WeatherExcelReporter : ExcelReporterBase<WeatherForecast>
    {
        protected override MemberInfo[] GetExportedProperties()
        {
            var ignoredProperties = new[]
            {
                nameof(WeatherForecast.Summary)
            };

            return typeof(WeatherForecast)
                .GetProperties()
                .Where(x => !ignoredProperties.Contains(x.Name))
                .Cast<MemberInfo>()
                .ToArray();
        }

        protected override string GetName(int chunk, int chunkSize, int resultLength)
        {
            return chunk == 0
                ? $"0 - {resultLength}"
                : $"{chunk * chunkSize} - {chunk * chunkSize + resultLength}";
        }

        protected override ExcelWorksheet GetWorkSheet(ExcelWorkbook workbook, string name)
        {
            var ws = workbook.Worksheets.Add(name);

            ws.Cells[1, 1].Value = "Порядковый номер";
            ws.Cells[1, 1].Style.WrapText = true;
            
            ws.Cells[1, 2].Value = "Дата";
            ws.Column(2).Style.Numberformat.Format = "dd.MM.yyyy HH:mm:ss";
            ws.Cells[1, 2].Style.WrapText = true;
            
            ws.Cells[1, 3].Value = "Номер телефона участника акции в расшифрованном виде";
            ws.Cells[1, 3].Style.WrapText = true;

            ws.Cells[1, 4].Value = "Номер телефона участника акции в расшифрованном виде";
            ws.Cells[1, 4].Style.WrapText = true;

            ws.Cells["A1:O1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            ws.Cells["A1:O1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["A1:O1"].AutoFitColumns();
            ws.Cells["A1:O1"].Style.Font.Bold = true;
            ws.Row(1).Height = 80;

            return ws;
        }
    }
}