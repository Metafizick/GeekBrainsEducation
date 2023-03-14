using CardStorageService.Data;
using CardStorageService.Models;
using CardStorageService.Models.Requests;
using CardStorageService.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace CardStorageService.Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        #region Services
        private readonly IServiceScopeFactory _serviceScopeFactory;
        #endregion
        private readonly Dictionary<string, SessionInfo> _sessions = 
            new Dictionary<string, SessionInfo>();
        public AuthenticateService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public AuthenticationResponse Login(AuthenticationRequest authenticationRequest)
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();
            CardStorageServiceDbContext context = scope.ServiceProvider.GetRequiredService<CardStorageServiceDbContext>();

            Account account = 
                !string.IsNullOrWhiteSpace(authenticationRequest.Login) ? 
                FindAccountByLogin(context, authenticationRequest.Login) : null;
            if (account == null)
            {
                return new AuthenticationResponse
                {
                    Status = AuthenticationStatus.UserNotFound
                };
            }
            if (!PasswordUtils.VerifyPassword(authenticationRequest.Password, account.PasswordSalt, account.PasswordHash)) 
            {
                return new AuthenticationResponse 
                { 
                    Status = AuthenticationStatus.InvalidPassword 
                };
            }
        }
        private Account FindAccountByLogin(CardStorageServiceDbContext context, string login)
        {
            return context.Accounts.
                FirstOrDefault(account => account.EMail == login);
        }
        public SessionInfo GetSessionInfo(string sessionToken)
        {
            throw new NotImplementedException();
        }

        
    }
}
