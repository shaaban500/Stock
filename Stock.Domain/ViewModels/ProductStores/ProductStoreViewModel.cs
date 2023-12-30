using Stock.Domain.Entities.Products;
using Stock.Domain.Entities.Stores;

namespace Stock.Domain.ViewModels.ProductStores
{
    public class ProductStoreViewModel
    {
        public long StoreId { get; set; }
        public long ProductId { get; set; }
    }
}
