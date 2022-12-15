using DPSample.Domain.Entities;
using DPSample.Domain.Enums;
using DPSample.Services.Contracts.CommansRepositories;
using DPSample.Services.Exceptions;
using DPSample.Utilities.Security;
using Microsoft.Extensions.Logging;
using MediatR;
using DPSample.Services.Contracts.QueryRepositories;

namespace DPSample.Services.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ISecurityServices _securityServices;
        private readonly ILogger<CreateUserCommand> _logger;

        public CreateUserCommandHandler(
            IUserCommandRepository userCommandRepository,
            ISecurityServices securityServices,
            ILogger<CreateUserCommand> logger,
            IUserQueryRepository userQueryRepository)
        {
            _userCommandRepository = userCommandRepository;
            _securityServices = securityServices;
            _logger = logger;
            _userQueryRepository = userQueryRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CreateUserCommandResponse response= new CreateUserCommandResponse();
            try
            {
                //
                // Checking User Exist
                //
                bool isUserExist = await _userQueryRepository.ChackUserExistByUsername(request.Username, CancellationToken.None);
                if (isUserExist)
                {
                    response.RegisterResponseStatus = UserRegisterResponseStatus.AllradyExist;
                    response.Success = false;
                    return response;
                }
                //
                // Adding new user
                //
                Random rnd = new Random();
                int code = rnd.Next(1111, 9999);
                string salt = _securityServices.CreateRandomSalt();
                User user = new User()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Username = request.Username,
                    Password = _securityServices.CreatePasswordHash(request.Password, salt),
                    PasswordSalt = salt,
                    UserRoleId = 1, // General User
                    NationalCode=request.NationalCode,
                    IsActive = true,
                    IsLoggedIn = false,                    
                };
                await _userCommandRepository.AddAsync(user);
                //
                //
                //
                response.Success = true;
                response.UserId = user.UserId;
                response.Username=user.Username;
                response.RegisterResponseStatus = UserRegisterResponseStatus.Succeed;
                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.CustomErrorMessage = ExceptionMessages.UserRegisterFailure;
                response.ExceptionMessage = ex.Message;
                //
                // Logging
                //
                _logger.LogError(ex, $"CreateUserCommand : {request.FirstName} {request.LastName}");

                return response;
            }            
        }
    }
}