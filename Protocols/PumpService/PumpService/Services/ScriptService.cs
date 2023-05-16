using Microsoft.CSharp;
using NLog;
using PumpService.Data.Interfaces;
using PumpService.Services.Interfaces;
using PumpService.Settings.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace PumpService.Services
{
    public class ScriptService : IScriptService
    {
        private readonly Logger _logger;
        private readonly IScriptSettings _settings;
        private readonly IStatisticsData _statisticsData;
        private readonly IPumpServiceCallback _callback;
        private CompilerResults _compilerResults;

        public ScriptService(Logger logger, IScriptSettings settings, IStatisticsData statisticsData, IPumpServiceCallback callback)
        {
            _logger = logger;
            _settings = settings;
            _statisticsData = statisticsData;
            _callback = callback;
        }

        public bool Compile()
        {
            try
            {
                _logger.Info("Старт компиляции скрипта...");
                CompilerParameters compilerParameters = new CompilerParameters();
                compilerParameters.GenerateInMemory = true;
                compilerParameters.ReferencedAssemblies.Add("System.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
                compilerParameters.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                compilerParameters.ReferencedAssemblies.Add("Microsoft.CSharp.dll");
                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
                string script = File.ReadAllText(_settings.FileName);
                CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider();
                _compilerResults = cSharpCodeProvider.CompileAssemblyFromSource(compilerParameters, script);
                
                if (_compilerResults.Errors?.Count != 0)
                {
                    string compileErrors = string.Join("\n", _compilerResults.Errors.Cast<CompilerError>().Select(e => e.ToString()));
                    _logger.Error("Ошибки компиляции {errors}", compileErrors);
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Ошибка при компиляци скрипта");
                return false;
            }

            _logger.Info("Окончание компиляции скрипта...");
            return true;
        }

        public void Run()
        {
            if (_compilerResults == null || (_compilerResults.Errors?.Count != 0))
                if (!Compile())
                    return;

            Type type = _compilerResults.CompiledAssembly.GetType("Sample.SampleScript");
            if (type == null)
                return;

            MethodInfo entryPointMethod = type.GetMethod("EntryPoint");
            if (entryPointMethod == null)
                return;
            Task.Run(() =>
            {
                try
                {
                    _logger.Info("Старт выполнения скрипта...");

                    for (int i = 0; i < 10; i++)
                    {
                        if ((bool)entryPointMethod.Invoke(Activator.CreateInstance(type), new object[] { }))
                            _statisticsData.SuccessTacts++;
                        else
                            _statisticsData.ErrorTacts++;

                        _statisticsData.AllTacts++;
                        _callback.UpdateStatistics((Data.StatisticsData)_statisticsData);
                        Thread.Sleep(1000);
                    }
                    _logger.Info("Окончание выполнения скрипта.");
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Ошибка при выполнении скрипта");
                }
            });
           
        }
    }
}