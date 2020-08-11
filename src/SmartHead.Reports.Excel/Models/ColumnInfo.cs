using System.Reflection;
using SmartHead.Reports.Abstractions.Converters;

namespace SmartHead.Reports.Excel.Models
{
    public class ColumnInfo
    {
        public string Value { get; set; }

        public string Format { get; set; }

        public bool? WrapText { get; set; }

        public IValueConverter Converter { get; set; }

        public PropertyInfo PropertyInfo { get; set; }
    }
}