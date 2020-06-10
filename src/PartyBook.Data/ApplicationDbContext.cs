namespace PartyBook.Data
{
    using IdentityServer4.EntityFramework.Options;
    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;
    using PartyBook.Data.Models;

    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<NightClub> NightClubs { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<BookRequest> BookRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
