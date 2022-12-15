using DPSample.Domain.Entities;
using DPSample.Services.Contracts.CommansRepositories;
using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.Exceptions;
using MediatR;

namespace DPSample.Services.Commands.LogoutUser
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, LogoutUserCommandResponse>
    {
        private readonly IUserTokenCommandRepository _userTokenCommandRepository;
        private readonly IUserTokenQueryRepository _userTokenQueryRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IUserCommandRepository _userCommandRepository;

        public LogoutUserCommandHandler(IUserTokenCommandRepository userTokenCommandRepository,
            IUserTokenQueryRepository userTokenQueryRepository,
            IUserQueryRepository userQueryRepository,
            IUserCommandRepository userCommandRepository)
        {
            _userTokenCommandRepository = userTokenCommandRepository;
            _userTokenQueryRepository = userTokenQueryRepository;
            _userQueryRepository = userQueryRepository;
            _userCommandRepository = userCommandRepository;
        }

        public async Task<LogoutUserCommandResponse> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            LogoutUserCommandResponse response = new LogoutUserCommandResponse();
            try
            {
                List<UserToken> userTokens = await _userTokenQueryRepository.GetTokens(request.UserId);
                foreach (var token in userTokens)
                {
                    await _userTokenCommandRepository.DeleteAsync(token);
                }

                User user = await _userQueryRepository.FindByKeyAsync(request.UserId);
                user.IsLoggedIn = false;
                await _userCommandRepository.UpdateAsync(user);

                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.CustomErrorMessage = ExceptionMessages.GeneralError;
                response.ExceptionMessage = ex.Message;
                return response;
            }
            throw new NotImplementedException();
        }
    }
}