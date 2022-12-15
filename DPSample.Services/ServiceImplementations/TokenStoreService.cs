using DPSample.Domain.Entities;
using DPSample.Services.Commands.AuthenticateUser;
using DPSample.Services.Commands.LogoutUser;
using DPSample.Services.Contracts.CommansRepositories;
using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.ServiceInterfaces;
using DPSample.SharedServices.Common;
using MediatR;

namespace DPSample.Services.ServiceImplementations
{
    public class TokenStoreService : ITokenStoreService
    {
        private readonly IMediator _mediator;
        private readonly IUserTokenQueryRepository _userTokenQueryRepository;
        private readonly IUserTokenCommandRepository _userTokenCommandRepository;

        public TokenStoreService(IMediator mediator, IUserTokenQueryRepository userTokenQueryRepository, IUserTokenCommandRepository userTokenCommandRepository)
        {
            _mediator = mediator;
            _userTokenQueryRepository = userTokenQueryRepository;
            _userTokenCommandRepository = userTokenCommandRepository;
        }
     
        public async Task<JWTTokens> CreateJwtTokens(string username, string password)
        {
            AuthenticateUserCommand command = new AuthenticateUserCommand() { UserName = username, Password = password };
            AuthenticateUserCommandResponse response = await _mediator.Send(command);
            if (response.Success)
                return response.Token;
            return null;
        }
        public async Task<bool> DeleteExpiredTokensAsync()
        {
            try
            {
                var now = DateTimeOffset.Now;
                List<UserToken> tokens = await Task.Run(() => _userTokenQueryRepository.GetAllAsync(null).Result.Where(x => x.AccessTokenExpiresDateTime < now).ToList());
                foreach (var item in tokens)
                {
                    await _userTokenCommandRepository.DeleteAsync(item);
                }
                return true;
            }
            catch (Exception)
            {
               return false;    
            }
        }
        public async Task<bool> InvalidateUserTokensAsync(int userId)
        {
            try
            {
                LogoutUserCommand command = new LogoutUserCommand() { UserId = userId };
                LogoutUserCommandResponse response = await _mediator.Send(command);                
                return response.Success;
            }
            catch (Exception)
            {
                return false;
            }            
        }
        public async Task<bool> IsValidTokenAsync(string accessToken, int userId)
        {
            UserToken token = await _userTokenQueryRepository.GetToken(accessToken, userId);
            return token?.AccessTokenExpiresDateTime >= DateTimeOffset.Now;
        }
    }
}