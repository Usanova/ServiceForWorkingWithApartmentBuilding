using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration
{
    public sealed class DesignTimeServiceDbContextFactory : IDesignTimeDbContextFactory<ServiceDbContext>
    {
        public ServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ServiceDbContext>();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ServiceForWorkingWithApartmentBuilding"));

            return new ServiceDbContext(optionsBuilder.Options);
        }
    }
}
