using apicolege.Data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apicolege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteControlador : ControllerBase
    {
        private readonly IEstudianteRepositorio _estudianteRepositorio;

        public EstudianteControlador(IEstudianteRepositorio estudianteRepositorio)
        {
            _estudianteRepositorio = estudianteRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEstudiante()
        {
            return Ok(await _estudianteRepositorio.GetAllEstudiante());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstudianteDetails(int id)
        {
            return Ok(await _estudianteRepositorio.GetEstudianteDetails(id));
        }
    }
}
