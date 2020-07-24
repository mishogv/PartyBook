namespace PartyBook.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.Data.Models;

    public class TempDbContext : DbContext
    {
        public TempDbContext()
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
