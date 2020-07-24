namespace PartyBook.MicroServices.Statistics.Data.Models
{
    using PartyBook.Data.Common.Models;
    using PartyBook.Services.Mapping;
    using PartyBook.ViewModels.Statistics;

    public class RviewStatistic : BaseModel<int>, IMapTo<StatisticsGetAllViewModel>
    {
        public int CountOfReviews { get; set; }
    }
}
