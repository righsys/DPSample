using DPSample.Domain.Entities;
using DPSample.SharedCore;

namespace DPSample.Domain.Events
{
    public class UserCreatedEvent : DomainEventBase
    {
        public User User { get; set; }
        public UserCreatedEvent(User user)
        {
            User = user;
        }
    }
}