using DPSample.Services.DTOs;
using DPSample.SharedServices.Common;

namespace DPSample.Services.Queries.GetAllUsers
{
    public class GetAllUsersDetailQueryResponse : QueryResponseBase
    {
          public List<UserDetailDto> Users { get; set; } 
    }
}