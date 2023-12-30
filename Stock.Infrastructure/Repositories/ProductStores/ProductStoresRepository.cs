using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities.ProductStores;
using Stock.Domain.Interfaces.Repositories.ProductStores;
using Stock.Infrastructure.Repositories.Shared;

namespace Stock.Infrastructure.Repositories.ProductStores
{
    public class ProductStoresRepository : GenericRepository<ProductStore>, IProductStoresRepository
    {
        public ProductStoresRepository(DbContext context) : base(context)
        {
        }
    }
}
