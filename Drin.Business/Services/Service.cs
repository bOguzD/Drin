using Drin.Core.Repositories;
using Drin.Core.Services;
using Drin.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace Drin.Business.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> repository;
        private readonly IUnitOfWork unitOfWork;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T entity)
        {
            await repository.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }
        public async Task<T> AddAsyncReturnEntity(T entity)
        {
            await repository.AddAsync(entity);
            await unitOfWork.CommitAsync();
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await repository.AddRangeAsync(entities);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await repository.AnyAsync(predicate);
        }

        public async Task DeleteAsync(T entity)
        {
            repository.Delete(entity);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            repository.DeleteRange(entities);
            await unitOfWork.CommitAsync();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return repository.GetAll(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            repository.Update(entity);
            await unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return repository.Where(predicate);
        }
    }
}
