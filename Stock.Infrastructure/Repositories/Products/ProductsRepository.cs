using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities.Products;
using Stock.Domain.Interfaces.Repositories.Products;
using Stock.Infrastructure.Repositories.Shared;

namespace Stock.Infrastructure.Repositories.Products
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(DbContext context) : base(context)
        {
        }
    }
}
