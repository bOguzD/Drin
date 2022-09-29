using Drin.Core.UnitOfWorks;

namespace Drin.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DrinDbContext context;

        public UnitOfWork(DrinDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
