using DPSample.Services.DTOs;
using DPSample.SharedServices.Common;

namespace DPSample.Services.Queries.GetUserInfo
{
    public class GetUserInfoQueryResponse : QueryResponseBase
    {
        public UserDetailDto UserSummary { get; set; }
    }
}