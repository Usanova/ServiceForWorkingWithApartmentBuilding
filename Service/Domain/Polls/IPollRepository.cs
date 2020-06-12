using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Polls
{
    public interface IPollRepository
    {
        Task<IEnumerable<Poll>> GetPollsByTenantId(Guid tenantId, CancellationToken cancellationToken);

        Task Save(Poll poll, CancellationToken cancellationToken);

        Task<Poll> GetWithAnswerOptions(Guid pollId, CancellationToken cancellationToken);

    }
}
