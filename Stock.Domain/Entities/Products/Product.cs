using Stock.Domain.Entities.Shared;
using Stock.Domain.Entities.Stores;

namespace Stock.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public IList<Store> Stores { get; set; }
    }
}
