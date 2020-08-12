using System;
using SmartHead.Reports.Excel.Converters;
using Xunit;

namespace SmartHead.Reports.Excel.Tests.Converters
{
    public class EnumToStringConverterTests
    {
        private EnumToStringConverter _converter = new EnumToStringConverter();
        
        private enum Order
        {
            First,
            Second
        }
        
        private enum Tests
        {
            First,
            Second
        }

        [Theory]
        [InlineData(null)]
        [InlineData(Order.First)]
        public void EnumToStringConverter_ShouldReturn_EmptyString_For_Given_Values(object value)
        {
            var result = _converter.Convert(value);
            
            Assert.Equal(result, String.Empty);
        }
        
        [Theory]
        [InlineData(1)]
        [InlineData("")]
        public void EnumToStringConverter_ShouldThrow_ArgumentException_For_Given_Values(object value)
        {
            Assert.Throws<ArgumentException>(() => _converter.Convert(value));
        }
    }
}