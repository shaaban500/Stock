using Microsoft.AspNetCore.Mvc;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.Interfaces.Services.ProductStores;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.ViewModels.ProductStores;
using Stock.Domain.ViewModels.Purchase;

namespace Stock.Presentation.Controllers
{
    public class ProductStoresController : Controller
    {
        private readonly IStoresService _storeService;
        private readonly IProductService _productService;
        private readonly IProductStoreService _productStoreService;
        public ProductStoresController(IStoresService storeService, IProductStoreService productStoreService, IProductService productService)
        {
            _storeService = storeService;
            _productStoreService = productStoreService;
            _productService = productService;
        }

        public async Task<IActionResult> GetAll(GetAllProductStoreViewModel model)
        {
            var productStoreViewModel = new GetAllProductStoreViewModel
            {
                SelectedStoreId = model.SelectedStoreId,
                Stores = await _storeService.GetAll(),
                SelectedStore = await _storeService.GetById(model.SelectedStoreId),
            };
            

            if(model.SelectedStoreId == 0)
            {
                return View(productStoreViewModel);
            }

            productStoreViewModel.Products = await _productStoreService.GetProductsByStoreId(model.SelectedStoreId);

            return View(productStoreViewModel);
        }



        [HttpGet]
        public async Task<IActionResult> AddOrEdit()
        {
            var addProductStoreViewModel = new AddProductStoreViewModel
            {
                Stores = await _storeService.GetAll(),
                Products = await _productService.GetAll(),
            };
            
            return View(addProductStoreViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddProductStoreViewModel model)
        {
            await _productStoreService.Add(model);
            return RedirectToAction("GetAll", "ProductStores", new GetAllProductStoreViewModel { SelectedStoreId = model.SelectedStoreId});
        }


        public async Task<IActionResult> GetQuantityById(long storeId, long productId)
        {
            var quantity = await _productStoreService.GetQuantityById(storeId, productId);
            return Ok(new {oldQuantity = quantity});
        }
    }
}
