using Microsoft.EntityFrameworkCore;
using ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration
{
    public sealed class ServiceDbContext : DbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>(builder =>
            {
                builder.ToTable("Tenant");
                builder.HasKey(t => t.TenatId);
                builder.Property(t => t.Name).HasMaxLength(32);
                builder.Property(t => t.Surname).HasMaxLength(32);
                builder.Property(t => t.Password).HasMaxLength(64); ;
                builder.Property(t => t.DateOfBirth);
                builder.Property(t => t.BuildingId);
                builder.Property(t => t.EntranceNumber);
                builder.Property(t => t.FlatNumber);
                builder.Property(t => t.Avatar);
            });

            modelBuilder.Entity<ManagementCompany>(builder =>
            {
                builder.ToTable("ManagementCompany");
                builder.HasKey(mc => mc.ManagementCompanyId);
                builder.Property(mc => mc.Name).HasMaxLength(64);
                builder.HasMany(mc => mc.Buildings)
                    .WithOne()
                    .HasForeignKey(b => b.ManagementCompanyId)
                    .HasPrincipalKey(mc => mc.ManagementCompanyId);
            });

            modelBuilder.Entity<Building>(builder =>
            {
                builder.ToTable("Building");
                builder.HasKey(b => b.BuildingId);
                builder.Property(mc => mc.Address).HasMaxLength(64);
            });
        }
    }
}
