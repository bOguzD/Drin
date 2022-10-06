using Drin.Core.Entities;
using Drin.Core.Repositories;
using Drin.Core.Repositories.EntityRepositories;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;

namespace Drin.Business.Services.EntityServices
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork,
            IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }
    }
}
