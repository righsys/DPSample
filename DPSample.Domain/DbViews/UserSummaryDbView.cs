namespace DPSample.Domain.DbViews
{
    public class UserSummaryDbView
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string RoleEnName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}