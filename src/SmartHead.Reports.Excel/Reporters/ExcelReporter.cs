using System;
using SmartHead.Reports.Core;

namespace SmartHead.Reports.Excel.Reporters
{
    public abstract class ExcelReporter<Tin> : IReporter<Tin, ReportOptions, byte[]>
    {
        public byte[] Export(Tin[] input, ReportOptions options = null)
        {
            throw new NotImplementedException();
        }
    }
}