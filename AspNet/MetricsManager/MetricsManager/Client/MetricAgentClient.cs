using MetricsAgent.Responses;
using MetricsManager.Requests;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public class MetricAgentClient : IMetricAgentClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        public MetricAgentClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public AllHddMetricsResponse GetHddMetrics(GetAllHddMetricsRequest request)
        {
            var requestString = request.FromTime.ToString();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:5001/api/metricsagent/hdd/from/{requestString}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllHddMetricsResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public AllRamMetricsResponse GetAllRamMetrics(GetAllRamMetricsRequest request)
        {
            throw new NotImplementedException();
        }

        public AllCpuMetricsResponse GetCpuMetrics(GetAllCpuMetricsRequest request)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:5001/api/metricsagent/cpu/from/{request.FromTime}");
            try
            {
                HttpResponseMessage response = _httpClient.SendAsync(httpRequest).Result;
                using var responseStream = response.Content.ReadAsStreamAsync().Result;
                return JsonSerializer.DeserializeAsync<AllCpuMetricsResponse>(responseStream).Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public AllNetworkMetricsResponse GetCpuMetrics(GetAllNetworkMetricsRequest request)
        {
            throw new NotImplementedException();
        }

        public AllDotNetMetricsResponse GetDotNetMetrics(GetAllDotNetMetricsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
