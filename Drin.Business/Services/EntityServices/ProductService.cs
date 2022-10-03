using Drin.Core.Entities;
using Drin.Core.Repositories;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;

namespace Drin.Business.Services.EntityServices
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
