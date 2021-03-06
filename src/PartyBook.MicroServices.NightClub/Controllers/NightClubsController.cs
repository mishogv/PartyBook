﻿namespace PartyBook.MicroServices.NightClub.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Controllers;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.NightClub.Services;
    using PartyBook.ViewModels.Gateway;
    using PartyBook.ViewModels.NightClub;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    //TODO ADD ALLOW ANONYMOUS
    [Authorize]
    public class NightClubsController : ApiController
    {
        private readonly INightClubService nightClubService;

        public NightClubsController(INightClubService nightClubService)
        {
            this.nightClubService = nightClubService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<NightClubGetAllViewModel>> GetAll()
        => await this.nightClubService.GetAllAsync();

        [AllowAnonymous]
        [HttpGet("{name}")]
        public async Task<ActionResult<NightClubCreateViewModel>> Get([FromRoute][Required]string name)
            =>  await this.nightClubService.GetByNameAsync(name);

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<NightClubGatewayViewModel>> GetById([FromRoute][Required]string id)
            => await this.nightClubService.GetByIdAsync(id);

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create([FromBody]NightClubCreateInputModel inputModel)
        {
            var userId = User.GetCurrentUserId();
            var nightClub = await this.nightClubService.CreateAsync(inputModel.Name, inputModel.CoverUrl, inputModel.Description, inputModel.BusinessHours, inputModel.Location, inputModel.TelephoneForReservations, userId);

            return this.Created(nameof(Create), nightClub.Name);
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