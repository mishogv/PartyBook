namespace PartyBook.Common.Infrastructure
{
    using System.Linq;
    using System.Security.Claims;

    public static class ClaimsPrincipleExtension
    {
        public static string GetCurrentUserId(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal
                        .Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
                        ?.Value;
    }
}
