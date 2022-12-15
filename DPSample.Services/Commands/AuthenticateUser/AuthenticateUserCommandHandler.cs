using DPSample.Domain.Entities;
using DPSample.Services.Contracts.CommansRepositories;
using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.Queries.ValidateUserLogin;
using DPSample.SharedServices.Common;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DPSample.Services.Commands.AuthenticateUser
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserCommandResponse>
    {
      
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IUserTokenCommandRepository _userTokenCommandRepository;
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;

        public AuthenticateUserCommandHandler(
            IMediator mediator, IUserTokenCommandRepository userTokenCommandRepository, 
            IConfiguration configuration, IUserCommandRepository userCommandRepository,
            IUserQueryRepository userQueryRepository)
        {

            _mediator = mediator;
            _userTokenCommandRepository = userTokenCommandRepository;
            _configuration = configuration;
            _userCommandRepository = userCommandRepository;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<AuthenticateUserCommandResponse> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            AuthenticateUserCommandResponse response = new AuthenticateUserCommandResponse();
            var now = DateTimeOffset.UtcNow;
            var accessTokenExpiresDateTime = now.AddMinutes(Convert.ToInt32(_configuration["JWT:AccessTokenExpirationMinutes"]));
            var refreshTokenExpiresDateTime = now.AddMinutes(Convert.ToInt32(_configuration["JWT:RefreshTokenExpirationMinutes"]));
            var accessToken = await Authenticate(request.UserName, request.Password);
            var refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            if (accessToken is null)
            {
                response.Success = false;
                response.CustomErrorMessage = "Authentication Failed";
                return response;
            }
            UserToken userToken = new UserToken()
            {
                UserId = accessToken.UserId,
                AccessTokenExpiresDateTime = accessTokenExpiresDateTime,
                RefreshTokenExpiresDateTime = refreshTokenExpiresDateTime,
                AccessTokenHash = accessToken.Token,
                RefreshTokenIdHash = refreshToken,
            };
            await _userTokenCommandRepository.AddAsync(userToken);

            
            User user = await _userQueryRepository.FindByKeyAsync(accessToken.UserId);
            user.IsLoggedIn = true;
            await _userCommandRepository.UpdateAsync(user);

            response.Success = true;
            response.Token = accessToken;
            response.Token.RefreshToken = refreshToken;
            return response;
        }

        //
        //
        //
        private async Task<JWTTokens> Authenticate(string username, string password)
        {
            ValidateUserLoginQueryResponse response = new ValidateUserLoginQueryResponse();
            ValidateUserLoginQuery query = new ValidateUserLoginQuery() { Username = username, Password = password };
            response = await _mediator.Send(query);
            switch (response.UserLoginValidationStatus)
            {
                case Domain.Enums.UserLoginValidationStatus.NotExist:
                    return null;
                case Domain.Enums.UserLoginValidationStatus.WrongPassword:
                    return null;
                case Domain.Enums.UserLoginValidationStatus.Succeed:
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iss, _configuration["JWT:Issuer"]),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString(), ClaimValueTypes.Integer64),
                        new Claim(ClaimTypes.NameIdentifier, response.UserSummary.UserId.ToString()),
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.UserData, response.UserSummary.UserId.ToString()),
                        new Claim(ClaimTypes.Role, response.UserSummary.RoleName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:Issuer"],
                        audience: _configuration["JWT:Audience"],
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JWT:AccessTokenExpirationMinutes"])),
                        signingCredentials: creds);
                    var tokenHandler = new JwtSecurityTokenHandler();

                    return new JWTTokens { Token = tokenHandler.WriteToken(token), UserId = response.UserSummary.UserId };
            }
            return null;
        }
    }
}