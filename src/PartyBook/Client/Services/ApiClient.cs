namespace PartyBook.Client.Services
{
    using PartyBook.Configurations;
    using PartyBook.ViewModels.NightClub;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class ApiClient : IApiClient
    {
        private readonly HttpClient client;
        private readonly ApplicationSettings urls;

        public ApiClient(IHttpClientFactory httpClientFactory, ApplicationSettings settings)
        {
            this.client = httpClientFactory.CreateClient();
            this.urls = settings;
        }

        public async Task<IEnumerable<NightClubGetAllViewModel>> GetNightClubs()
            => await client.GetFromJsonAsync<IEnumerable<NightClubGetAllViewModel>>($"{this.urls.NightClubAppUrl}/NightClubs");
    }
}
