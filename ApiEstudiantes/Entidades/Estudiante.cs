using System.ComponentModel.DataAnnotations;

namespace ApiEstudiantes.Models
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Matricula { get; set; }= string.Empty;   
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public DateTime FechaCreado { get; set; }
        public DateTime FechaModificado { get; set; }
    }
}
