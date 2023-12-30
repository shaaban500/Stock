using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.Stores;

namespace Stock.Domain.ViewModels.ProductStores
{
    public class AddProductStoreViewModel
    {
        public long OldQuantity { get; set; }
        public long NewQuantity { get; set; }
        public long SelectedStoreId { get; set; }
        public long SelectedProductId { get; set; }

        public List<ProductViewModel> Products { get; set; }
        public List<StoreViewModel> Stores { get; set; }
    }
}
