using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Polls
{
    public sealed class PollManager
    {
        private readonly IPollRepository repository;
        private readonly ITenantService tenantService;

        public PollManager(IPollRepository repository, ITenantService tenantService)
        {
            this.repository = repository;
            this.tenantService = tenantService;
        }

        public async Task CreateByBuilding(string question, IEnumerable<string> answers, Guid owner,
            Guid buildingId,
            CancellationToken cancellationToken)
        {
            var poll = new Poll(question, owner);

            foreach (var answer in answers)
                poll.AddAnswer(answer);

            var tenants = await tenantService.GetTenantsByBuilding(buildingId, cancellationToken);

            foreach (var tenant in tenants)
                poll.AddTenant(tenant.TenantId);

            await repository.Save(poll, cancellationToken);
        }
    }
}
