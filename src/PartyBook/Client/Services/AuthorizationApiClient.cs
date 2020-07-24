namespace PartyBook.Client.Services
{
    using PartyBook.Configurations;
    using PartyBook.ViewModels.NightClub;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class AuthorizationApiClient : IAuthorizationApiClient
    {
        private readonly HttpClient client;
        private readonly ApplicationSettings applicationSettings;

        public AuthorizationApiClient(HttpClient client, ApplicationSettings applicationSettings)
        {
            this.client = client;
            this.applicationSettings = applicationSettings;
        }

        public async Task<string> CreateNightClubAsync(NightClubCreateInputModel nightClub) 
            => await this.PostAsJsonAsync<NightClubCreateInputModel, string>(this.applicationSettings.NightClubAppUrl + "/Create", nightClub);

        private async Task<TResult> PostAsJsonAsync<TRequest, TResult>(string url, TRequest request)
        {
            var response = await this.client.PostAsJsonAsync(url, request);
            var result = await response.Content.ReadFromJsonAsync<TResult>();

            return result;
        }
    }
}
