using apicolege.Data.repositorio;
using apicolege.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace apicolege.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignaturaController : ControllerBase
    {
        private readonly IAsignaturaRepositorio _colegioRepositorio;

        public AsignaturaController(IAsignaturaRepositorio colegioRepositorio)
        {
            _colegioRepositorio = colegioRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllcolegio()
        {
            return Ok(await _colegioRepositorio.GetAllAsignatura());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetColegioDetails(int id)
        {
            return Ok(await _colegioRepositorio.GetAsignaturaDetails(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateColegio( [FromBody]Asignatura asignatura)
        {
            if (asignatura == null)

                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState); 
            var created = await _colegioRepositorio.InsertcAsignatura(asignatura);
            return Created("created", created);
            
        }
        [HttpPut]
        public async Task<IActionResult> UpdateColegio([FromBody] Asignatura asignatura)
        {
            if (asignatura == null)

                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           await _colegioRepositorio.UpdateAsignatura(asignatura);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsignatura(int id)
        {
            await _colegioRepositorio.DeleteAsignatura(new Asignatura { Id =id});
            return NoContent();
            
        }

        [HttpPut]
        [Route("asignar_estudiante")]
        public async Task<IActionResult> AsignarEstudiante([FromBody] Inscrito asignatura)
        {
            if (asignatura == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _colegioRepositorio.InsertcInscrito(asignatura);
            return NoContent();
        }
    }
}



