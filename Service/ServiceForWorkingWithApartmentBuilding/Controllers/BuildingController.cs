using Domain.Buildings;
using Infrastructure.Buildings.Query;
using Microsoft.AspNetCore.Mvc;
using ServiceForWorkingWithApartmentBuilding.Models.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public class BuildingController : Controller
    {
        [HttpPost("/building/{managementCompanyId}")]
        public async Task<ActionResult> CreateBuilding(CancellationToken cancellationToken,
           [FromRoute] Guid managementCompanyId,
           [FromBody] CreateBuildingBinding binding,
           [FromServices] IBuildingRepository repository)
        {
            var building = await repository.Get(binding.Address, managementCompanyId, cancellationToken);
            if (building != null)
                return Ok();

            building = await repository.Get(binding.Address, cancellationToken);
            if (building != null)
                return BadRequest("Данный адрес уже зарегистрирован у другой компании");

            building = new Building(managementCompanyId, binding.Address);

            await repository.Save(building, cancellationToken);

            return Ok();
        }

        [HttpGet("/building/{managementCompanyId}")]
        public async Task<IActionResult> GetBuildings(CancellationToken cancellationToken,
            [FromRoute] Guid managementCompanyId,
            [FromServices] GetListBuilding getListBuilding)
        {
            return Ok(await getListBuilding.Handler(managementCompanyId, cancellationToken));
        }
    }
}
