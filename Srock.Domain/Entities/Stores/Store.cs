using Srock.Domain.Entities.Products;
using Srock.Domain.Entities.Shared;

namespace Srock.Domain.Entities.Stores
{
    public class Store : BaseEntity
    {
        public string Name { get; set; }
        public List<Product>  Products { get; set; }
    }
}
