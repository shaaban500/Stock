using Microsoft.AspNetCore.Mvc;
using Stock.Domain.Entities.Stores;
using Stock.Domain.Interfaces.Services.Stores;

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
            return View(stores);
        }


        public async Task<IActionResult> AddOrUpdate(Store model)
        {
            await _storesService.AddOrUpdate(model);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _storesService.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
