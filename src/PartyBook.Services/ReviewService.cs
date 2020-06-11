namespace PartyBook.Services
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.Data;
    using PartyBook.Data.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext dbContext;

        public ReviewService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<int>> GetAsync(string nightClubId)
            => await this.dbContext
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

            await this.dbContext.Reviews.AddAsync(review);

            await this.dbContext.SaveChangesAsync();

            return review.Id;
        }

        public async Task<int> UpdateAsync(int raiting, string description, int id, string userId)
        {
            var review = await this.dbContext.Reviews.FindAsync(id);

            if (review.UserId != userId)
            {
                return -1;
            }

            review.Raiting = raiting;
            review.Description = description;

            this.dbContext.Reviews.Update(review);

            await this.dbContext.SaveChangesAsync();

            return review.Id;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var review = await this.dbContext.Reviews.FindAsync(id);

            if (review.UserId != userId)
            {
                return false;
            }

            this.dbContext.Reviews.Remove(review);
            return (await this.dbContext.SaveChangesAsync()) > 0;
        }
    }
}
