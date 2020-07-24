namespace PartyBook.Server.Services.Identity
{
    using PartyBook.Data.Identity.Models;
    using System.Collections.Generic;

    public interface ITokenGeneratorService
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles = null);
    }
}
