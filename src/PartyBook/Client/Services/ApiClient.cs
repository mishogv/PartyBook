namespace PartyBook.Client.Services
{
    using PartyBook.ViewModels.NightClub;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;

    public class ApiClient : IApiClient
    {
        private readonly HttpClient client;

        public ApiClient(IHttpClientFactory httpClientFactory)
        {
            this.client = httpClientFactory.CreateClient();
        }

        public async Task<IEnumerable<NightClubGetAllViewModel>> GetNightClubs()
            => await client.GetFromJsonAsync<IEnumerable<NightClubGetAllViewModel>>("http://localhost:5002/NightClubs");
    }
}
