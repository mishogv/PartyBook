namespace PartyBook.MicroServices.Statistics.Services
{
    using PartyBook.ViewModels.Statistics;
    using System.Threading.Tasks;

    public interface IStatisticsService
    {
        Task AddReviewStatisticAsync();

        Task<StatisticsGetAllViewModel> GetAllAsync();
    }
}
