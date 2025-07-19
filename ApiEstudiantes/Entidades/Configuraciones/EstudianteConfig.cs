using ApiEstudiantes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ApiEstudiantes.Entidades.Configuraciones
{
    public class EstudianteConfig : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.Property(prop => prop.Id)
                .IsRequired()                
                .ValueGeneratedOnAdd();
            builder.Property(prop => prop.Matricula)
                .IsRequired()
                .HasMaxLength(14);
            builder.Property(prop => prop.Nombre)
                .IsRequired()
                .HasMaxLength(35);
            builder.Property(prop => prop.Apellido)
                .IsRequired()
                .HasMaxLength(35);
            builder.Property(prop => prop.Telefono)
               .IsRequired()
               .HasMaxLength(12);
            builder.Property(prop => prop.Direccion)
               .IsRequired()
               .HasMaxLength(49);            
        }
    }
}
