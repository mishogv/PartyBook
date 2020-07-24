namespace PartyBook.MicroServices.Administration.Controllers
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Infrastructure;
    using PartyBook.Common.Services.Identity;
    using PartyBook.Configurations;
    using PartyBook.ViewModels.Statistics;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using static Common.GlobalConstants.Infrastructure;

    [AuthorizeAdministrator]
    public class StatisticsController : Controller
    {
        private readonly ApplicationSettings appSettings;
        private readonly ICurrentTokenService tokenService;

        public StatisticsController(ApplicationSettings appSettings, ICurrentTokenService tokenService)
        {
            this.appSettings = appSettings;
            this.tokenService = tokenService;
        }

        public async Task<IActionResult> Index()
        {
            var client = HttpClientFactory.Create();
            //client.BaseAddress = new Uri(this.appSettings.StatisticsAppUrl);
            client.BaseAddress = new Uri(this.appSettings.StatisticsAppInternalUrl);
            var currentToken = this.tokenService.Get();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationHeaderValuePrefix, currentToken);

            var result = await client.GetJsonAsync<StatisticsGetAllViewModel>("Statistics");
            return this.View(result);
        }
    }
}
