namespace PartyBook.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Server.Infrastructure.Extensions;
    using PartyBook.Services;
    using PartyBook.ViewModels.NightClub;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [Authorize]
    public class NightClubController : ApiController
    {
        private readonly INightClubService nightClubService;

        public NightClubController(INightClubService nightClubService)
        {
            this.nightClubService = nightClubService;
        }
        //TODO: Add get multipple nightClubs

        [HttpGet("{name}")]
        public async Task<ActionResult<NightClubCreateViewModel>> Get([FromRoute]string name)
            =>  await this.nightClubService.GetByNameAsync(name);

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<NightClubCreateViewModel>> GetById([FromRoute]string id)
            => await this.nightClubService.GetByIdAsync(id);

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create([FromBody]NightClubCreateInputModel inputModel)
        {
            var userId = User.GetCurrentUserId();
            var nightClub = await this.nightClubService.CreateAsync(inputModel.Name, inputModel.CoverUrl, inputModel.Description, inputModel.BusinessHours, inputModel.Location, inputModel.TelephoneForReservations, userId);

            return this.Created(nameof(Create), nightClub);
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update([FromBody]NightClubUpdateInputModel inputModel)
        {
            var nightClub = await this.nightClubService.UpdateAsync(inputModel.Id,inputModel.Name, inputModel.CoverUrl, inputModel.Description, inputModel.BusinessHours, inputModel.Location, inputModel.TelephoneForReservations);

            return this.Ok(nightClub);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete([FromBody]NightClubDeleteInputModel inputModel)
        {
            var nightClub = await this.nightClubService.DeleteAsync(inputModel.Id);

            return this.Accepted(nightClub);
        }
    }
}