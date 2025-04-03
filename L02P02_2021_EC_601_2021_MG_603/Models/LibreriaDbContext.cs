using Microsoft.EntityFrameworkCore;

namespace L02P02_2021_EC_601_2021_MG_603.Models
{
    public class LibreriaDbContext : DbContext
    {
        public LibreriaDbContext(DbContextOptions<LibreriaDbContext> options) : base(options) { }

        // Usamos los nombres exactos de las tablas
        public DbSet<autores> autores { get; set; }
        public DbSet<libros> libros { get; set; }
        public DbSet<comentarios_libros> comentarios_libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuramos los nombres de las tablas por si acaso
            modelBuilder.Entity<autores>().ToTable("autores");
            modelBuilder.Entity<libros>().ToTable("libros");
            modelBuilder.Entity<comentarios_libros>().ToTable("comentarios_libros");
        }
    }
}