using PumpService.Settings.Interfaces;

namespace PumpService.Settings
{
    public class ScriptSettings: IScriptSettings
    {
        private const string defaultFileName = @"e:\tmp\scripts\Sample.script";

        public string FileName { get; set; } = defaultFileName;
    }
}