using Microsoft.AspNetCore.Mvc;

namespace CoffeeSystem.WebApp.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
