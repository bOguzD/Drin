using Drin.Core.Entities;
using System.Reflection.Metadata;

namespace Drin.Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
