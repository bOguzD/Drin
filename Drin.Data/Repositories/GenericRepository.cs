using Drin.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Drin.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DrinDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(DrinDbContext context, DbSet<T> dbSet)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }
        public async Task<T> AddAsyncReturnEntity(T entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }

        public void Delete(T entity)
        {
            //context.Entry(entity).State = EntityState.Deleted;
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            //Çektiği datayı memory'ye almasın diye AsNoTracking dedik
            return dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => GetAllAsync());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);

            if (entity == null)
                throw new ArgumentNullException("Entity is null");

            return entity;
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }
    }
}
