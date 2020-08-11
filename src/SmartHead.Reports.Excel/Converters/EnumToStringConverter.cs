using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using SmartHead.Reports.Abstractions.Converters;

namespace SmartHead.Reports.Excel.Converters
{
    public class EnumToStringConverter : IValueConverter
    {
        public string Convert(object value)
        {
            if (value == null)
                return String.Empty;

            var valueType = value.GetType();
            
            if (!valueType.IsEnum || !Enum.IsDefined(valueType, value))
                throw new ArgumentException(nameof(valueType));

            var member = valueType
                .GetMember(value.ToString())
                .FirstOrDefault();

            if(member == null)
                return String.Empty;
            
            return member.GetCustomAttribute<DisplayAttribute>()?.Name
                   ?? member.GetCustomAttribute<DescriptionAttribute>()?.Description
                   ?? value.ToString();
        }
    }
}