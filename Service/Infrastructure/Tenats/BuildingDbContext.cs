using Domain.Tenats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Infrastructure.Tenats
{
    public sealed class BuildingDbContext : DbContext
    {
        public BuildingDbContext(DbContextOptions<BuildingDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        internal DbSet<Building> Buildings { get; set; }

        internal DbSet<ManagementCompany> ManagementCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>(b =>
            {
                b.ToTable("Building");
                b.HasKey(b => b.BuildingId);
            });

            modelBuilder.Entity<ManagementCompany>(b =>
            {
                b.ToTable("ManagementCompany");
                b.HasKey(b => b.ManagementCompanyId);
            });
        }
    }

    public class ManagementCompany
    {
        public Guid ManagementCompanyId { get; private set; }

        public string Name { get; private set; }
    }
}
