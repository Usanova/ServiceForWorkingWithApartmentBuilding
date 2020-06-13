using Domain.Meetings;
using Microsoft.AspNetCore.Mvc;
using ServiceForWorkingWithApartmentBuilding.Models.Meeting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public sealed class MeetingController : Controller
    {
        [HttpPost("/meetings/buindings/{buildingId}")]
        public async Task<ActionResult> OpenMeetingForBuilding(CancellationToken cancellationToken, 
            [FromRoute] Guid buildingId,
            [FromBody] CreateMeetingBinding binding,
            [FromServices] MeetingManager manager)
        {
            return Ok(await manager.OpenForBuilding(binding.Name, binding.OwnerId, buildingId, cancellationToken));
        }

        [HttpDelete("/meetings/buindings/{meetingId}")]
        public async Task<ActionResult> CloseMeetingForBuilding(CancellationToken cancellationToken,
            [FromRoute] Guid meetingId,
            [FromServices] MeetingManager manager)
        {
            await manager.Close(meetingId, cancellationToken);

            return Ok();
        }
    }
}
