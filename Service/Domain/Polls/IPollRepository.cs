using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Polls
{
    public interface IPollRepository
    {

        Task<Poll> Get(Guid pollId, CancellationToken cancellationToken);
        Task<IEnumerable<Poll>> GetPollsByTenantId(Guid tenantId, CancellationToken cancellationToken);

        Task<IEnumerable<Poll>> GetPollsByManagementCompanyId(Guid managementCompanyId,
            CancellationToken cancellationToken);

        Task Save(Poll poll, CancellationToken cancellationToken);

        Task<Poll> GetWithAnswerOptions(Guid pollId, CancellationToken cancellationToken);
    }
}
