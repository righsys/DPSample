using DPSample.SharedServices.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace DPSample.SharedServices.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICurrentApplicationServices _currentApplicationServices;
        public RequestLogger(
            ICurrentUserService currentUserService,
            ILogger<TRequest> logger,
            ICurrentApplicationServices currentApplicationServices)
        {
            _currentUserService = currentUserService;
            _logger = logger;
            _currentApplicationServices = currentApplicationServices;
        }
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;
            _logger.LogInformation("{@ApplicationName} Request: Username: {Name} {@UserId} {@Request}",
                _currentApplicationServices.ApplicationName, name, _currentUserService.Username, request);
            return Task.CompletedTask;
        }
    }
}