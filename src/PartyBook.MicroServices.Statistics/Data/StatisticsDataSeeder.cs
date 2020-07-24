namespace PartyBook.MicroServices.Statistics.Data
{
    using PartyBook.Data.Common;
    using PartyBook.MicroServices.Statistics.Data.Models;
    using System.Linq;

    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticsDbContext dbContext;

        public StatisticsDataSeeder(StatisticsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void SeedData()
        {
            var reviewStatistics = this.dbContext.RviewStatistics.FirstOrDefault();

            if (reviewStatistics == null)
            {
                reviewStatistics = new RviewStatistic() { CountOfReviews = 0 };
                this.dbContext.RviewStatistics.Add(reviewStatistics);
                this.dbContext.SaveChanges();
            }
        }
    }
}
