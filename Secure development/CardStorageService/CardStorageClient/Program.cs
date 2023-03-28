using Grpc.Net.Client;
using static ClientServiceProtos.ClientService;
namespace CardStorageClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создать клиента...");
            Console.ReadLine();

            using (GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5001"))
            {
                ClientServiceClient client = new ClientServiceClient(channel);
                var response = client.Create(new ClientServiceProtos.CreateClientRequest
                {
                    FirstName = "Андрей",
                    Surname = "Бауткин",
                    Patronymic = "Геннадьевич"
                });

                Console.WriteLine($"ClientId:{response.ClientId}; Errcode: {response.ErrorCode}; ErrMessage: {response.ErrorMessage}");
            }
        }
    }
}