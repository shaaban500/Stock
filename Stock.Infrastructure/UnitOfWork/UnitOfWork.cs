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


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
