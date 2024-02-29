using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities.models;

namespace APISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        [HttpGet]

        public ActionResult<List<Producto>> GetUsuarios()
        {
            return ProductoService.ListarProductos();
        }
    }
}
