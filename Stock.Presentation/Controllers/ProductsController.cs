using Microsoft.AspNetCore.Mvc;

namespace Stock.Presentation.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
