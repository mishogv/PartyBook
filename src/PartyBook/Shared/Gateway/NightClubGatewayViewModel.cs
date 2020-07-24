namespace PartyBook.ViewModels.Gateway
{
    using System.Collections.Generic;

    public class NightClubGatewayViewModel
    {
        public NightClubGatewayViewModel()
        {
            this.Reviews = new List<ReviewGatewayViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string CoverUrl { get; set; }

        public string Description { get; set; }

        public string BusinessHours { get; set; }

        public string Location { get; set; }

        public string TelephoneForReservations { get; set; }

        public ICollection<ReviewGatewayViewModel> Reviews { get; set; }
    }
}
