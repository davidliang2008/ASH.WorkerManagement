using System;

namespace ASH.WorkerManagement.Domain.SharedKernel
{
    public abstract class Entity : IEntity
    {
        private const int HASH_MULTIPLIER = 31;

        public Guid EntityId { get; private set; }

        protected Entity()
        {
            if (this.EntityId == default)
            {
                this.EntityId = Guid.NewGuid();
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null) || !(obj is Entity))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Entity other = (Entity)obj;
            return other.EntityId.Equals(this.EntityId);
        }

        public override int GetHashCode()
        {
            // GetType() returns runtime type of the instance
            var typeHashCode = this.GetType().GetHashCode();

            // XOR for random distribution. See:
            // https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
            return HASH_MULTIPLIER ^ (typeHashCode * this.EntityId.GetHashCode());
        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (ReferenceEquals(left, null))
                return ReferenceEquals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
