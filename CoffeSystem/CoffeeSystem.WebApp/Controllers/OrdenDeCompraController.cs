using Microsoft.AspNetCore.Mvc;

namespace CoffeeSystem.WebApp.Controllers
{
    public class OrdenDeCompraController : Controller
    {
        public IActionResult NuevaOrdenDeCompra()
        {
            return View();
        }

        public IActionResult ListarOrdenDeCompra()
        {
            return View();
        }
    }
}
