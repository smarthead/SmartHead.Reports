namespace SmartHead.Reports.Core
{
    public interface IReporter<in T>
    {
        byte[] Export(T[] input, byte[] template = null);
    }
}