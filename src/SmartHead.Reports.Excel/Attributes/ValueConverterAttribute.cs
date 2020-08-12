using System;
using SmartHead.Reports.Abstractions.Converters;

namespace SmartHead.Reports.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValueConverterAttribute: Attribute
    {
        public Type ConverterType { get; }

        public ValueConverterAttribute(Type converterType)
        {
            ConverterType = converterType 
                            ?? throw new ArgumentNullException(nameof(converterType));

            if(!typeof(IValueConverter).IsAssignableFrom(converterType))
                throw new InvalidOperationException(nameof(converterType));
        }
    }
}