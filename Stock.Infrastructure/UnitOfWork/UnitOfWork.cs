using Stock.Domain.Interfaces.Repositories.Products;
using Stock.Domain.Interfaces.Repositories.ProductStores;
using Stock.Domain.Interfaces.Repositories.Stores;
using Stock.Domain.Interfaces.UnitOfWork;
using Stock.Infrastructure.Contexts;
using Stock.Infrastructure.Repositories.Products;
using Stock.Infrastructure.Repositories.ProductStores;
using Stock.Infrastructure.Repositories.Stores;

namespace Stock.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        public UnitOfWork(AppDBContext context)
        {
            _context = context;
        }

        private IStoresRepository _storesRepository;
        private IProductsRepository _productsRepository;
        private IProductStoresRepository _productStoresRepository;

        public IStoresRepository Stores => _storesRepository ?? new StoresRepository(_context);
        public IProductsRepository Products => _productsRepository ?? new ProductsRepository(_context);
        public IProductStoresRepository ProductStores => _productStoresRepository ?? new ProductStoresRepository(_context);


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
