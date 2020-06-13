using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingClient.Models
{
    public class CreateManagementCompanyBinding
    {
        public string Name { get; set; }

        public string Info { get; set; }

        public string Password { get; set; }

        public IFormFile Avatar { get; set; }
    }

    public sealed class CreateManagementCompanyBindingValidation : AbstractValidator<CreateManagementCompanyBinding>
    {
        public CreateManagementCompanyBindingValidation()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Password).NotEmpty();
        }
    }
}
