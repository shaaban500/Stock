using Stock.Domain.Entities.ProductStores;
using Stock.Domain.Interfaces.Repositories.Shared;

namespace Stock.Domain.Interfaces.Repositories.ProductStores
{
    public interface IProductStoresRepository : IGenericRepository<ProductStore>
    {
    }
}
