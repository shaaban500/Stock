using Stock.Domain.Interfaces.Repositories.Products;
using Stock.Domain.Interfaces.Repositories.Stores;

namespace Stock.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStoresRepository Stores { get; }
        IProductsRepository Products { get; }
    }
}
