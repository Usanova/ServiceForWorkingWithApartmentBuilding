using Domain.Polls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Polls
{
    public sealed class PollDbContext : DbContext
    {
        public PollDbContext(DbContextOptions<PollDbContext> options) : base(options)
        { }

        internal DbSet<Poll> Polls { get; set; }

        internal DbSet<PollTenant> PollTenant { get; set; }

        internal DbSet<AnswerOption> AnswerOption { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnswerOption>(builder =>
            {
                builder.ToTable("AnswerOption");
                builder.HasKey(a => a.AnswerOptionId);
            });

            modelBuilder.Entity<Poll>(builder =>
            {
                builder.ToTable("Poll");
                builder.HasKey(a => a.PollId);
                builder.Property(a => a.State).HasConversion<string>().HasMaxLength(64);
            });

            modelBuilder.Entity<PollTenant>(builder =>
            {
                builder.ToTable("PollTenant");
                builder.HasKey(a => a.PollTenantId);
            });
        }
    }
}
