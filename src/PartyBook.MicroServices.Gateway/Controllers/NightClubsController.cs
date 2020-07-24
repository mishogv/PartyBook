namespace PartyBook.Microservices.Gateway.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Controllers;
    using PartyBook.Common.Services.Identity;
    using PartyBook.Configurations;
    using PartyBook.ViewModels.Gateway;
    using PartyBook.ViewModels.Review;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using static Common.GlobalConstants.Infrastructure;

    [Authorize]
    public class NightClubsController : ApiController
    {
        private readonly ApplicationSettings appSettings;
        private readonly ICurrentTokenService tokenService;

        public NightClubsController(ApplicationSettings appSettings, ICurrentTokenService tokenService)
        {
            this.appSettings = appSettings;
            this.tokenService = tokenService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NightClubGatewayViewModel>> Get([FromRoute][Required] string id)
        {
            var client = HttpClientFactory.Create();
            var currentToken = this.tokenService.Get();
            client.BaseAddress = new Uri(this.appSettings.NightClubAppUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationHeaderValuePrefix, currentToken);
            var nightClub = await client.GetJsonAsync<NightClubGatewayViewModel>("NightClubs/GetById/" + id);
            client = HttpClientFactory.Create();
            client.BaseAddress = new Uri(this.appSettings.ReviewAppUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationHeaderValuePrefix, currentToken);
            var reviews = await client.GetJsonAsync<ReviewGetViewModel[]>("Reviews/" + id);
            nightClub.Reviews = reviews.Select(x => new ReviewGatewayViewModel { Id = x.Id, Description = x.Description, Raiting = x.Raiting }).ToArray();
            return nightClub;
        }
    }
}
