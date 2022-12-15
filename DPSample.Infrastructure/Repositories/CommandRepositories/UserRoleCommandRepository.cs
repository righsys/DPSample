using DPSample.Domain.Entities;
using DPSample.Infrastructure.DbContexts;
using DPSample.Infrastructure.RepositoryBase;
using DPSample.Services.Contracts.CommansRepositories;

namespace DPSample.Infrastructure.Repositories.CommandRepositories
{
    public class UserRoleCommandRepository : CommandRepositoryBase<UserRole>  , IUserRoleCommandRepository
    {
        private readonly CommandDbContext _commandDbContext;
        public UserRoleCommandRepository(CommandDbContext commandDbContext) : base(commandDbContext) => _commandDbContext = commandDbContext;
    }
}