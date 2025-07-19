using Microsoft.EntityFrameworkCore;
using ApiEstudiantes.Models;
using Microsoft.Extensions.Options;
namespace ApiEstudiantes.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        
        public DbSet<Estudiante> Estudiante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .HasIndex(e => e.Matricula)
                .IsUnique();
          
            modelBuilder.Entity<Estudiante>()
                .Property(e => e.FechaCreado)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Estudiante>()
               .Property(e => e.FechaModificado)
               .HasDefaultValueSql("GETDATE()");
        }

    }

}
