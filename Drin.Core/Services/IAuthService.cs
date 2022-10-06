using Drin.Core.DTOs;
using Drin.Core.Entities;
using Drin.Core.Utilities.Security.JWT;

namespace Drin.Core.Services
{
    public interface IAuthService
    {
        void Register(UserRegistrationDTO userRegistrationDTO, string pasword);
        void Login(UserRegistrationDTO userRegistrationDTO);
        void Logout(UserRegistrationDTO userRegistrationDTO);
        bool UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
