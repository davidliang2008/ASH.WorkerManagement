using ASH.WorkerManagement.Domain.SharedKernel;

namespace ASH.WorkerManagement.Domain
{
    public class Worker : AggregateRoot
    {
        public WorkerType WorkerType { get; private set; }

        public FullName FullName { get; private set; }

        public Address Address { get; private set; }

        public PayRate PayRate { get; private set; }

        public double? MaxExpense { get; private set; }
    }
}
