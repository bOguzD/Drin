using Microsoft.IdentityModel.Tokens;

namespace Drin.Core.Utilities.Security.Encryption
{
    public class SignCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
