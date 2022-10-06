using Drin.Core.Entities;
using Drin.Core.Repositories.EntityRepositories;

namespace Drin.Data.Repositories.EntityRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DrinDbContext context) : base(context)
        {

        }
    }
}
