using Stock.Domain.Entities.Products;

namespace Stock.Domain.ViewModels.Products
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }
    }
}
