using Drin.Business.Exceptions;
using Drin.Core.Repositories;
using Drin.Core.Services;
using Drin.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace Drin.Business.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
        }

        //public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        //{
        //    return _repository.GetAll(predicate);
        //}

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            if(entity == null)
                throw new NotFoundExceptionHandler($"{typeof(T).Name} (Id: {id}) not found");
            

            return entity;
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> WhereAsQueryable(Expression<Func<T, bool>> predicate)
        {
            return _repository.WhereAsQueryable(predicate);
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }
    }
}
