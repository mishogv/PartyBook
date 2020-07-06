namespace PartyBook.Client.Services
{
    using System.Net.Http;

    public class AuthorizationApiClient : IAuthorizationApiClient
    {
        private readonly HttpClient client;

        public AuthorizationApiClient(HttpClient client)
        {
            this.client = client;
        }
    }
}
