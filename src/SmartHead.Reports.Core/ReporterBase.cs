using System.Linq;
using System.Reflection;
using SmartHead.Reports.Core.Attributes;

namespace SmartHead.Reports.Core
{
    public abstract class ReporterBase<TInput, TOptions, TResult> : IReporter<TInput, TOptions, TResult>
        where TOptions: class
    {
        protected virtual MemberInfo[] GetExportedProperties()
        {
            return typeof(TInput)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => !x.IsDefined(typeof(ExportIgnoreAttribute)))
                .Cast<MemberInfo>()
                .ToArray();
        }
        
        public abstract TResult Export(TInput[] input, TOptions options = default(TOptions));
    }
}