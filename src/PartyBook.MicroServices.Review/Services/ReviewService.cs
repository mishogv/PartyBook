namespace PartyBook.MicroServices.Review.Services
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using PartyBook.Common.Messages;
    using PartyBook.Data.Common.Models;
    using PartyBook.MicroServices.Review.Data;
    using PartyBook.MicroServices.Review.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReviewService : IReviewService
    {
        private readonly ReviewDbContext dbContext;
        private readonly IBus publisher;

        public ReviewService(ReviewDbContext dbContext, IBus publisher)
        {
            this.dbContext = dbContext;
            this.publisher = publisher;
        }

        public async Task<IEnumerable<int>> GetAsync(string nightClubId)
            => await dbContext
                .Reviews
                .Where(x => x.NightClubId == nightClubId)
                .OrderByDescending(x => x.Raiting)
                .Select(x => x.Id)
                .ToListAsync();

        public async Task<int> CreateAsync(int raiting, string description, string userId, string nightClubId)
        {
            var review = new Review()
            {
                Raiting = raiting,
                Description = description,
                NightClubId = nightClubId,
                UserId = userId
            };

            var messageData = new ReviewCreatedMessage() { ReviewId = review.Id };
            var message = new Message(messageData);

            var messageInDb = await this.dbContext.Messages.AddAsync(message);
            await dbContext.Reviews.AddAsync(review);

            await dbContext.SaveChangesAsync();

            await this.publisher.Publish(messageData);

            messageInDb.Entity.MarkAsPublished();

            await this.dbContext.SaveChangesAsync();

            return review.Id;
        }

        public async Task<int> UpdateAsync(int raiting, string description, int id, string userId)
        {
            var review = await dbContext.Reviews.FindAsync(id);

            if (review.UserId != userId)
            {
                return -1;
            }

            review.Raiting = raiting;
            review.Description = description;

            dbContext.Reviews.Update(review);

            await dbContext.SaveChangesAsync();

            return review.Id;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var review = await dbContext.Reviews.FindAsync(id);

            if (review.UserId != userId)
            {
                return false;
            }

            dbContext.Reviews.Remove(review);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
