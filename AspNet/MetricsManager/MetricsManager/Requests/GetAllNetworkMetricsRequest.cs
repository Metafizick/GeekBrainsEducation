namespace MetricsManager.Requests
{
    public class GetAllNetworkMetricsRequest
    {
        public GetAllNetworkMetricsRequest(string from)
        {
            From = from;
        }
        public string From { get; }
    }
}
