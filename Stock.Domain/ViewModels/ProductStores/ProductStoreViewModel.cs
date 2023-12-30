using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.Stores;

namespace Stock.Domain.ViewModels.Purchase
{
    public class ProductStoreViewModel
    {
        public long SelectedStoreId { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<StoreViewModel> Stores { get; set; }

    }
}
