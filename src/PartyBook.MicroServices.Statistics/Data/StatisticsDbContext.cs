namespace PartyBook.MicroServices.Statistics.Data
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.Data.Common;
    using PartyBook.MicroServices.Statistics.Data.Models;

    public class StatisticsDbContext : MessageDbContext
    {
        public StatisticsDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<RviewStatistic> RviewStatistics { get; set; }
    }
}
