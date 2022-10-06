using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace Drin.Core.Extensions
{
    public static class ClaimExtension
    {
        public static void AddNameIdentifier(this ICollection<Claim> claims, string identifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, identifier));
        }
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

    }
}
