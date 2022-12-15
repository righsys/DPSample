using DPSample.Domain.Enums;
using DPSample.Services.DTOs;
using DPSample.SharedServices.Common;

namespace DPSample.Services.Queries.ValidateUserLogin
{
    public class ValidateUserLoginQueryResponse:QueryResponseBase
    {
        public UserSummaryDto UserSummary { get; set; }
        public UserLoginValidationStatus UserLoginValidationStatus { get; set; }
    }
}