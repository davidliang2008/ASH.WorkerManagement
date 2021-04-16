using System;

namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public interface IDomainEvent
    {
        DateTime TimeStampUtc { get; }
    }
}
