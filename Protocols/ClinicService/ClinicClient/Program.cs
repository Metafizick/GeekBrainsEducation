using ClientServiceProtos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using PetServiceProtos;
using static ClientServiceProtos.ClientService;
using static PetServiceProtos.PetService;

using var channel = GrpcChannel.ForAddress("https://localhost:5001");

ClinicService.Protos.AuthenticateService.AuthenticateServiceClient authenticateServiceClient = new ClinicService.Protos.AuthenticateService.AuthenticateServiceClient(channel);
var authenticationResponse = authenticateServiceClient.Login(new ClinicService.Protos.AuthenticationRequest
{
    UserName = "test@mail.ru",
    Password = "123456"
});

if (authenticationResponse.Status != 0)
{
    Console.WriteLine("Authentication error.");
    Console.ReadKey();
    return;
}

Console.WriteLine($"Session token: {authenticationResponse.SessionInfo.SessionToken}");

var credentials = CallCredentials.FromInterceptor((c, m) =>
{
    m.Add("Authorization",
        $"Bearer {authenticationResponse.SessionInfo.SessionToken}");
    return Task.CompletedTask;
});

var protectedChannel = GrpcChannel.ForAddress("https://localhost:5001",
        new GrpcChannelOptions
        {

            Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
        });

TestClients(protectedChannel);

TestPets(protectedChannel);

Console.ReadKey();

static void TestClients(GrpcChannel channel)
{
    var clientService = new ClientServiceClient(channel);

    var createClientResponse = clientService.CreateClient(new CreateClientRequest
    {
        Document = "PASS123",
        FirstName = "Федор",
        Surname = "Орликов",
        Patronymic = "Игоревич"
    });

    Console.WriteLine($"Client ({createClientResponse.ClientId}) created successfully.");


    var updateClientResponse = clientService.UpdateClient(new UpdateClientRequest
    {
        ClientId = createClientResponse.ClientId.Value,
        Document = $"PASS123_{Random.Shared.Next(1, 1000)}",
        FirstName = "Федор",
        Surname = "Орликов",
        Patronymic = "Игоревич"
    });

    if (updateClientResponse.ErrCode == 0)
        Console.WriteLine($"Client ({createClientResponse.ClientId}) updated successfully.");
    else
        Console.WriteLine($"Client update error code {updateClientResponse.ErrCode}:\r\n\t with error: {updateClientResponse.ErrMessage}");

    PrintClients(clientService);

    var deleteClientResponse = clientService.DeleteClient(new DeleteClientRequest
    {
        ClientId = createClientResponse.ClientId.Value
    });

    if (deleteClientResponse.ErrCode == 0)
        Console.WriteLine($"Client ({createClientResponse.ClientId}) deleted successfully.");
    else
        Console.WriteLine($"Client update error code {deleteClientResponse.ErrCode}:\r\n\t with error: {deleteClientResponse.ErrMessage}");

    PrintClients(clientService);
}

static void TestPets(GrpcChannel channel)
{
    var petService = new PetServiceClient(channel);

    var createPetResponse = petService.CreatePet(new CreatePetRequest
    {
        ClientId = 1,
        Name = "Шарик",
        Birthday = Timestamp.FromDateTime(new DateTime(2020, 01, 01).ToUniversalTime())
    }); 

    Console.WriteLine($"Pet ({createPetResponse.PetId}) created successfully.");


    var updatePetResponse = petService.UpdatePet(new UpdatePetRequest
    {
        PetId = createPetResponse.PetId.Value,
        ClientId = 1,
        Name = $"Шарик_{Random.Shared.Next(1, 1000)}",
        Birthday = Timestamp.FromDateTime(new DateTime(2020, 01, 02).ToUniversalTime())
    });

    if (updatePetResponse.ErrCode == 0)
        Console.WriteLine($"Pet ({createPetResponse.PetId}) updated successfully.");
    else
        Console.WriteLine($"Pet update error code {updatePetResponse.ErrCode}:\r\n\t with error: {updatePetResponse.ErrMessage}");

    PrintPets(petService, 1);

    var deletePetResponse = petService.DeletePet(new DeletePetRequest
    {
         PetId = createPetResponse.PetId.Value
    });

    if (deletePetResponse.ErrCode == 0)
        Console.WriteLine($"Pet ({createPetResponse.PetId}) deleted successfully.");
    else
        Console.WriteLine($"Pet update error code {deletePetResponse.ErrCode}:\r\n\t with error: {deletePetResponse.ErrMessage}");

    PrintPets(petService, 1);
}

static void PrintClients(ClientServiceClient clientService)
{
    var getClientsResponse = clientService.GetClients(new ClientServiceProtos.GetClientsRequest());
    if (getClientsResponse.ErrCode == 0)
    {
        Console.WriteLine("Clients:");
        Console.WriteLine("========\n");
        foreach (var clientDto in getClientsResponse.Clients)
        {
            Console.WriteLine($"({clientDto.ClientId}/{clientDto.Document}) {clientDto.Surname} {clientDto.FirstName} {clientDto.Patronymic}");
        }
    }
}

static void PrintPets(PetServiceClient petService, int clientId)
{
    var getClientPetsResponse = petService.GetClientPets(new GetPetsRequest() { ClientId = clientId});
    if (getClientPetsResponse.ErrCode == 0)
    {
        Console.WriteLine($"Client ({clientId}) pets:");
        Console.WriteLine("========\n");
        foreach (var item in getClientPetsResponse.Pets)
        {
            Console.WriteLine($"({item.PetId}/) {item.Name} {item.Birthday.ToDateTime()}");
        }
    }
}