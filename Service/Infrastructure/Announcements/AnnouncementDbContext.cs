using Domain.Announcements;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Announcements
{
    public sealed class AnnouncementDbContext : DbContext
    {
        public AnnouncementDbContext(DbContextOptions<AnnouncementDbContext> options) : base(options)
        { }

        internal DbSet<Announcement> Announcements { get; set;}

        internal DbSet<AnnouncementTenant> AnnouncementTenant { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Announcement>(builder =>
            {
                builder.ToTable("Announcement");
                builder.HasKey(a => a.AnnouncementId);
            });

            modelBuilder.Entity<AnnouncementTenant>(builder =>
            {
                builder.ToTable("AnnouncementTenant");
                builder.HasKey(at => at.AnnouncementTenantId);
            });
        }
    }
}
