using DPSample.SharedServices.Interfaces;
using System.Security.Claims;

namespace DPSample.Api.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService()
        {
            Username = "hasan";//httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            IsAuthenticated = Username != null;
        }
        public string Username { get; }
        public bool IsAuthenticated { get; }
    }
}
