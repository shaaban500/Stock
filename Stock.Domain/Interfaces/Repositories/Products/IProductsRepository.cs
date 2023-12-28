using Stock.Domain.Entities.Products;
using Stock.Domain.Interfaces.Repositories.Shared;

namespace Stock.Domain.Interfaces.Repositories.Products
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
    }
}
