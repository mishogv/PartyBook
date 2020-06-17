namespace PartyBook.Server
{
    using IdentityServer4.Models;
    using System.Collections.Generic;

    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };


        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource("weatherapi", "The Weather API")
            };


        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "blazor",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedCorsOrigins = { "https://localhost:5001" },
                    AllowedScopes = { "openid", "profile", "email", "weatherapi" },
                    RedirectUris = { "https://localhost:5001/authentication/login-callback" },
                    PostLogoutRedirectUris = { "https://localhost:5001/" },
                    Enabled = true
                },
            };
    }
}
