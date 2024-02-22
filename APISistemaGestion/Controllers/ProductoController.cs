using Microsoft.AspNetCore.Mvc;

namespace APISistemaGestion.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
