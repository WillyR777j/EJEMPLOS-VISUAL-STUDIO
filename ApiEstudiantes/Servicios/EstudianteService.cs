using ApiEstudiantes.Models;

namespace ApiEstudiantes.Servicios
{
    public class EstudianteService : IEstudianteService
    {
        public Estudiante CrearEstudiante(Estudiante estudiante)
        {
            estudiante.FechaCreado = DateTime.UtcNow;
            estudiante.FechaModificado = DateTime.UtcNow;
            return estudiante;
        }
    }
}
