using System.Collections.Generic;

namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly IList<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public IEnumerable<IDomainEvent> DomainEvents => _domainEvents;

        public void AddEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
