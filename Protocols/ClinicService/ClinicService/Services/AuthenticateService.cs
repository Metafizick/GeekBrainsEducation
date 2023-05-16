using ClinicService.Data;
using ClinicService.Helpers;
using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Models.Responses;
using ClinicService.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using NLog.Fluent;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicService.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        public const string SecretKey = "fwejk34432?fwef/fefFFE";
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly Dictionary<string, SessionInfo> _sessions = new Dictionary<string, SessionInfo>();

        public AuthenticateService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public SessionInfo? GetSessionInfo(string sessionToken)
        {
            SessionInfo? sessionInfo;

            lock (_sessions)
            {
                _sessions.TryGetValue(sessionToken, out sessionInfo);
            }

            if (sessionInfo == null)
            {
                using IServiceScope scope = _serviceScopeFactory.CreateScope();
                ClinicServiceDbContext db = scope.ServiceProvider.GetRequiredService<ClinicServiceDbContext>();

                var session = db.AccountSessions.FirstOrDefault(item => item.SessionToken == sessionToken);

                if (session == null)
                    return null;

                var account = db.Accounts.FirstOrDefault(item => item.AccountId == session.AccountId);

                if (account == null)
                    throw new KeyNotFoundException($"Не найден аккаунт ({session.AccountId})");

                sessionInfo = GetSessionInfo(account, session);

                if (sessionInfo != null)
                {
                    lock (_sessions)
                    {
                        _sessions[sessionToken] = sessionInfo;
                    }
                }
            }

            return sessionInfo;
        }

        public AuthenticationResponse Login(AuthenticationRequest authenticationRequest)
        {
            var scope = _serviceScopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ClinicServiceDbContext>();

            var account = !string.IsNullOrEmpty(authenticationRequest.Login)
                ? db.Accounts.FirstOrDefault(account => account.EMail == authenticationRequest.Login)
                : null;

            if (account is null)
                return new AuthenticationResponse() { Status = AuthenticationStatus.UserNotFound };

            if (!PasswordUtils.VirifyPassword(authenticationRequest.Password, account.PasswordSalt,account.PasswordHash))
                return new AuthenticationResponse() { Status = AuthenticationStatus.InvalidPassword };

            AccountSession session = new AccountSession
            {
                AccountId = account.AccountId,
                SessionToken = CreateSessionToken(account),
                TimeCreated = DateTime.Now,
                TimeLastRequest = DateTime.Now,
                IsClosed = false,
            };

            db.AccountSessions.Add(session);
            db.SaveChanges();

            SessionInfo sessionInfo = GetSessionInfo(account, session);

            lock (_sessions)
            {
                _sessions[sessionInfo.SessionToken] = sessionInfo;
            }


            return new AuthenticationResponse
            {
                Status = AuthenticationStatus.Success,
                SessionInfo = sessionInfo
            };
        }

        private SessionInfo GetSessionInfo(Account account, AccountSession accountSession)
        {
            return new SessionInfo
            {
                SessionId = accountSession.SessionId,
                SessionToken = accountSession.SessionToken,
                Account = new AccountDto
                {
                    AccountId = account.AccountId,
                    EMail = account.EMail,
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    SecondName = account.SecondName,
                    Locked = account.Locked
                }
            };
        }

        private string CreateSessionToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                    new Claim(ClaimTypes.Name, account.EMail)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
