namespace PartyBook.MicroServices.Review.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.Review.Data.Models;

    public class ReviewDbContext : DbContext
    {
        public ReviewDbContext(DbContextOptions<ReviewDbContext> options)
            : base(options)
        {

        }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
