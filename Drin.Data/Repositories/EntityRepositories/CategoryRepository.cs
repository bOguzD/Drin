using Drin.Core.Entities;
using Drin.Core.Repositories.EntityRepositories;
using Microsoft.EntityFrameworkCore;

namespace Drin.Data.Repositories.EntityRepositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DrinDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            //TODO: İkisi arasındaki farkı araştır. İkisi de Queryable
            var category = await _context.Category.Where(x => x.Id == categoryId).Include(x=>x.Products).SingleOrDefaultAsync();
            //var category = await _context.Category.Include(x => x.Products).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
            return category;
        }
    }
}
