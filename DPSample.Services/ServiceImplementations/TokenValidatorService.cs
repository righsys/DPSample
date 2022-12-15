using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DPSample.Services.ServiceImplementations
{
    public class TokenValidatorService : ITokenValidatorService
    {
        private readonly ITokenStoreService _tokenStoreService;
        private readonly IUserQueryRepository _userQueryRepository;

        public TokenValidatorService(ITokenStoreService tokenStoreService, IUserQueryRepository userQueryRepository)
        {
            _tokenStoreService = tokenStoreService;
            _userQueryRepository = userQueryRepository;
        }

        public async Task ValidateAsync(TokenValidatedContext context)
        {
            var userPrincipal = context.Principal;

            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return;
            }

            var userIdString = claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
            if (!int.TryParse(userIdString, out int userId))
            {
                context.Fail("This is not our issued token. It has no user-id.");
                return;
            }

            //var user = await _userQueryRepository.FindByKeyAsync(Convert.ToInt32(userId));
            //if (user == null || !user.IsActive)
            //{
            //    context.Fail("This token is expired. Please login again.");
            //}

            var accessToken = context.SecurityToken as JwtSecurityToken;
            if (accessToken == null || string.IsNullOrWhiteSpace(accessToken.RawData) ||
                !await _tokenStoreService.IsValidTokenAsync(accessToken.RawData, userId).ConfigureAwait(false))
            {
                context.Fail("This token is not in our database.");
                return;
            }
        }
    }
}