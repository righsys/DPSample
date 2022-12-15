using DPSample.SharedServices.Interfaces;

namespace DPSample.Api.Services
{
    public class CurrentApplicationServices : ICurrentApplicationServices
    {
        public CurrentApplicationServices()
        {
            ApplicationName = "DPSample";
        }
        public string ApplicationName { get; }
    }
}
