using Microsoft.AspNetCore.Mvc;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.ViewModels.Purchase;

namespace Stock.Presentation.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly IStoresService _storeService;
        private readonly IProductService _productService;
        public PurchaseController(IStoresService storeService, IProductService productService)
        {
            _storeService = storeService;
            _productService = productService;
        }

        public async Task<IActionResult> GetAll(long storeId)
        {
            var purchaseViewModel = new PurchaseViewModel
            {
                SelectedStoreId = storeId,
                Stores = await _storeService.GetAll(),
                Products = await _productService.GetProductsByStoreId(storeId)
            };

            return View(purchaseViewModel);
        }


    }
}
