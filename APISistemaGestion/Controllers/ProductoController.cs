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

        public ActionResult<List<Producto>> GetProductos()
        {
            return ProductoService.ListarProductos();
        }
    }
}
