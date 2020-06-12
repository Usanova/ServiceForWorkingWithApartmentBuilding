﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Polls
{
    public interface ITenantService
    {
        Task<IEnumerable<Tenant>> GetTenantsByBuilding(Guid buildingId, CancellationToken cancellationToken);
    }
}
