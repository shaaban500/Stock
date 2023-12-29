using Stock.Domain.Entities.Products;

namespace Stock.Domain.Interfaces.Services.Products
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task AddOrUpdate(Product model);
        Task Delete(long id);
    }
}
