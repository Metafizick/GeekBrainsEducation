using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
                    return GenerateJwtTokeb(i);
                }
                i++;
            }
            return string.Empty;
        }
        public string GenerateJwtTokeb(int id)
        {
            JwtSecurityTokenHandler jwtSecurityTokenHandler= new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretCode);
        }
    }
}
