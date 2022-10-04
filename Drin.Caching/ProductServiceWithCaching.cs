using AutoMapper;
using Drin.Business.Exceptions;
using Drin.Core.Entities;
using Drin.Core.Repositories.EntityRepositories;
using Drin.Core.Responses;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Drin.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        //In-Memory Caching'de key value değeri tutulur
        private const string CacheProductKey = "productCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache,
            IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if(_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _repository.GetAll().ToList());
            }
        }

        public async Task AddAsync(Product entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Product> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> predicate)
        {
            return Task.FromResult(_memoryCache.Get<List<Product>>(CacheProductKey).Any(predicate.Compile()));
        }

        public async void Delete(Product entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
            await CacheAllProductAsync();
        }

        public async Task DeleteAsync(Product entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();

        }

        public async Task DeleteRangeAsync(IEnumerable<Product> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var entity = _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);

            if (entity == null)
                throw new NotFoundExceptionHandler($"{typeof(Product).Name} (Id: {id}) not found");

            return Task.FromResult(entity);
        }

        public async Task<ServiceResponse> GetProductsWithCategory()
        {
            var productsWithCategory = await _repository.GetProductsWithCategory();
            if (productsWithCategory == null)
                ServiceResponse.Failure(500, "Bilgiler getirilemedi");

            return ServiceResponse.Success(200, null, productsWithCategory);
        }

        public async void Update(Product entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
            await CacheAllProductAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
        }

        public Task<IEnumerable<Product>> Where(Expression<Func<Product, bool>> predicate)
        {
            return (Task<IEnumerable<Product>>)_memoryCache.Get<IEnumerable<Product>>(CacheProductKey).Where(predicate.Compile());
        }

        public IQueryable<Product> WhereAsQueryable(Expression<Func<Product, bool>> predicate)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(predicate.Compile()).AsQueryable();
        }

        public async Task CacheAllProductAsync()
        {
            _memoryCache.Set(CacheProductKey, await _repository.GetAllAsync());
        }
    }
}
