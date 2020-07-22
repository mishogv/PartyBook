using PartyBook.ViewModels.NightClub;
using System.Threading.Tasks;

namespace PartyBook.Client.Services
{
    public interface IAuthorizationApiClient
    {
        Task<string> CreateNightClubAsync(NightClubCreateInputModel nightClub);
    }
}
