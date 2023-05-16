using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Models.Responses;

namespace ClinicService.Services.Interfaces
{
    public interface IAuthenticateService
    {
        AuthenticationResponse Login(AuthenticationRequest authenticationRequest);

        public SessionInfo? GetSessionInfo(string sessionToken);
    }
}
