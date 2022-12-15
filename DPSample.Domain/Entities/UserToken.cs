using DPSample.SharedCore;

namespace DPSample.Domain.Entities
{
    public class UserToken : EntityBase<int>, IUserAggregateRoot
    {
        public int UserTokenId { get; set; }
        public int UserId { get; set; }
        public string AccessTokenHash { get; set; }
        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }
        public string RefreshTokenIdHash { get; set; }
        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }

        //
        // Navigation property
        //
        public virtual User User { get; set; }
    }
}