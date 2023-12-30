using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.Purchase;

namespace Stock.Domain.Interfaces.Services.Products
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProductsByStoreId(long storeId);
        Task<ProductViewModel> GetById(long id = 0);
        Task<List<ProductViewModel>> GetAll();
        Task AddOrEdit(ProductViewModel model);
        Task Delete(long id);
    }
}
