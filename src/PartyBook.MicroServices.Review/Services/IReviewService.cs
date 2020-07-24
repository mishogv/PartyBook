namespace PartyBook.MicroServices.Review.Services
{
    using PartyBook.ViewModels.Review;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReviewService
    {
        Task<IEnumerable<ReviewGetViewModel>> GetAsync(string nightClubId);

        Task<int> CreateAsync(int raiting, string description, string userId, string nightClubId);

        Task<int> UpdateAsync(int raiting, string description, int id, string userId);

        Task<bool> DeleteAsync(int id, string userId);
    }
}
