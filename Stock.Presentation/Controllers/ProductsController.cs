using Microsoft.AspNetCore.Mvc;
using Stock.Domain.Interfaces.Services.Products;
using Stock.Domain.ViewModels.Products;

namespace Stock.Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return View(nameof(GetAll), products);
        }


        [HttpGet]
        public async Task<IActionResult> AddOrEdit(long id = 0)
        {
            if (id == 0)
            {
                return View(new ProductViewModel());
            }
            else
            {
                var productViewModel = await _productService.GetById(id);

                if (productViewModel == null)
                {
                    return NotFound();
                }

                return View(productViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(ProductViewModel model)
        {
            await _productService.AddOrEdit(model);
            return RedirectToAction("GetAll", "Products");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _productService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
