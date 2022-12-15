namespace DPSample.SharedServices.Interfaces
{
    public interface ICurrentUserService
    {
        string Username { get; }
        bool IsAuthenticated { get; }
    }
}
