using Domain.ManagementCompanies;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ManagementCompanies.Query
{
    public sealed class GetManagementCompanyProfileViewByName
    {
        private readonly IManagementCompanyRepository repository;
        private readonly IMeetingService meetingService;

        public GetManagementCompanyProfileViewByName(IManagementCompanyRepository repository,
            IMeetingService meetingService)
        {
            this.repository = repository;
            this.meetingService = meetingService;
        }

        public async Task<ManagementCompanyProfileView> Handler(string managementCompanyName, CancellationToken cancellationToken)
        {
            var managementCompany = await repository.Get(managementCompanyName, cancellationToken);

            var meetingId = await meetingService.Get(managementCompany.ManagementCompanyId, cancellationToken);

            return new ManagementCompanyProfileView()
            {
                Id = managementCompany.ManagementCompanyId,
                Name = managementCompany.Name,
                Info = managementCompany.Info,
                HasMeeting = meetingId == null ? null : meetingId.MeetingId.ToString(),
                Avatar = managementCompany.Avatar
            };
        }
    }
}
