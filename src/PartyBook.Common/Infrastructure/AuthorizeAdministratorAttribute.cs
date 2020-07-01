namespace PartyBook.Common.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;
    using static PartyBook.Common.GlobalConstants;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = Administration.AdministrationRoleName;
    }
}
