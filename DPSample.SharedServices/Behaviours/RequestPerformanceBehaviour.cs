using DPSample.SharedServices.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DPSample.SharedServices.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICurrentApplicationServices _currentApplicationServices;

        public RequestPerformanceBehaviour(
            ICurrentUserService currentUserService,
            ILogger<TRequest> logger,
            ICurrentApplicationServices currentApplicationServices)
        {
            _timer = new Stopwatch();
            _currentUserService = currentUserService;
            _logger = logger;
            _currentApplicationServices = currentApplicationServices;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;
                _logger.LogWarning("{@ApplicationName} Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@Request}",
                    _currentApplicationServices.ApplicationName, name, _timer.ElapsedMilliseconds, _currentUserService.Username, request);
            }
            return response;
        }
    }
}