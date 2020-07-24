namespace PartyBook.Client.Services
{
    using Blazored.LocalStorage;
    using Microsoft.AspNetCore.Components.Authorization;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using PartyBook.ViewModels.Identity;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http;

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<UserOutputModel> Register(RegisterInputModel registerModel)
        {
            var result = await _httpClient.PostJsonAsync<UserOutputModel>("Identity/Register", registerModel);
            return result;
        }


        public async Task<UserOutputModel> Login(LoginInputModel loginModel)
        {
            //var loginAsJson = JsonConvert.SerializeObject(loginModel);
            //var response = await _httpClient.PostAsync("Identity/Login", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            ////var loginResult = JsonSerializer.Deserialize<UserOutputModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            //Console.WriteLine("token " + await response.Content.ReadAsStringAsync());
            //var loginResult = JsonConvert.DeserializeObject<UserOutputModel>(await response.Content.ReadAsStringAsync());
            //if (!response.IsSuccessStatusCode)
            //{
            //    return loginResult;
            //}

            //await _localStorage.SetItemAsync("authToken", loginResult.Token);
            //((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            //return loginResult;
            var response = await _httpClient.PostJsonAsync<UserOutputModel>("Identity/Login", loginModel);

            await _localStorage.SetItemAsync("authToken", response.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.Token);

            return response;
        }

        public async Task<UserOutputModel> Login(string token, LoginInputModel loginModel)
        {
            await _localStorage.SetItemAsync("authToken", token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            return new UserOutputModel(token);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
