// using System.IO;
// using System.Linq;
// using System.Reflection;
// using OfficeOpenXml;
// using OfficeOpenXml.Table;
// using SmartHead.Reports.Core;
//
// namespace SmartHead.Reports.Excel
// {
//     public abstract class ExcelReporterBase<T> : IReporter<T>
//     {
//         protected int ChunkSize { get; set; } = 1000000;
//         
//         protected int StartRow { get; set; } = 2;
//         
//         protected abstract MemberInfo[] GetExportedProperties();
//         
//         protected abstract string GetName(int chunk, int chunkSize, int resultLength);
//         
//         protected abstract ExcelWorksheet GetWorkSheet(ExcelWorkbook workbook, string name);
//
//         public byte[] Export(T[] input, byte[] template = null)
//         {
//             using var package = template == null
//                 ? new ExcelPackage()
//                 : new ExcelPackage(new MemoryStream(template));
//
//             var properties = GetExportedProperties();
//             
//             var chunkCount = input.Length / ChunkSize + 1;
//
//             for (var i = 0; i < chunkCount; i++)
//             {
//                 var chunk = input
//                     .Skip(i * ChunkSize)
//                     .Take(ChunkSize)
//                     .ToArray();
//
//                 var ws = GetWorkSheet(package.Workbook, GetName(i, ChunkSize, chunk.Length));
//                 
//                 ws.Cells[StartRow, 1].LoadFromCollection(chunk, 
//                     false, 
//                     TableStyles.None, 
//                     BindingFlags.Public, 
//                     properties);
//             }
//
//             return package.GetAsByteArray();
//         }
//     }
// }