using Domain.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Polls.Query
{
    public sealed class GetListPollForTenant
    {
        private readonly IPollRepository repository;

        public GetListPollForTenant(IPollRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PollReference>> Handler(Guid tenantId, CancellationToken cancellationToken)
        {
            return (await repository.GetPollsByTenantId(tenantId, cancellationToken))
                .Select(a => new PollReference()
                {
                    PollId = a.PollId,
                    Question = a.Question
                });
        }
    }
}
