namespace PartyBook.Server.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Server.Infrastructure.Extensions;
    using PartyBook.Services;
    using PartyBook.ViewModels.Event;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Authorize]
    public class EventsController : ApiController
    {
        private readonly IEventService eventService;

        public EventsController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IEnumerable<int>> Get()
            => await this.eventService.GetAsync();

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create([FromBody]EventCreateInputModel inputModel)
        {
            var userId = User.GetCurrentUserId();
            var result = await this.eventService.CreateAsync(inputModel.Title, inputModel.Description, inputModel.PictureUrl, inputModel.When, inputModel.NightClubId);

            return this.Created(nameof(Create), result);
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update([FromBody]EventUpdateInputModel inputModel)
        {
            var result = await this.eventService.UpdateAsync(inputModel.Id, inputModel.Title, inputModel.Description, inputModel.PictureUrl, inputModel.When, this.User.GetCurrentUserId());

            return this.Ok(result);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete([FromBody]EventDeleteInputModel inputModel)
        {
            //TODO : Message or something else not just fucking bool
            var result = await this.eventService.DeleteAsync(inputModel.Id, this.User.GetCurrentUserId());

            return this.Accepted(result);
        }
    }
}