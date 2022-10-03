using Drin.Core.Entities;
using Drin.Core.Repositories;
using Drin.Core.Repositories.EntityRepositories;
using Drin.Core.Responses;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;

namespace Drin.Business.Services.EntityServices
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        //Mapper da eklenebilirdi ama gerek yok sanki serviceResponse döndüğümüz için
        public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork, 
            ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResponse> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);
            return ServiceResponse.Success(200, "Kategori başarı ile getirildi.", category);
        }
    }
}
