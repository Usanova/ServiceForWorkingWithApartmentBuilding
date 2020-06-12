using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Polls.Query
{
    public sealed class AnswerOptionReference
    {
        public Guid AnswerOptionId { get; set; }
             
        public string Answer { get; set; }

        public int VotersNumber { get; set; }
    }
}
