namespace PartyBook.Server.Services.Identity
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using PartyBook.Common.Services;
    using PartyBook.Data.Identity.Models;
    using PartyBook.ViewModels.Identity;

    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenGeneratorService jwtTokenGenerator;

        public IdentityService(
            UserManager<ApplicationUser> userManager,
            ITokenGeneratorService jwtTokenGenerator)
        {
            this.userManager = userManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<Result<ApplicationUser>> Register(RegisterInputModel userInput)
        {
            var user = new ApplicationUser
            {
                FirstName = userInput.FirstName,
                LastName = userInput.LastName,
                Email = userInput.Email,
                UserName = userInput.Email
            };

            var identityResult = await userManager.CreateAsync(user, userInput.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result<ApplicationUser>.SuccessWith(user)
                : Result<ApplicationUser>.Failure(errors);
        }

        public async Task<Result<UserOutputModel>> Login(LoginInputModel userInput)
        {
            var user = await userManager.FindByEmailAsync(userInput.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await userManager.CheckPasswordAsync(user, userInput.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var roles = await userManager.GetRolesAsync(user);

            var token = jwtTokenGenerator.GenerateToken(user, roles);

            return new UserOutputModel(token);
        }
    }
}
