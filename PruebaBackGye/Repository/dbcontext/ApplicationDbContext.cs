using Microsoft.EntityFrameworkCore;
using PruebaBackGye.Models;

namespace PruebaBackGye.Repository.dbcontext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProductoDeseado> ProductosDeseados { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar las relaciones si es necesario
            modelBuilder.Entity<ProductoDeseado>()
                .HasKey(pd => new { pd.UsuarioId, pd.ProductoId });

            modelBuilder.Entity<ProductoDeseado>()
                .HasOne(pd => pd.Usuario)
                .WithMany(u => u.ProductosDeseados)
                .HasForeignKey(pd => pd.UsuarioId);

            modelBuilder.Entity<ProductoDeseado>()
                .HasOne(pd => pd.Producto)
                .WithMany()
                .HasForeignKey(pd => pd.ProductoId);
        }
    }
}
