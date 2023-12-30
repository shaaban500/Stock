using Stock.Domain.Entities.ProductStores;
using Stock.Domain.Entities.Shared;
using Stock.Domain.Entities.Stores;

namespace Stock.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductStore> ProductStores { get; set; }
    }
}
