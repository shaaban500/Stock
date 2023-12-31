using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.ProductStores;

namespace Stock.Domain.Interfaces.Services.ProductStores
{
    public interface IProductStoreService
    {
        Task Add(AddProductStoreViewModel viewModel);
        Task<List<ProductViewModel>> GetProductsByStoreId(long storeId);
        Task<long> GetQuantityById(long storeId, long productId);
    }
}
