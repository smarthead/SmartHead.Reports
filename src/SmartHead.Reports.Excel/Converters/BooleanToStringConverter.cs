using System;
using SmartHead.Reports.Abstractions.Converters;

namespace SmartHead.Reports.Excel.Converters
{
    public class BooleanToStringConverter : IValueConverter
    {
        public string Convert(object value)
        {
            if (value == null || !Boolean.TryParse(value.ToString(), out var flag))
                return String.Empty;

            //todo: Локализация
            return flag
                ? "Да"
                : "Нет";
        }
    }
}