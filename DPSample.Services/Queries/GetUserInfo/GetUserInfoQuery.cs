using MediatR;

namespace DPSample.Services.Queries.GetUserInfo
{
    public class GetUserInfoQuery :IRequest<GetUserInfoQueryResponse>
    {
        public string Username { get; set; }
    }
}