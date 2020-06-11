using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes
{
    public sealed class AnswerOption
    {
        public Guid AnswerOptionId { get; private set; }

        public Guid PollId { get; private set; }

        public string Answer { get; private set; }

        public int VotersNumber { get; private set; }
    }
}
