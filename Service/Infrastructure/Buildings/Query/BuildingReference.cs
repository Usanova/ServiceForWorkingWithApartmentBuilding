﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Buildings.Query
{
    public sealed class BuildingReference
    {
        public Guid ManagementCompanyId { get; set; }

        public string Address { get; set; }
    }
}
