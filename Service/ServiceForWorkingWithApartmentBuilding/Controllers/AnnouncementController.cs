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
        [HttpPost("/Announcement/{buildingId}")]
        public async Task<IActionResult> CreateAnnouncementByBuildingId(CancellationToken cancellationToken,
            [FromRoute] Guid buildingId,
            [System.Web.Http.FromBody] CreateAnnouncementBinding binding,
            [FromServices] AnnouncementManager mananger)
        {
            await mananger.Create(binding.Title, binding.Content, buildingId, cancellationToken);

            return Ok();
        }


        [HttpGet("/Announcement/{tenatId}")]
        public async Task<IActionResult> GetAnnouncements(CancellationToken cancellationToken,
            [FromRoute] Guid tenatId,
            [FromServices] GetListAnnouncement getListAnnouncement,
            [FromQuery] int? offset = 0,
            [FromQuery] int? count = 10)
        {
            return Ok(await getListAnnouncement.Handler(tenatId, offset.Value, count.Value, cancellationToken));
        }
    }
}
