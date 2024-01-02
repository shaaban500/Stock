using Stock.Domain.Interfaces.Repositories.Products;
using Stock.Domain.Interfaces.Repositories.ProductStores;
using Stock.Domain.Interfaces.Repositories.Stores;

namespace Stock.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStoresRepository Stores { get; }
        IProductsRepository Products { get; }
        IProductStoresRepository ProductStores { get; }

        void Save();
        Task<int> SaveAsync();
    }
}
