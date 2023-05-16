using PumpClient.PumpServiceReference;
using System;
using System.ServiceModel;

namespace PumpClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InstanceContext context = new InstanceContext(new CallbackHandler());
            PumpServiceClient pumpServiceClient = new PumpServiceClient(context);

            pumpServiceClient.CompileScript();
            pumpServiceClient.RunScript();

            Console.ReadKey();
            pumpServiceClient.Close();
        }
    }
}
