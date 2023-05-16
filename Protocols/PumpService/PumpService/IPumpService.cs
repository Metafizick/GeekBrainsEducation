using System.ServiceModel;

namespace PumpService
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IPumpServiceCallback))]
    public interface IPumpService
    {
        [OperationContract(IsOneWay = true)]
        void RunScript();

        [OperationContract(IsOneWay = true)]
        void UpdateAndCompileScript(string fileName);

        [OperationContract(IsOneWay = true)]
        void CompileScript();
    }
}
