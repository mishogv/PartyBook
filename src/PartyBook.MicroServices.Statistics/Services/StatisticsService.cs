namespace PartyBook.MicroServices.Statistics.Services
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.Statistics.Data;
    using PartyBook.MicroServices.Statistics.Data.Models;
    using System.Threading.Tasks;

    public class StatisticsService : IStatisticsService
    {
        private readonly StatisticsDbContext dbContext;

        public StatisticsService(StatisticsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddReviewStatisticAsync()
        {
            //TODO : Fix with seed
            var statistic = await this.dbContext.RviewStatistics.FirstOrDefaultAsync();

            if (statistic != null)
            {
                statistic.CountOfReviews++;
                await this.dbContext.SaveChangesAsync();
            }
            else
            {
                statistic = new RviewStatistic();

                statistic.CountOfReviews++;
                await this.dbContext.AddAsync(statistic);
                await this.dbContext.SaveChangesAsync();
            }
        }
    }
}
