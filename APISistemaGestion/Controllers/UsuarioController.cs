using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionData;
using SistemaGestionEntities.models;

namespace APISistemaGestion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet]

        public ActionResult<List<Usuario>> GetUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

    }
}
