using Drin.Core.Repositories.EntityRepositories;

namespace Drin.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }

        Task CommitAsync();
        void Commit();
    }
}
