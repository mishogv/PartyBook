namespace PartyBook.MicroServices.NightClub.Services
{
    using PartyBook.ViewModels.Gateway;
    using PartyBook.ViewModels.NightClub;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INightClubService
    {
        Task<IEnumerable<NightClubGetAllViewModel>> GetAllAsync();

        Task<NightClubGatewayViewModel> GetByIdAsync(string id);

        Task<NightClubCreateViewModel> GetByNameAsync(string name);

        Task<NightClubCreateViewModel> CreateAsync(string name, string coverUrl, string description, string businessHours,
                                string location, string telephoneForReservations, string userId);

        Task<NightClubCreateViewModel> UpdateAsync(string id, string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations);

        Task<bool> DeleteAsync(string id);
    }
}
