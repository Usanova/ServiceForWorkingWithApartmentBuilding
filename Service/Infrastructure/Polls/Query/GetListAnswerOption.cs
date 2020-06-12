using Domain.Polls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Polls.Query
{
    public sealed class GetListAnswerOption
    {
        private readonly IPollRepository repository;

        public GetListAnswerOption(IPollRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<AnswerOptionReference>> Handler(Guid pollId, CancellationToken cancellationToken)
        {
            var poll = await repository.GetWithAnswerOptions(pollId, cancellationToken);

            return poll.AnswerOption
                .Select(ao => new AnswerOptionReference 
                { 
                    AnswerOptionId = ao.AnswerOptionId,
                    Answer = ao.Answer,
                    VotersNumber = ao.VotersNumber
                });
        }
    }
}
