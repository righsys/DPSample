using DPSample.Domain.Entities;
using DPSample.Infrastructure.DbContexts;
using DPSample.Infrastructure.RepositoryBase;
using DPSample.Services.Contracts.CommansRepositories;

namespace DPSample.Infrastructure.Repositories.CommandRepositories
{
    public class UserCommandRepository : CommandRepositoryBase<User> , IUserCommandRepository
    {
        private readonly CommandDbContext _commandDbContext;
        public UserCommandRepository(CommandDbContext commandDbContext) : base(commandDbContext) => _commandDbContext = commandDbContext;

    }
}