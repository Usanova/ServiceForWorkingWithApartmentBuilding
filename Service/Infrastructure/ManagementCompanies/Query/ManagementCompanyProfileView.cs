using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.ManagementCompanies.Query
{
    public sealed class ManagementCompanyProfileView
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public string HasMeeting { get; set; }

        public byte[] Avatar { get; set; }
    }
}
