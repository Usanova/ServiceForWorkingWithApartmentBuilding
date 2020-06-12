using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceForWorkingWithApartmentBuildingDatabaseMigration.Entytes
{
    public sealed class Poll
    {
        public Guid PollId { get; private set; }

        public string Question { get; private set; }

        public ICollection<AnswerOption> AnswerOption { get; private set; }

        public Guid OwnerId { get; private set; }

        public PollState State { get; private set; }

        public ICollection<PollTenant> PollTenat { get; private set; }

    }

    public enum PollState
    {
        Active,
        Deleted
    }
}
