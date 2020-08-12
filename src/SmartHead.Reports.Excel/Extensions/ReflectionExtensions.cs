using System;
using System.Reflection;
using SmartHead.Reports.Abstractions.Attributes;
using SmartHead.Reports.Abstractions.Converters;
using SmartHead.Reports.Excel.Attributes;
using SmartHead.Reports.Excel.Models;

namespace SmartHead.Reports.Excel.Extensions
{
    public static class ReflectionExtensions
    {
        public static ColumnInfo GetColumnInfo(this PropertyInfo member)
        {
            var columnAttribute = member.GetCustomAttribute<ColumnAttribute>();
            var converterAttribute = member.GetCustomAttribute<ValueConverterAttribute>();
            
            return new ColumnInfo
            {
                Value = columnAttribute?.Title,
                Format = columnAttribute?.Format,
                WrapText = columnAttribute?.WrapText,
                Converter = converterAttribute != null? Activator
                    .CreateInstance(converterAttribute.ConverterType) as IValueConverter 
                    : null,
                PropertyInfo = member
            };
        }

        public static string GetValue<Tin>(this Tin source, ColumnInfo info)
        {
            var value = info.PropertyInfo.GetValue(source);
            return info.Converter?.Convert(value) ?? value?.ToString() ?? "";
        }
    }
}