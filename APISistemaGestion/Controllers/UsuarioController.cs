using Microsoft.AspNetCore.Mvc;

namespace APISistemaGestion.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
