using Domain.Polls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Polls
{
    public sealed class PollRepository : IPollRepository
    {
        private readonly PollDbContext context;
        public PollRepository(PollDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Poll>> GetPollsByTenantId(Guid tenatId, CancellationToken cancellationToken)
        {
            var pollTenants = context.PollTenant
                .Where(at => at.TenantId == tenatId)
                .Select(at => at.PollId);

            return await context.Polls
                .Where(a => pollTenants.Contains(a.PollId))
                .ToListAsync(cancellationToken);
        }

        public async Task Save(Poll poll, CancellationToken cancellationToken)
        {
            if (context.Entry(poll).State == EntityState.Detached)
                context.Polls.Add(poll);

            await context.SaveChangesAsync();
        }

        public async Task<Poll> GetWithAnswerOptions(Guid pollId, CancellationToken cancellationToken)
        {
            return await context.Polls
                 .Include(p => p.AnswerOption)
                 .SingleOrDefaultAsync(p => p.PollId == pollId, cancellationToken);                 
        }
    }
}
