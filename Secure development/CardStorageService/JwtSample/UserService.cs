using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JwtSample
{
    internal class UserService
    {
        private const string SecretCode = "XN32Z5{6y@t8j%TE#A";
        private IDictionary<string, string> _users = new Dictionary<string, string>()
        {
            {"root1", "test"},
            {"root2", "test"},
            {"root3", "test"},
            {"root4", "test"}
        };
        public string Authenticate(string user, string password)
        {
            if (string.IsNullOrEmpty(user) ||
                string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }
            int i = 0;
            foreach (KeyValuePair<string, string> pair in _users)
            {
                if (string.CompareOrdinal(pair.Key, user) == 0 &&
                    string.CompareOrdinal(pair.Value, password) == 0)
                {
                    return GenerateJwtToken(i);
                }
                i++;
            }
            return string.Empty;
        }
        public string GenerateJwtToken(int id)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);
            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor();
            securityTokenDescriptor.Expires = DateTime.UtcNow.AddMinutes(15);
            securityTokenDescriptor.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
            securityTokenDescriptor.Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.NameIdentifier, id.ToString())
            });

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}
