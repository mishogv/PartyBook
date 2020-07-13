namespace PartyBook.MicroServices.Statistics.Data.Models
{
    using PartyBook.Data.Common.Models;

    public class RviewStatistic : BaseModel<int>
    {
        public int CountOfReviews { get; set; }
    }
}
