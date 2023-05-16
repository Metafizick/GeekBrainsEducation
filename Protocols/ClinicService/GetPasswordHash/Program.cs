using ClinicService.Helpers;

var hash = PasswordUtils.GetPasswordHash("123456", "fewfnwjkbvdjsnb");
Console.WriteLine(hash);
Console.ReadKey();