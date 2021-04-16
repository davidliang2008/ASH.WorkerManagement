using System.Collections.Generic;

namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public interface IAggregateRoot : IEntity
    {
        IEnumerable<IDomainEvent> DomainEvents { get; }
        void AddEvent(IDomainEvent domainEvent);
        void ClearEvents();
    }
}
