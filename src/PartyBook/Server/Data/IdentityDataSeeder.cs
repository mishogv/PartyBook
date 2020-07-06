namespace PartyBook.Server.Data
{
    using Microsoft.AspNetCore.Identity;
    using PartyBook.Data.Common;
    using PartyBook.Data.Identity.Models;
    using System.Linq;
    using System.Threading.Tasks;

    using static PartyBook.Common.GlobalConstants;

    public class IdentityDataSeeder : IDataSeeder
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task
                .Run(async () =>
                {
                    var adminRole = new IdentityRole(Administration.AdministrationRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    var adminUser = new ApplicationUser
                    {
                        UserName = "admin@crs.com",
                        Email = "admin@crs.com",
                        SecurityStamp = "RandomSecurityStamp",
                        FirstName = "GoshoElud",
                        LastName = "Ivanov"
                    };

                    await userManager.CreateAsync(adminUser, "asdasd");

                    await userManager.AddToRoleAsync(adminUser, Administration.AdministrationRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
