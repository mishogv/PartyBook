namespace PartyBook.MicroServices.Review.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PartyBook.Common.Controllers;
    using PartyBook.Common.Infrastructure;
    using PartyBook.MicroServices.Review.Services;
    using PartyBook.ViewModels.Review;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    [Authorize]
    public class ReviewsController : ApiController
    {
        private readonly IReviewService reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<ReviewGetViewModel>> Get([FromRoute][Required]string id)
            => await this.reviewService.GetAsync(id);

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create([FromBody]ReviewCreateInputModel inputModel)
        {
            var userId = User.GetCurrentUserId();
            var review = await this.reviewService.CreateAsync(inputModel.Raiting, inputModel.Description, userId, inputModel.NightClubId);

            return this.Created(nameof(Create), review);
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<ActionResult> Update([FromBody]ReviewUpdateInputModel inputModel)
        {
            var result = await this.reviewService.UpdateAsync(inputModel.Raiting, inputModel.Description, inputModel.Id, this.User.GetCurrentUserId());

            return this.Ok(result);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<ActionResult> Delete([FromBody]ReviewDeleteInputModel inputModel)
        {
            //TODO : Message or something else not just fucking bool
            var review = await this.reviewService.DeleteAsync(inputModel.Id, this.User.GetCurrentUserId());

            return this.Accepted(review);
        }
    }
}
