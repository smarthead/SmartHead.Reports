using System;

namespace SmartHead.Reports.Abstractions.Converters
{
    public interface IValueConverter
    {
        public string Convert(object value);
    }
}