using back.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace back.Configurations
{
    public class DbFactoryContext : IDesignTimeDbContextFactory<ArtigoDbContext>
    {
       
        public ArtigoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArtigoDbContext>();
            optionsBuilder.UseSqlServer("Server=desktop-2dvh51e\\sqlexpress; Database= Blog; user= riddle; password = Deusminhavida2403");
            ArtigoDbContext contexto = new ArtigoDbContext(optionsBuilder.Options);

            return contexto;
        }
    }
}
