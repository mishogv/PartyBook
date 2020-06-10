namespace PartyBook.Services
{
    using PartyBook.ViewModels.NightClub;
    using System.Threading.Tasks;

    public interface INightClubService
    {
        Task<NightClubCreateViewModel> CreateAsync(string name, string coverUrl, string description, string businessHours,
                                string location, string telephoneForReservations, string userId);

        Task<NightClubCreateViewModel> UpdateAsync(string id, string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations);

        Task<bool> DeleteAsync(string id);
    }
}
