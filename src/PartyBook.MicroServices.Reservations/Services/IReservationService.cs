namespace PartyBook.MicroServices.Reservations.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReservationService
    {
        Task<int> CreateAsync(string telephoneNumber, int numberOfPeaople, DateTime when, string nightClubId, string userId, string nightClubOwnerId, string message = "");

        Task<int> ApproveAsync(int id, bool isApproved, string userId);

        Task<int> RejectAsync(int id, bool isRejected, string userId);

        Task<IEnumerable<int>> GetPendigByUserId(string userId);
    }
}
