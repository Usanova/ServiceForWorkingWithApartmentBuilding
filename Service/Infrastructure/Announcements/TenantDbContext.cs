using Domain.Announcements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Announcements
{
    public sealed class TenantDbContext :DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        { }

        internal DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>(builder =>
            {
                builder.ToTable("Tenant");
                builder.HasKey(a => a.TenantId);
            });
        }
    }
}
