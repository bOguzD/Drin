using Drin.Core.UnitOfWorks;

namespace Drin.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DrinDbContext _context;

        public UnitOfWork(DrinDbContext context)
        {
            _context = context;
        }

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
