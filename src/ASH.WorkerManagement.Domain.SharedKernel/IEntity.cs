using System;

namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public interface IEntity
    {
        Guid EntityId { get; }
    }
}
