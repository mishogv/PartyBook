namespace PartyBook.MicroServices.Statistics.Data
{
    using Microsoft.EntityFrameworkCore;

    public class StatisticsDbContext : DbContext
    {
        public StatisticsDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
