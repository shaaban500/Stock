using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Services.Stores;
using Stock.Domain.ViewModels.Products;
using Stock.Domain.ViewModels.Stores;

namespace Stock.Presentation.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoresService _storesService;
        public StoresController(IStoresService storesService)
        {
            _storesService = storesService;
        }

        public async Task<IActionResult> GetAll()
        {
            var stores = await _storesService.GetAll();
            return View(nameof(GetAll), stores);
        }


        [HttpGet]
        public async Task<IActionResult> AddOrEdit(long id = 0)
        {
            if (id == 0)
            {
                return View(new StoreViewModel());
            }
            else
            {
                var storeViewModel = await _storesService.GetById(id);
                
                if (storeViewModel == null)
                {
                    return NotFound();
                }

                return View(storeViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(StoreViewModel model)
        {
            await _storesService.AddOrEdit(model);
            return RedirectToAction("GetAll", "Stores");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _storesService.Delete(id);
            
            return RedirectToAction(nameof(GetAll));
        }
    }
}
