using PumpService.Data;
using PumpService.Data.Interfaces;
using System.ServiceModel;

namespace PumpService
{
    [ServiceContract]
    public interface IPumpServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void UpdateStatistics(StatisticsData statisticsData);
    }
}
