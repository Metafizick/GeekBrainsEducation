using PumpService.Data.Interfaces;
using System.Runtime.Serialization;

namespace PumpService.Data
{
    [DataContract]
    public class StatisticsData : IStatisticsData
    {
        
        [DataMember]
        public int SuccessTacts { get; set; }
        
        [DataMember]
        public int ErrorTacts { get; set; }
        
        [DataMember]
        public int AllTacts { get; set; }
    }
}