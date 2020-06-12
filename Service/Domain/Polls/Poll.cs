using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Domain.Polls
{
    public sealed class Poll
    {
        public Poll(string question, Guid ownerId)
        {
            PollId = Guid.NewGuid();
            Question = question;
            OwnerId = ownerId;
            State = PollState.Active;
            AnswerOption_ = new List<AnswerOption>();
            PollTenat_ = new List<PollTenant>();
        }

        public Guid PollId { get; private set; }

        public string Question { get; private set; }

        List<AnswerOption> AnswerOption_ { get; set; }

        public ICollection<AnswerOption> AnswerOption => AnswerOption_;

        public Guid OwnerId { get; private set; }

        public PollState State { get; private set; }

        List<PollTenant> PollTenat_ { get; set; }
        public ICollection<PollTenant> PollTenant => PollTenat_;

        public void AddAnswer(string answer)
        {
            AnswerOption_.Add(new AnswerOption(answer));
        }

        public void AddTenant(Guid tenant)
        {
            PollTenat_.Add(new PollTenant(tenant));
        }

        public void ToVote(Guid AnswerOptionId)
        {
            var answerOption = AnswerOption_.FirstOrDefault(ao => ao.AnswerOptionId == AnswerOptionId);
            answerOption.ToVote();
        }

        public void Close()
        {
            State = PollState.Deleted;
        }
    }

    public enum PollState
    {
        Active,
        Deleted
    }
}
