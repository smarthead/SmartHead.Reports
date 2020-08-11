using System;

namespace SmartHead.Reports.Excel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Title { get; set; }
        
        public string Format { get; set; }
        
        public bool WrapText { get; set; }
    }
}