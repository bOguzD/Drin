using Drin.Core.Entities;
using Drin.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drin.Core.Services.EntityServices
{
    public interface IUserService : IService<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
