using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace InGazAPI.Data
{
    public class InGazDbContextFactory : IDesignTimeDbContextFactory<InGazDbContext>
    {
        public InGazDbContext CreateDbContext(string[] args)
        {
            // Load configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Get connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Create DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<InGazDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new InGazDbContext(optionsBuilder.Options);
        }
    }
}
