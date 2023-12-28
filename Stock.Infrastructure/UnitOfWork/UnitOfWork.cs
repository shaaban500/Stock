using Stock.Domain.Interfaces.Repositories.Products;
using Stock.Domain.Interfaces.Repositories.Stores;
using Stock.Domain.Interfaces.UnitOfWork;
using Stock.Infrastructure.Contexts;
using Stock.Infrastructure.Repositories.Products;
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

        public IStoresRepository _storesRepository;
        public IProductsRepository _productsRepository;

        public IStoresRepository Stores => _storesRepository ?? new StoresRepository(_context);
        public IProductsRepository Products => _productsRepository ?? new ProductsRepository(_context);


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
