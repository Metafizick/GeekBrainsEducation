namespace MetricsManager.Requests
{
    public class GetAllDotNetMetricsRequest
    {
        public GetAllDotNetMetricsRequest(string from)
        {
            From = from;
        }
        public string From { get; }
    }
}
