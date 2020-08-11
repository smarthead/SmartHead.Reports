using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SmartHead.Reports.Example.Reporters;
using SmartHead.Reports.Excel.Reporters;

namespace SmartHead.Reports.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var data = Enumerable
                .Range(0, 1000)
                .Select(x => new User
                {
                    Name = $"{nameof(User.Name)} {x}",
                    Role = x % 2 == 0 ? Role.Admin : Role.Guest,
                    IsLocked = x % 2 != 0
                })
                .ToArray();

            var reporter = new ExcelReporter<User>();

            var report = reporter.Export(data, new ReportOptions());

            await using var s = File.Create("data.xlsx");
            await s.WriteAsync(report);
        }
    }
}