using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.Stores;

namespace Stock.Domain.ViewModels.Purchase
{
    public class GetAllProductStoreViewModel
    {
        public GetAllProductStoreViewModel()
        {
            Stores = new List<StoreViewModel>();
            Products = new List<ProductViewModel>();
        }

        public long SelectedStoreId { get; set; }
        public StoreViewModel SelectedStore { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<StoreViewModel> Stores { get; set; }
    }
}
