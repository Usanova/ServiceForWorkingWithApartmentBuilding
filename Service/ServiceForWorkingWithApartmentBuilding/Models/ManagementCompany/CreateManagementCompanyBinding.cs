using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Models.ManagementCompany
{
    public class CreateManagementCompanyBinding
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public string Password { get; set; }

        public IFormFile Avatar { get; set; }
    }

    public sealed class CreateTenatBindingValidation : AbstractValidator<CreateManagementCompanyBinding>
    {
        public CreateTenatBindingValidation()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
        }
    }
}
