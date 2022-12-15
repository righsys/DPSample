using System.ComponentModel.DataAnnotations.Schema;

namespace DPSample.SharedCore
{
    public abstract class EntityBase<EntityKey> : IEquatable<EntityBase<EntityKey>>
    {
        [NotMapped]
        public EntityKey Id { get; set; }
        //
        // Overrides and Operators
        //
        public bool Equals(EntityBase<EntityKey> otherEntity)
        {
            if (otherEntity is null)
                return false;
            if (otherEntity.GetType() != typeof(EntityBase<EntityKey>))
                return false;
            return true;
        }
        public static bool operator ==(EntityBase<EntityKey> left, EntityBase<EntityKey> right)
        {
            return EqualityComparer<EntityBase<EntityKey>>.Default.Equals(left, right);
        }
        public static bool operator !=(EntityBase<EntityKey> left, EntityBase<EntityKey> right)
        {
            return !(left == right);
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
                return false;
            if (obj.GetType() != typeof(EntityBase<EntityKey>))
                return false;
            if (obj is not EntityBase<EntityKey> entity)
                return false;
            return true;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        //
        // Domain Event Functionality
        //
        private List<DomainEventBase> _domainEvents = new();
        [NotMapped]
        public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();
        public void RegisterDomainEvent(DomainEventBase domainEvent) => _domainEvents.Add(domainEvent);
        internal void ClearDomainEvents() => _domainEvents.Clear();
    }
}