namespace PartyBook.MicroServices.Statistics.Messages
{
    using System.Threading.Tasks;
    using MassTransit;
    using PartyBook.Common.Messages;
    using PartyBook.MicroServices.Statistics.Services;

    public class ReviewCreatedConsumer : IConsumer<ReviewCreatedMessage>
    {
        private readonly IStatisticsService statisticsService;

        public ReviewCreatedConsumer(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }
        public async Task Consume(ConsumeContext<ReviewCreatedMessage> context)
        {
            await this.statisticsService.AddReviewStatisticAsync();
        }
    }
}
