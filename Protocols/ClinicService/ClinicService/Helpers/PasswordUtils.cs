using System.Security.Cryptography;
using System.Text;

namespace ClinicService.Helpers;

public class PasswordUtils
{
    private const string secretKey = "dfDEFGKNhfuiwehfHFEFOKPOK242";


    public static bool VirifyPassword(string password, string salt, string hash) 
        =>  GetPasswordHash(password, salt) == hash; 
    
    public static string GetPasswordHash(string password, string salt)
    {
        var passwordText = $"{password}~{salt}~{secretKey}";
        var bytes = Encoding.UTF8.GetBytes(passwordText);

        var sha512 = SHA512.Create();
        var hash = sha512.ComputeHash(bytes);

        return Convert.ToBase64String(hash);
    }
}
