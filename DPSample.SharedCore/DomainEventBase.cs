using MediatR;

namespace DPSample.SharedCore
{
    public abstract class DomainEventBase : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.Now;
    }
}