//namespace PartyBook.Data.NightClub
//{
//    using Microsoft.EntityFrameworkCore;
//    using PartyBook.Data.NightClub.Models;

//    public class NightClubDbContext : DbContext
//    {
//        public NightClubDbContext(DbContextOptions<NightClubDbContext> options)
//            :base(options)
//        {

//        }

//        public DbSet<Event> Events { get; set; }

//        public DbSet<NightClub> NightClubs { get; set; }

//        public DbSet<Review> Reviews { get; set; }

//        public DbSet<BookRequest> BookRequests { get; set; }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            base.OnModelCreating(builder);
//        }
//    }
//}
