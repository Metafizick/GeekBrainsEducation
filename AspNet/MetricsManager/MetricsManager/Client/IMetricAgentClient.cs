using MetricsAgent.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Requests;

namespace MetricsManager.Client
{
    interface IMetricAgentClient
    {
        AllRamMetricsResponse GetAllRamMetrics(GetAllRamMetricsRequest request);
        AllHddMetricsResponse GetHddMetrics(GetAllHddMetricsRequest request);
        AllDotNetMetricsResponse GetDotNetMetrics(GetAllDotNetMetricsRequest request);
        AllCpuMetricsResponse GetCpuMetrics(GetAllCpuMetricsRequest request);
        AllNetworkMetricsResponse GetCpuMetrics(GetAllNetworkMetricsRequest request);
    }
}    

