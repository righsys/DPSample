using DPSample.SharedCore;

namespace DPSample.Domain.Entities
{
    public class UserRole : EntityBase<int>, IUserAggregateRoot
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }
        public int UserRoleId { get; set; }
        public string RoleEnName { get; set; }

        //
        // Navigation Properties
        //
        public virtual ICollection<User> Users { get; set; }
    }
}