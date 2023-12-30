using Stock.Domain.Entities.Products;
using Stock.Domain.Entities.Shared;
using Stock.Domain.Entities.Stores;

namespace Stock.Domain.Entities.ProductStores
{
    public class ProductStore : BaseEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public long StoreId { get; set; }
        public Store Store { get; set; }

        public long Quantity { get; set; }
    }
}
