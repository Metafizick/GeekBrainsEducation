using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpService.Services.Interfaces
{
    public interface IScriptService
    {
        void Run();

        bool Compile();
    }
}
