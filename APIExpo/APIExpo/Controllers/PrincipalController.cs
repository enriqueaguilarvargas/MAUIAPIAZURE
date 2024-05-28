using Microsoft.AspNetCore.Mvc;
namespace APIExpo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {
        [HttpGet("ConsultarRegistro")]
        public JsonResult Consultar(int ID)
        {
            var Consulta = new Consultas();
            var Lista = Consulta.ConsultaRegistro(ID);
            return new JsonResult(Lista);
        }
        [HttpGet("ConsultarTodo")]
        public JsonResult ConsultarTodo()
        {
            var Consulta = new Consultas();
            var Lista = Consulta.ConsultaTodo();
            return new JsonResult(Lista);
        }
    }
}
