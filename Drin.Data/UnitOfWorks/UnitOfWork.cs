using Drin.Core.Repositories.EntityRepositories;
using Drin.Core.UnitOfWorks;
using Drin.Data.Repositories.EntityRepositories;

namespace Drin.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DrinDbContext _context;
        private ProductRepository? _productRepository;

        public UnitOfWork(DrinDbContext context)
        {
            _context = context;
        }
        public IProductRepository Product => _productRepository = _productRepository ?? new ProductRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
