using Domain.Announcements;
using Infrastructure.Announcements.Query;
using Microsoft.AspNetCore.Mvc;
using ServiceForWorkingWithApartmentBuilding.Models.Announcement;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public class AnnouncementController : Controller
    {
        [HttpPost("/announcement/buildings/{buildingId}")]
        public async Task<IActionResult> CreateAnnouncementByBuildingId(CancellationToken cancellationToken,
            [FromRoute] Guid buildingId,
            [FromBody] CreateAnnouncementBinding binding,
            [FromServices] AnnouncementManager mananger)
        {
            await mananger.CreateByBuilding(binding.Title, binding.Content, buildingId, cancellationToken);

            return Ok();
        }


        [HttpGet("/announcement/tenants/{tenantId}")]
        public async Task<IActionResult> GetAnnouncementsForTenant(CancellationToken cancellationToken,
            [FromRoute] Guid tenantId,
            [FromServices] GetListAnnouncement getListAnnouncement,
            [FromQuery] int? offset = 0,
            [FromQuery] int? count = 10)
        {
            return Ok(await getListAnnouncement.Handler(tenantId, offset.Value, count.Value, cancellationToken));
        }
    }
}
