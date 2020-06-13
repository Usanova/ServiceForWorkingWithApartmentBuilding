using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.ManagementCompanies
{
    public interface IMeetingService
    {
        Task<Meeting> Get(Guid ownerId, CancellationToken cancellationToken);
    }
}
