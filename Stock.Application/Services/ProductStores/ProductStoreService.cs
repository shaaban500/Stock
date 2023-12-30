using AutoMapper;
using Stock.Domain.Interfaces.Services.ProductStores;
using Stock.Domain.Interfaces.UnitOfWork;
using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.ProductStores;

namespace Stock.Application.Services.ProductStores
{
    public class ProductStoreService : IProductStoreService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductStoreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(AddProductStoreViewModel viewModel)
        {
            var productStore = await _unitOfWork.ProductStores.GetByIdAsync(ps => ps.StoreId == viewModel.SelectedStoreId && ps.ProductId == viewModel.SelectedProductId);
            
            if (productStore == null)
                return;

            if(viewModel.NewQuantity > 0)
            {
                productStore.Quantity = viewModel.NewQuantity;
                await _unitOfWork.ProductStores.UpdateAsync(productStore);
            }
        }

        public async Task<List<ProductViewModel>> GetProductsByStoreId(long storeId)
        {
            var allProducts = await _unitOfWork.Products.GetAllAsync();
            var productsInStore = await _unitOfWork.ProductStores.GetAllAsync(x => x.StoreId == storeId, null, x => x.Product);

            var productsWithQuantities = allProducts.Select(product => new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Quantity = productsInStore.Any(ps => ps.ProductId == product.Id) ?
                           productsInStore.First(ps => ps.ProductId == product.Id).Quantity : 0,
            }).ToList();

            return productsWithQuantities;
        }

        public async Task<long> GetQuantityById(long storeId, long productId)
        {
            var productStore = await _unitOfWork.ProductStores.GetByIdAsync(ps => ps.StoreId == storeId && ps.ProductId == productId);
            return productStore == null ? 0 : productStore.Quantity;
        }
    }
}
