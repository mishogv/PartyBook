using PartyBook.ViewModels.Identity;
using System.Threading.Tasks;

namespace PartyBook.Client.Services
{
    public interface IAuthService
    {
        Task<UserOutputModel> Login(LoginInputModel loginModel);

        Task Logout();

        Task<UserOutputModel> Register(RegisterInputModel registerModel);
    }
}
