using Microsoft.AspNetCore.Mvc;

namespace APISistemaGestion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : Controller
    {

      
        public IActionResult Index()
        {
            return View();
        }
    }
}
