using System;

namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime TimeStampUtc { get; private set; }

        protected DomainEvent()
        {
            this.TimeStampUtc = DateTimeProvider.UtcNow;
        }
    }
}
