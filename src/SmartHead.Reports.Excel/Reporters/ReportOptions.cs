namespace SmartHead.Reports.Excel.Reporters
{
    public class ReportOptions
    {
        public ReportOptions(byte[] template = null, int pageSize = 1000000, int startFrom = 2)
        {
            Template = template;
            PageSize = pageSize;
            StartFrom = startFrom;
        }
        
        public byte[] Template { get; }
        
        public int PageSize { get; }
        
        public int StartFrom { get; }
    }
}