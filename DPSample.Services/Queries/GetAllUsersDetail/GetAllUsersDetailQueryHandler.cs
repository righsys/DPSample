using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.DTOs;
using DPSample.Services.Exceptions;
using DPSample.Services.Mappers;
using Microsoft.Extensions.Logging;
using MediatR;

namespace DPSample.Services.Queries.GetAllUsers
{
    public class GetAllUsersDetailQueryHandler : IRequestHandler<GetAllUsersDetailQuery, GetAllUsersDetailQueryResponse>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ILogger<GetAllUsersDetailQuery> _logger;

        public GetAllUsersDetailQueryHandler(IUserQueryRepository userQueryRepository, ILogger<GetAllUsersDetailQuery> logger)
        {
            _userQueryRepository = userQueryRepository;
            _logger = logger;
        }

        public async Task<GetAllUsersDetailQueryResponse> Handle(GetAllUsersDetailQuery request, CancellationToken cancellationToken)
        {
            GetAllUsersDetailQueryResponse response = new GetAllUsersDetailQueryResponse();
            try
            {
                var properties = typeof(UserDetailDto).GetProperties().ToList();
                List<string> cols = new List<string>();
                foreach (var property in properties) 
                {
                     cols.Add($"[{property.Name}]");
                }
                var result = await _userQueryRepository.GetAllAsync(cols);
                response.Users = result.ConvertToUserDetailDto();
                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ExceptionMessage=ex.Message;
                response.CustomErrorMessage = ExceptionMessages.GeneralError;

                //
                // Logging
                //
                _logger.LogError(ex, $"GetAllUsersDetailQuery : {ex.Message}");

                return response;
            }
        }
    }
}