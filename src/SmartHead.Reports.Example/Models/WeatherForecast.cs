using System;
using SmartHead.Reports.Core.Attributes;

namespace SmartHead.Reports.Example.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        [ExportIgnore]
        public string Summary { get; set; }
    }
}