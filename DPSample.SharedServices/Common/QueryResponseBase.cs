namespace DPSample.SharedServices.Common
{
    public class QueryResponseBase : CommandResponseBase
    {
        public int ResultCount { get; set; } = 0;
    }
}