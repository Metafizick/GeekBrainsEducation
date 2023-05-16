using System.ServiceModel;
using PumpService.Settings.Interfaces;
using PumpService.Services.Interfaces;
using PumpService.Services;
using PumpService.Settings;
using PumpService.Data;
using NLog;

namespace PumpService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class PumpService : IPumpService
    {
        private readonly IScriptService _scriptService;
        private readonly IScriptSettings _settings;
        private StatisticsData _statisticsData;
        private Logger _logger;

        private IPumpServiceCallback Callback => OperationContext.Current.GetCallbackChannel<IPumpServiceCallback>();

        public PumpService()
        {
            _logger = LogManager.GetCurrentClassLogger();
            _settings = new ScriptSettings();
            _statisticsData = new StatisticsData();
            _scriptService = new ScriptService(_logger, _settings, _statisticsData, Callback);
        }

        public void CompileScript()
        {
            _scriptService.Compile();
        }

        public void RunScript()
        {
            _scriptService.Run();
        }

        public void UpdateAndCompileScript(string fileName)
        {
            _settings.FileName = fileName;
            _scriptService.Compile();
        }
    }
}
