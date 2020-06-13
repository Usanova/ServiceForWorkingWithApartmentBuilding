using Domain.ManagementCompanies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ManagementCompanies
{
    public sealed class ManagementCompanyDbContext : DbContext
    {
        public ManagementCompanyDbContext(DbContextOptions<ManagementCompanyDbContext> options) : base(options)
        { }

        public DbSet<ManagementCompany> ManagementCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ManagementCompany>(m =>
            {
                m.ToTable("ManagementCompany");
                m.HasKey(m => m.ManagementCompanyId);
            });
        }
    }
}
