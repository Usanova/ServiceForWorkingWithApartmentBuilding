using Domain.Polls;
using Infrastructure.Polls.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using ServiceForWorkingWithApartmentBuilding.Models.Poll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceForWorkingWithApartmentBuilding.Controllers
{
    public class PollController: Controller
    {
        [HttpPost("/polls/buildings/{buildingId}")]
        public async Task<IActionResult> CreatePollByBuildingId(CancellationToken cancellationToken,
        [FromRoute] Guid buildingId,
        [FromBody] CreatePollBinding binding,
        [FromServices] PollManager mananger)
        {
            await mananger.CreateByBuilding(binding.Question, binding.Answers, binding.OwnerId, 
                buildingId, cancellationToken);

            return Ok();
        }

        [HttpGet("/polls/tenant/{tenantId}")]
        public async Task<IActionResult> GetPollsForTeant(CancellationToken cancellationToken,
            [FromRoute] Guid tenantId,
            [FromServices] GetListPollForTenant getListPollForTenant)
        {
            return Ok(await getListPollForTenant.Handler(tenantId, cancellationToken));
        }

        [HttpGet("/polls/managementCompany/{managementCompanyId}")]
        public async Task<IActionResult> GetPollsFromManagementCompany(CancellationToken cancellationToken,
        [FromRoute] Guid managementCompanyId,
        [FromServices] GetListPollForManagementCompany getListPollForManagementCompany)
        {
            return Ok(await getListPollForManagementCompany.Handler(managementCompanyId, cancellationToken));
        }

        [HttpGet("/polls/answers/{pollId}")]
        public async Task<IActionResult> GetAnswerOption(CancellationToken cancellationToken,
            [FromRoute] Guid pollId,
            [FromServices] GetListAnswerOption getListAnswerOption)
        {
            return Ok(await getListAnswerOption.Handler(pollId, cancellationToken));
        }

        [HttpPost("/polls/{pollId}/answer/{answerOptionId}")]
        public async Task<IActionResult> ToVoke(CancellationToken cancellationToken,
        [FromRoute] Guid pollId,
        [FromRoute] Guid answerOptionId,
        [FromServices] IPollRepository repository)
        {
            var poll = await repository.GetWithAnswerOptions(pollId, cancellationToken);

            poll.ToVote(answerOptionId);

            await repository.Save(poll, cancellationToken);

            return Ok();
        }

        [HttpDelete("/polls/{pollId}")]
        public async Task<IActionResult> Close(CancellationToken cancellationToken,
        [FromRoute] Guid pollId,
        [FromServices] IPollRepository repository)
        {
            var poll = await repository.Get(pollId, cancellationToken);

            poll.Close();

            await repository.Save(poll, cancellationToken);

            return Ok();
        }
    }
}
