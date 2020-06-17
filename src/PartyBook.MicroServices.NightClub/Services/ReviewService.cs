namespace PartyBook.MicroServices.NightClub.Services
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.NightClub.Data;
    using PartyBook.MicroServices.NightClub.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReviewService : IReviewService
    {
        private readonly NightClubDbContext dbContext;

        public ReviewService(NightClubDbContext dbContext)
        {
            this.dbContext = dbContext;
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

            await dbContext.Reviews.AddAsync(review);

            await dbContext.SaveChangesAsync();

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
