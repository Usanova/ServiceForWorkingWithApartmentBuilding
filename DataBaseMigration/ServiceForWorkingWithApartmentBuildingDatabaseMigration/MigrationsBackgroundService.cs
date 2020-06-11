using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration
{
    internal sealed class MigrationsBackgroundService : BackgroundService
    {
        private readonly ServiceDbContext _context;

        public MigrationsBackgroundService(ServiceDbContext context)
        {
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting migrations...");

            try
            {
                await Policy
                    .Handle<SocketException>()
                    .WaitAndRetryAsync(10,
                        (tryNumber) => TimeSpan.FromSeconds(tryNumber),
                        (ex, delayTime) => Console.WriteLine($"Connection to database server failed. Try after {delayTime.Seconds} seconds"))
                    .ExecuteAsync(async (cancellationToken) => await _context.Database.MigrateAsync(cancellationToken), stoppingToken);

                Console.WriteLine("Migrations ended. Awaiting cancel...");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Migrations were fail " + ex.Message);
            }
        }
    }
}
