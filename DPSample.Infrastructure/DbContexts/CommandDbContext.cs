using DPSample.Domain.Entities;
using DPSample.SharedCore;
using DPSample.SharedCore.Interfaces;
using DPSample.SharedServices.Interfaces;
using DPSample.Utilities.DateTimeHelper;
using Microsoft.EntityFrameworkCore;

namespace DPSample.Infrastructure.DbContexts
{
    public class CommandDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeHelper _dateTimeHelper;

        public CommandDbContext(DbContextOptions<CommandDbContext> options,
            IDomainEventDispatcher dispatcher,
            ICurrentUserService currentUserService,
            IDateTimeHelper dateTimeHelper) : base(options)
        {
            _dispatcher = dispatcher;
            _currentUserService = currentUserService;
            _dateTimeHelper = dateTimeHelper;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommandDbContext).Assembly);

            modelBuilder.Entity<User>().ToTable("User").HasKey(x => x.UserId);
            modelBuilder.Entity<UserRole>().ToTable("UserRole").HasKey(x => x.UserRoleId);
            modelBuilder.Entity<UserToken>().ToTable("UserToken").HasKey(x => x.UserTokenId);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<EntityBase<int>>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);
            return result;
        }
        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
        //
        //
        //
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
    }
}