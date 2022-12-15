using DPSample.SharedCore;

namespace DPSample.Domain.Entities
{
    public class User : EntityBase<int>, IUserAggregateRoot
    {
        public int UserId { get; set; }
        public int UserRoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsLoggedIn { get; set; }

        //
        // Navigation Properties
        //
        public virtual UserRole UserRole { get; set; }
        public virtual ICollection<UserToken> UserTokens { get; set; }
    }
}