namespace PartyBook.Client.Services
{
    using PartyBook.ViewModels.NightClub;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IApiClient
    {
        Task<IEnumerable<NightClubGetAllViewModel>> GetNightClubs();
    }
}
