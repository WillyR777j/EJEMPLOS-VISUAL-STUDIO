using ApiEstudiantes.DTOs;
using ApiEstudiantes.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace ApiEstudiantes.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<EstudiantesController> _logger;

        public EstudiantesController(ApplicationDbContext context, IMapper mapper, ILogger<EstudiantesController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteCreacionDTO>>> GetEstudiantes()
        {
            _logger.LogInformation("Obteniendo lista de estudiantes");
            try
            {
                var estudiantes = await _context.Estudiante.ToListAsync();
                var estudiantesDto = _mapper.Map<List<EstudianteCreacionDTO>>(estudiantes);
                return Ok(estudiantesDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estudiantes");
                return StatusCode(500, "Error interno del servidor");
               
            }            
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
        {
            try
            {
                var estudiante = await _context.Estudiante.FindAsync(id);

                if (estudiante == null)
                {
                    _logger.LogInformation("Estudiante no encontrado");
                }                    
                    return Ok(estudiante);              
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Estudiante no encontrado");
                return StatusCode(500, "Error interno del servidor");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Estudiante>> PostEstudiante(Estudiante estudiante)
        {
            _context.Estudiante.Add(estudiante);
            await _context.SaveChangesAsync();

            return Ok();

            //return CreatedAtAction(nameof(GetEstudiante), new { id = estudiante.Matricula }, estudiante);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstudiante(int id, Estudiante estudiante)
        {           

            _context.Entry(estudiante).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            _context.Estudiante.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
