using System;

namespace MetricsManager.Requests
{
    public class GetAllHddMetricsRequest
    {
        public GetAllHddMetricsRequest(TimeSpan fromTime)
        {
            FromTime = fromTime;
        }
        public TimeSpan FromTime { get; }
    }
}
