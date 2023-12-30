using Stock.Domain.ViewModels.Products;

namespace Stock.Domain.Interfaces.Services.Products
{
    public interface IProductService
    {
        Task<ProductViewModel> GetById(long id = 0);
        Task<List<ProductViewModel>> GetAll();
        Task AddOrEdit(ProductViewModel model);
        Task Delete(long id);
    }
}
