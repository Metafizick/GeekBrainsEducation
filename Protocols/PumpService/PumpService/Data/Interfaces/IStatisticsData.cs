namespace PumpService.Data.Interfaces
{
    public interface IStatisticsData
    {
        int SuccessTacts { get; set; }
        int ErrorTacts { get; set; }
        int AllTacts { get; set; }
    }
}
