using Domain.ManagementCompanies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ManagementCompanies.Query
{
    public sealed class GetManagementCompanyProfileViewById
    {
        private readonly IManagementCompanyRepository repository;
        private readonly IMeetingService meetingService;

        public GetManagementCompanyProfileViewById(IManagementCompanyRepository repository,
            IMeetingService meetingService)
        {
            this.repository = repository;
            this.meetingService = meetingService;
        }

        public async Task<ManagementCompanyProfileView> Handler(Guid managementCompanyId, CancellationToken cancellationToken)
        {
            var managementCompany = await repository.Get(managementCompanyId, cancellationToken);

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
