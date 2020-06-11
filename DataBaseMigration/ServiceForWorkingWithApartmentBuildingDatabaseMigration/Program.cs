using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceForWorkingWithApartmentBuildingDatabaseMigration.Extensions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.AddEnvironmentVariables(prefix: "DOTNET_");
                })
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp
                        .AddJsonFile("appsettings.json", optional: true)
                        .AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args);

                })
                .ConfigureServices((hostContext, services) => ConfigureServices(services, hostContext.Configuration))
                .UseConsoleLifetime()
                .Build();

            await host.RunAsync();
        }

        internal static void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ServiceDbContext>(options =>
            {
                options.UseNpgsql(ConnectionStringExtensions.AppendApplicationName(
                    configuration.GetConnectionString("ServiceForWorkingWithApartmentBuilding")));
            });

            serviceCollection.AddHostedService<MigrationsBackgroundService>();
        }
    }
}
