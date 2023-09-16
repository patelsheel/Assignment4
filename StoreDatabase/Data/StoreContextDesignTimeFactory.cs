using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace StoreDatabase.Data
{
    public class StoreContextDesignTimeFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("StoreDB"));

            return new StoreContext(optionsBuilder.Options);


        }
    }
}

