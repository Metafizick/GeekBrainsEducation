namespace MetricsManager.Requests
{
    public class GetAllHddMetricsRequest
    {
        public GetAllHddMetricsRequest(string from)
        {
            From = from;
        }
        public string From { get; }
    }
}
