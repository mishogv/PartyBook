namespace PartyBook.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Server.Infrastructure.Extensions;
    using PartyBook.Services;
    using PartyBook.ViewModels.NightClub;
    using System.Threading.Tasks;

    [Authorize]
    public class NightClubController : ApiController
    {
        private readonly INightClubService nightClubService;

        public NightClubController(INightClubService nightClubService)
        {
            this.nightClubService = nightClubService;
        }

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create([FromBody]NightClubCreateInputModel inputModel)
        {
            var userId = User.GetCurrentUserId();
            var nightClub = await this.nightClubService.CreateAsync(inputModel.Name, inputModel.CoverUrl, inputModel.Description, inputModel.BusinessHours, inputModel.Location, inputModel.TelephoneForReservations, userId);

            return this.Created(nameof(Create), nightClub);
        }
    }
}