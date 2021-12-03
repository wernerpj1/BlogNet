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
            optionsBuilder.UseSqlServer("Server=localhost; Database= Blog; user = riddle; password = verni");
            ArtigoDbContext contexto = new ArtigoDbContext(optionsBuilder.Options);

            return contexto;
        }
    }
}
