namespace PartyBook.MicroServices.Statistics.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.Statistics.Data.Models;

    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RviewStatistic> RviewStatistics { get; set; }
    }
}
