namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public interface IRepository<TAggregateRoot>
        where TAggregateRoot : IAggregateRoot
    {
    }
}
