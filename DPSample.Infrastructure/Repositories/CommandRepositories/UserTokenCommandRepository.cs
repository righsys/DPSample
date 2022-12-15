using DPSample.Domain.Entities;
using DPSample.Infrastructure.DbContexts;
using DPSample.Infrastructure.RepositoryBase;
using DPSample.Services.Contracts.CommansRepositories;

namespace DPSample.Infrastructure.Repositories.CommandRepositories
{
    public class UserTokenCommandRepository : CommandRepositoryBase<UserToken>, IUserTokenCommandRepository
    {
        private readonly CommandDbContext _commandDbContext;
        public UserTokenCommandRepository(CommandDbContext commandDbContext) : base(commandDbContext) => _commandDbContext = commandDbContext;
    }
}