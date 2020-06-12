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
                builder.HasKey(t => t.TenantId);
                builder.Property(t => t.Name).HasMaxLength(32);
                builder.Property(t => t.Surname).HasMaxLength(32);
                builder.Property(t => t.Password).HasMaxLength(64);
                builder.Property(t => t.DateOfBirth);
                builder.Property(t => t.BuildingId);
                builder.Property(t => t.EntranceNumber);
                builder.Property(t => t.FlatNumber);
                builder.Property(t => t.Avatar);
                builder.HasMany(t => t.AnnouncementTenant)
                    .WithOne()
                    .HasForeignKey(at => at.TenantId)
                    .HasPrincipalKey(t => t.TenantId);
                builder.HasMany(t => t.PollTenant)
                    .WithOne()
                    .HasForeignKey(pt => pt.TenantId)
                    .HasPrincipalKey(t => t.TenantId);
            });

            modelBuilder.Entity<ManagementCompany>(builder =>
            {
                builder.ToTable("ManagementCompany");
                builder.HasKey(mc => mc.ManagementCompanyId);
                builder.Property(mc => mc.Name).HasMaxLength(64);
                builder.HasMany(mc => mc.Buildings)
                    .WithOne()
                    .HasForeignKey(mc => mc.ManagementCompanyId)
                    .HasPrincipalKey(mc => mc.ManagementCompanyId);
            });

            modelBuilder.Entity<Building>(builder =>
            {
                builder.ToTable("Building");
                builder.HasKey(b => b.BuildingId);
                builder.Property(b => b.Address).HasMaxLength(64);
            });

            modelBuilder.Entity<Announcement>(builder =>
            {
                builder.ToTable("Announcement");
                builder.HasKey(a => a.AnnouncementId);
                builder.Property(a => a.Title).HasMaxLength(64);
                builder.Property(a => a.Content).HasMaxLength(1024);
                builder.HasMany(a => a.AnnouncementTenant)
                   .WithOne()
                   .HasForeignKey(at => at.AnnouncementId)
                   .HasPrincipalKey(a => a.AnnouncementId);
            });

            modelBuilder.Entity<AnnouncementTenant>(builder =>
            {
                builder.ToTable("AnnouncementTenant");
                builder.HasKey(at => new { at.TenantId, at.AnnouncementId });
            });

            modelBuilder.Entity<AnswerOption>(builder =>
            {
                builder.ToTable("AnswerOption");
                builder.HasKey(a => a.AnswerOptionId);
                builder.HasKey(a => a.PollId);
                builder.Property(a => a.Answer);
                builder.Property(a => a.VotersNumber);
            });

            modelBuilder.Entity<Poll>(builder =>
            {
                builder.ToTable("Poll");
                builder.HasKey(a => a.PollId);
                builder.Property(a => a.Question).HasMaxLength(64);
                builder.HasMany(a => a.AnswerOption)
                    .WithOne()
                    .HasForeignKey(pt => pt.PollId)
                    .HasPrincipalKey(a => a.PollId);
                builder.HasKey(a => a.OwnerId);
                builder.HasMany(a => a.PollTenat)
                   .WithOne()
                   .HasForeignKey(pt => pt.PollId)
                   .HasPrincipalKey(a => a.PollId);
            });

            modelBuilder.Entity<PollTenant>(builder =>
            {
                builder.ToTable("PollTenant");
                builder.HasKey(at => new { at.TenantId, at.PollId });
            });
        }
    }
}
