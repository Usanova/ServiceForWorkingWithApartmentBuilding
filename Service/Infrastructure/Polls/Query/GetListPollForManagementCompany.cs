using Domain.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Polls.Query
{
    public sealed class GetListPollForManagementCompany
    {
        private readonly IPollRepository repository;

        public GetListPollForManagementCompany(IPollRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PollReference>> Handler(Guid managementCompany,
            CancellationToken cancellationToken)
        {
            return (await repository.GetPollsByManagementCompanyId(managementCompany, cancellationToken))
                .Select(a => new PollReference()
                {
                    PollId = a.PollId,
                    Question = a.Question
                });
        }
    }
}
