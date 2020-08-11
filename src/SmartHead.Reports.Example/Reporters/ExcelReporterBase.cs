using OfficeOpenXml;
using OfficeOpenXml.Style;
using SmartHead.Reports.Abstractions.Attributes;
using SmartHead.Reports.Excel.Attributes;
using SmartHead.Reports.Excel.Converters;
using SmartHead.Reports.Excel.Reporters;

namespace SmartHead.Reports.Example.Reporters
{
    public enum Role
    {
        Admin,
        Guest
    }
    
    public class User
    {
        [Column(Title = "Имя пользователя")]
        public string Name { get; set; }

        [Column(Title = "Роль")]
        [ValueConverter(typeof(EnumToStringConverter))]
        public Role Role { get; set; }

        [Column(Title = "Заблокирован")]
        [ValueConverter(typeof(BooleanToStringConverter))]
        public bool IsLocked { get; set; }
    }
}