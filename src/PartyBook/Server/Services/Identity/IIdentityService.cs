namespace PartyBook.Server.Services.Identity
{
    using System.Threading.Tasks;
    using PartyBook.Common.Services;
    using PartyBook.Data.Identity.Models;
    using PartyBook.ViewModels.Identity;

    public interface IIdentityService
    {
        Task<Result<ApplicationUser>> Register(RegisterInputModel userInput);

        Task<Result<UserOutputModel>> Login(LoginInputModel userInput);
    }
}
