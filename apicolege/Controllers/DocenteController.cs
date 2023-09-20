using apicolege.Data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apicolege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly IDocenteRepositorio _docenteRepositorio;

        public DocenteController(IDocenteRepositorio docenteRepositorio)
        {
            _docenteRepositorio = docenteRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEstudiante()
        {
            return Ok(await _docenteRepositorio.GetAllDocente());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocenteDetails(int id)
        {
            return Ok(await _docenteRepositorio.GetDetails(id));
        }
    }
}
