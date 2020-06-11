using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;

namespace ServiceForWorkingWithApartmentBuilding.Models.Tenat
{
    public sealed class CreateTenantBinding
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public int EntranceNumber { get; set; }

        public int FlatNumber { get; set; }

        public IFormFile Avatar { get; set; }
    }

    public sealed class CreateTenatBindingValidation : AbstractValidator<CreateTenantBinding>
    {
        public CreateTenatBindingValidation()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Password).NotEmpty();
        }
    }
}
