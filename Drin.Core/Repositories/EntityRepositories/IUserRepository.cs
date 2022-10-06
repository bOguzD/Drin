using Drin.Core.Entities;

namespace Drin.Core.Repositories.EntityRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
