using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Requests
{
    public class GetAllRamMetricsRequest
    {
        public GetAllRamMetricsRequest (string from)
        {
            From = from;
        }
        public string From { get; }
    }
}
