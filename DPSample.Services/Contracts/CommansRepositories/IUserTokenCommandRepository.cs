using DPSample.Domain.Entities;
using DPSample.SharedCore.Interfaces;

namespace DPSample.Services.Contracts.CommansRepositories
{
    public interface IUserTokenCommandRepository :ICommandGenericRepository<UserToken>
    {
    }
}
