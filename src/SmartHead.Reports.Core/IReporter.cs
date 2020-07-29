using System.Reflection;

namespace SmartHead.Reports.Core
{
    public interface IReporter<in TInput, in TOptions, out TResult>
        where TOptions: class
    { 
        TResult Export(TInput[] input, TOptions options = null);
    }
}