using back.Business.Entities;
using back.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Data
{
    public class ArtigoDbContext : DbContext
    {
        private DbContextOptionsBuilder<ArtigoDbContext> options;

        public ArtigoDbContext(DbContextOptions<ArtigoDbContext> options) :base(options)
        {

        }

        public ArtigoDbContext(DbContextOptionsBuilder<ArtigoDbContext> options)
        {
            this.options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new CategoriaMapping());
            modelBuilder.ApplyConfiguration(new ArtigoMapping());
            modelBuilder.ApplyConfiguration(new ImagensMapping());
            modelBuilder.ApplyConfiguration(new SubcategoriaMapping());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Artigo> Artigo { get; set; }
    }
}