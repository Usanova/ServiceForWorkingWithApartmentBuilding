using Domain.Meetings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Meetings
{
    public sealed class BuildingDbContext: DbContext
    {
        public BuildingDbContext(DbContextOptions<BuildingDbContext> options) : base(options)
        { }
        internal DbSet<Building> Buildings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>(builder =>
            {
                builder.ToTable("Building");
                builder.HasKey(a => a.BuildingId);
            });
        }
    }
}
