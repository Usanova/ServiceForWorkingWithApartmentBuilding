using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Polls
{
    public sealed class AnswerOption
    {
        public AnswerOption(string answer)
        {
            AnswerOptionId = Guid.NewGuid();
            Answer = answer;
            VotersNumber = 0;
        }

        public Guid AnswerOptionId { get; private set; }

        public Guid PollId { get; private set; }

        public string Answer { get; private set; }

        public int VotersNumber { get; private set; }

        public void ToVote()
        {
            VotersNumber++;
        }
    }
}
