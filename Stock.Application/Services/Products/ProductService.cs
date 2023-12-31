using AutoMapper;
using NToastNotify;
using Stock.Domain.Entities.Products;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.Interfaces.UnitOfWork;
using Stock.Domain.ViewModels.Products;

namespace Stock.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IToastNotification _toastr;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toastr)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _toastr = toastr;
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
                _toastr.AddSuccessToastMessage("Added Successfully..");
            }
            else
            {
                var product = await _unitOfWork.Products.UpdateAsync(productToAdd);
                _toastr.AddSuccessToastMessage("Updated Successfully..");
            }
        }


        public async Task Delete(long id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(x => x.Id == id);

            if (product is not null)
            {
                await _unitOfWork.Products.DeleteAsync(product);
                _toastr.AddSuccessToastMessage("Deleted Successfully..");
                return;
            }
            
            _toastr.AddErrorToastMessage("no product found!!");
        }
    }
}
