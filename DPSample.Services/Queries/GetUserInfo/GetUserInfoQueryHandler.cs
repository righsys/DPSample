using DPSample.Domain.DbViews;
using DPSample.Domain.Entities;
using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.Exceptions;
using DPSample.Services.Mappers;
using MediatR;

namespace DPSample.Services.Queries.GetUserInfo
{
    public class GetUserInfoQueryHandler : IRequestHandler<GetUserInfoQuery, GetUserInfoQueryResponse>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public GetUserInfoQueryHandler(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public async Task<GetUserInfoQueryResponse> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            GetUserInfoQueryResponse response = new GetUserInfoQueryResponse();
            try
            {
                UserDetailDbView user = await _userQueryRepository.GetUserDetailByUsername(request.Username, cancellationToken);
                if (user is null)
                {
                    response.Success = false;
                    response.CustomErrorMessage=ExceptionMessages.EntityNotFoundError;
                    return response;
                }
                response.Success=true;
                response.UserSummary = user.ConvertToUserDetailDto();
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ExceptionMessage = ex.Message;
                response.CustomErrorMessage = ExceptionMessages.GeneralError;
                return response;
            }
            

        }
    }
}