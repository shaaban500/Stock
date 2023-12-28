using Stock.Domain.Entities.Products;
using Stock.Domain.Entities.Shared;

namespace Stock.Domain.Entities.Stores
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
