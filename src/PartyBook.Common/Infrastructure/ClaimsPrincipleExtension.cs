namespace PartyBook.Common.Infrastructure
{
    using System.Linq;
    using System.Security.Claims;
    using static PartyBook.Common.GlobalConstants;

    public static class ClaimsPrincipleExtension
    {
        public static string GetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal
                        .Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                        ?.Value;

        public static bool IsAdministrator(this ClaimsPrincipal claimsPrincipal)
           => claimsPrincipal.IsInRole(Administration.AdministrationRoleName);
    }
}
