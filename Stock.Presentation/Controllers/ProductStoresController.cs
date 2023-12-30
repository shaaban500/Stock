using Microsoft.AspNetCore.Mvc;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.ViewModels.Purchase;

namespace Stock.Presentation.Controllers
{
    public class ProductStoresController : Controller
    {
        private readonly IStoresService _storeService;
        private readonly IProductService _productService;
        public ProductStoresController(IStoresService storeService, IProductService productService)
        {
            _storeService = storeService;
            _productService = productService;
        }

        public async Task<IActionResult> GetAll(long storeId)
        {
            var purchaseViewModel = new ProductStoreViewModel
            {
                SelectedStoreId = storeId,
                Stores = await _storeService.GetAll(),
                Products = await _productService.GetProductsByStoreId(storeId)
            };

            return View(purchaseViewModel);
        }


    }
}
