using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ManagementCompanies
{
    public sealed class ManagementCompany
    {
        public ManagementCompany(string name,
            string password,
            string info)
        {
            ManagementCompanyId = Guid.NewGuid();
            Name = name;
            Password = password;
            Info = info;
        }

        public void PutAvatar(byte[] avatar)
        {
            Avatar = avatar;
        }
        public Guid ManagementCompanyId { get; private set; }

        public string Name { get; private set; }

        public string Info { get; private set; }

        public byte[] Avatar { get; private set; }

        public string Password { get; private set; }
    }
}
