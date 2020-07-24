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

        public ApiClient(HttpClient client, ApplicationSettings settings)
        {
            this.client = client;
            this.urls = settings;
        }

        public async Task<IEnumerable<NightClubGetAllViewModel>> GetNightClubs()
            => await client.GetFromJsonAsync<IEnumerable<NightClubGetAllViewModel>>($"{this.urls.NightClubAppUrl}/NightClubs");
    }
}
