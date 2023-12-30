using System.Linq.Expressions;
using AutoMapper;
using Stock.Domain.Entities.Products;
using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.Interfaces.UnitOfWork;
using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.Purchase;

namespace Stock.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> GetById(long id = 0)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public async Task AddOrEdit(ProductViewModel model)
        {
            var productToAdd = _mapper.Map<Product>(model);

            if (model.Id == 0)
            {
                var product = await _unitOfWork.Products.AddAsync(productToAdd);
            }
            else
            {
                var product = await _unitOfWork.Products.UpdateAsync(productToAdd);
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

        public Task<List<ProductViewModel>> GetProductsByStoreId(long storeId)
        {
            throw new NotImplementedException();
        }
    }
}
