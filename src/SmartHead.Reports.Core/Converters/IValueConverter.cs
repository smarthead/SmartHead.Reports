using System;

namespace SmartHead.Reports.Core.Interfaces
{
    public interface IValueConverter<in Tin, out TOut>
    {
        TOut Convert(Tin value);
    }
}