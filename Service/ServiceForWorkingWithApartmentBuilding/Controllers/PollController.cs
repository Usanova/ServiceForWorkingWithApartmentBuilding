using Infrastructure.Polls.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public class PollController: Controller
    {
        [HttpGet("/polls")]
        public async Task<IActionResult> GetPolls(CancellationToken cancellationToken,
            [FromRoute] Guid tenantId,
            [FromServices] GetListPoll getListPoll)
        {
            //return Ok(await getListPoll.Handler(tenantId, cancellationToken));
            return Ok();
        }

        [HttpGet("/polls/{pollId}")]
        public async Task<IActionResult> GetAnswerOption(CancellationToken cancellationToken,
            [FromRoute] Guid pollId,
            [FromServices] GetListAnswerOption getListAnswerOption)
        {
            return Ok(await getListAnswerOption.Handler(pollId, cancellationToken));
        }
    }
}
