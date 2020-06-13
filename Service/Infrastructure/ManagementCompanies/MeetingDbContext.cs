using Domain.ManagementCompanies;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ManagementCompanies
{
    public sealed class MeetingDbContext : DbContext
    {
        public MeetingDbContext(DbContextOptions<MeetingDbContext> options) : base(options)
        { }

        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Meeting>(m =>
            {
                m.ToTable("Meeting");
                m.HasKey(m => m.MeetingId);
            });
        }
    }
}
