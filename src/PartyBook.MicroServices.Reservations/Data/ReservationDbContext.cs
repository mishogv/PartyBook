namespace PartyBook.MicroServices.Reservations.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.Reservations.Data.Models;

    public class ReservationDbContext : DbContext
    {
        public ReservationDbContext(DbContextOptions<ReservationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
