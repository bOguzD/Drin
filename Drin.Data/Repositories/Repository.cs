using Drin.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Drin.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //Protected yaptık çünkü her repo oluştuğunda bir daha tanımlamamıza gerek kalmıyor
        protected readonly DrinDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DrinDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            //context.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            //Çektiği datayı memory'ye almasın diye AsNoTracking dedik
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public IQueryable<T> WhereAsQueryable(Expression<Func<T, bool>> predicate)
        {
 
            return _dbSet.Where(predicate);
        }
        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T,bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }
    }
}
