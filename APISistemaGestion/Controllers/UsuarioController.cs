using Microsoft.AspNetCore.Mvc;

namespace APISistemaGestion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
