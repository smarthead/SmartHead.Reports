using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;
using SmartHead.Reports.Abstractions.Attributes;
using SmartHead.Reports.Abstractions.Reporter;
using SmartHead.Reports.Excel.Extensions;
using SmartHead.Reports.Excel.Models;

namespace SmartHead.Reports.Excel.Reporters
{
    public class ExcelReporter<Tin> : IReporter<Tin, ReportOptions, byte[]>
    {
        public ExcelReporter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        
        private ColumnInfo[] GetColumns() 
            => GetExportedProperties()
                .Select(x => x.GetColumnInfo())
                .ToArray();

        protected virtual PropertyInfo[] GetExportedProperties()
        {
            return typeof(Tin)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => !x.IsDefined(typeof(ExportIgnoreAttribute)))
                .ToArray();
        }

        protected virtual string GetWorkSheetName(int chunk, int chunkSize, int resultLength)
        {
            return chunk == 0 
                ? $"0 - {resultLength}" 
                : $"{chunk * chunkSize} - {(chunk * chunkSize + resultLength)}";
        }
        
        public static void SetHeader(ExcelWorksheet ws, ColumnInfo[] columns, int startRow)
        {
            for (var i = 0; i < columns.Length; i++)
            {
                var column = columns[i];

                if(column.Value != null)
                    ws.Cells[startRow, i + 1].Value = column.Value;
                
                if(column.Format != null)
                    ws.Cells[startRow, i + 1].Style.Numberformat.Format = column.Format;
                
                if(column.WrapText.HasValue)
                    ws.Cells[startRow, i + 1].Style.WrapText = column.WrapText.Value;
            }
        }

        protected virtual ExcelWorksheet GetWorkSheet(ExcelWorkbook workbook, 
            string name, 
            ColumnInfo[] columns,
            ReportOptions options)
        {
            var ws = workbook.Worksheets.Add(name);
            
            SetHeader(ws, columns, options.StartFrom);
            
            return ws;
        }

        public byte[] Export(Tin[] records, ReportOptions options)
        {
            using var package = options.Template == null
                ? new ExcelPackage()
                : new ExcelPackage(new MemoryStream(options.Template));
            
            var columns = GetColumns();
            
            var chunkCount = records.Length / options.PageSize + 1;

            for (var i = 0; i < chunkCount; i++)
            {
                var chunk = records
                    .Skip(i *  options.PageSize)
                    .Take(options.PageSize)
                    .ToArray();

                var ws = GetWorkSheet(
                    package.Workbook,
                    GetWorkSheetName(i,  options.PageSize, chunk.Length),
                    columns,
                    options);

                for (var j = 0; j < records.Length; j++)
                {
                    var record = records[j];
                    for (var k = 0; k < columns.Length; k++)
                    {
                        var column = columns[k];
                        ws.Cells[j + 1 + options.StartFrom, k + 1].Value =
                            record.GetValue(column);
                    }
                }
            }

            return package.GetAsByteArray();
        }
    }
}