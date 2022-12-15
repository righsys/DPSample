using DPSample.Domain.DbViews;
using DPSample.Domain.Entities;
using DPSample.Domain.Enums;
using DPSample.Services.Contracts.QueryRepositories;
using DPSample.Services.Exceptions;
using DPSample.Services.Mappers;
using DPSample.Utilities.Security;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DPSample.Services.Queries.ValidateUserLogin
{
    public class ValidateUserLoginQueryHandler : IRequestHandler<ValidateUserLoginQuery, ValidateUserLoginQueryResponse>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ISecurityServices _securityServices;
        private readonly ILogger<ValidateUserLoginQuery> _logger;
        public ValidateUserLoginQueryHandler(IUserQueryRepository userQueryRepository, ISecurityServices securityServices, ILogger<ValidateUserLoginQuery> logger)
        {
            _userQueryRepository = userQueryRepository;
            _securityServices = securityServices;
            _logger = logger;
        }

        public async Task<ValidateUserLoginQueryResponse> Handle(ValidateUserLoginQuery request, CancellationToken cancellationToken)
        {
            ValidateUserLoginQueryResponse response = new ValidateUserLoginQueryResponse();
            try
            {
                UserSummaryDbView user = null;
                if (!string.IsNullOrEmpty(request.Username))
                    user = await _userQueryRepository.GetUserSummaryByUsername(request.Username, CancellationToken.None);
                if (user == null)
                {
                    response.Success = false;
                    response.CustomErrorMessage = ExceptionMessages.EntityNotFoundError;
                    response.UserLoginValidationStatus = UserLoginValidationStatus.NotExist;
                    return response;
                }
                if (!IsUserValidatedToLogin(user, request.Password))
                {
                    response.Success = false;
                    response.CustomErrorMessage = ExceptionMessages.InvalidPassword;
                    response.UserLoginValidationStatus = UserLoginValidationStatus.WrongPassword;
                    return response;
                }
                response.Success = true;
                response.UserLoginValidationStatus = UserLoginValidationStatus.Succeed;
                response.UserSummary = user.ConvertToUserSummaryDto();
                return response;
            }
            catch (Exception ex)
            {
                //
                // Logging
                //
                _logger.LogError(ex, $"ValidateUserLoginQuery : Username : {request.Username} Password : {request.Password} == Message : {ex.Message}");
            }
            throw new NotImplementedException();
        }
        private bool IsUserValidatedToLogin(UserSummaryDbView user, string requestPassword)
        {
            string hashedpass = _securityServices.CreatePasswordHash(requestPassword, user.PasswordSalt);
            byte[] tmpSourcePass = System.Text.UnicodeEncoding.UTF8.GetBytes(hashedpass);
            byte[] tmpCurrentPass = System.Text.UnicodeEncoding.UTF8.GetBytes(user.Password);
            bool isValid = CompareByteArrays(tmpCurrentPass, tmpSourcePass);
            return isValid;
        }
        private bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}