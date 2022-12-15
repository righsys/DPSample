namespace DPSample.SharedCore.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<EntityBase<int>> entitiesWithEvents);
    }
}
