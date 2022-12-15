namespace DPSample.Domain.DbViews
{
    public class UserDetailDbView
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public bool IsActive { get; set; }
        public string Username { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}