using Stock.Domain.Entities.ProductStores;
using Stock.Domain.Entities.Shared;

namespace Stock.Domain.Entities.Stores
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductStore> ProductStores { get; set; }
    }
}
