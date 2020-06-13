using Domain.ManagementCompanies;
using Domain.Tenats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using ServiceForWorkingWithApartmentBuilding.Models.ManagementCompany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.ManagementCompanies.Query;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public class ManagementCompanyController : Controller
    {
        [HttpPost("/LoginManagementCompany")]
        public async Task<IActionResult> LoginManagementCompany(CancellationToken cancellationToken,
            [FromBody] LoginManagementCompanyBinding binding,
            [FromServices] IManagementCompanyRepository repository)
        {
            var managementCompany = await repository.Get(binding.NameCompany, binding.Password, cancellationToken);
            if (managementCompany == null)
            {
                return BadRequest(new { errorText = "Invalid companyname or password." });
            }

            return await GetToken(managementCompany.ManagementCompanyId);
        }


        [HttpPost("/RegisterManagementCompany")]
        public async Task<IActionResult> RegisterManagementCompany(CancellationToken cancellationToken,
           [FromBody] CreateManagementCompanyBinding binding,
           [FromServices] IManagementCompanyRepository repository)
        {
            var managementCompany = await repository.Get(binding.Name, cancellationToken);
            if (managementCompany != null)
            {
                return BadRequest(new { errorText = "Компания с таким именем уже зарегистрирована." });
            }

            managementCompany = new ManagementCompany(binding.Name, binding.Password, binding.Info);

            if (binding.Avatar != null)
            {
                byte[] avatarData = null;

                using (var binaryReader = new BinaryReader(binding.Avatar.OpenReadStream()))
                {
                    avatarData = binaryReader.ReadBytes((int)binding.Avatar.Length);
                }

                managementCompany.PutAvatar(avatarData);
            }

            await repository.Save(managementCompany);

            return await GetToken(managementCompany.ManagementCompanyId);
        }

        private async Task<IActionResult> GetToken(Guid managementCompanyId)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, managementCompanyId.ToString())
                };
            var identity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                companyId = identity.Name
            };

            return Json(response);
        }

        [HttpGet("/managementCompany/profile/{managementCompanyName}")]
        public async Task<ActionResult> GetManagementCompanyProfile(CancellationToken cancellationToken,
            [FromRoute] string managementCompanyName,
            [FromServices] GetManagementCompanyProfileViewByName getManagementCompanyProfileView)
        {
            return Ok(await getManagementCompanyProfileView.Handler(managementCompanyName, cancellationToken));
        }

        [HttpGet("/managementCompany/profile/id/{managementCompanyId}")]
        public async Task<ActionResult> GetManagementCompanyProfile(CancellationToken cancellationToken,
            [FromRoute] Guid managementCompanyId,
            [FromServices] GetManagementCompanyProfileViewById getManagementCompanyProfileViewById)
        {
            return Ok(await getManagementCompanyProfileViewById.Handler(managementCompanyId, cancellationToken));
        }
    }
}
