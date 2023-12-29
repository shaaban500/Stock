using Stock.Domain.Entities.Products;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.Interfaces.UnitOfWork;

namespace Stock.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.ToList();
        }

        public async Task AddOrUpdate(Product model)
        {
            if (model.Id == 0)
            {
                var product = await _unitOfWork.Products.AddAsync(model);
            }
            else
            {
                var product = await _unitOfWork.Products.UpdateAsync(model);
            }
        }

        public async Task Delete(long id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(x => x.Id == id);

            if (product is not null)
            {
                await _unitOfWork.Products.DeleteAsync(product);
            }
        }

    }
}
