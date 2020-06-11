using Infrastructure.Announcements.Query;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public class AnnouncementController : Controller
    {
        [HttpGet("/Announcement/{tenatId}")]
        public async Task<IActionResult> GetAnnouncements(CancellationToken cancellationToken,
            [FromRoute] Guid tenatId,
            [FromServices] GetListAnnouncement getListAnnouncement)
        {
            return Ok(await getListAnnouncement.Handler(tenatId, cancellationToken));
        }
    }
}
