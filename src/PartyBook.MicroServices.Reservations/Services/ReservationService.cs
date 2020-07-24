namespace PartyBook.MicroServices.Reservations.Services
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.Reservations.Data;
    using PartyBook.MicroServices.Reservations.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReservationService : IReservationService
    {
        private readonly ReservationDbContext dbContext;

        public ReservationService(ReservationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string telephoneNumber, int numberOfPeaople, DateTime when, string nightClubId, string userId, string nightClubOwnerId, string message = "")
        {
            var bookRequest = new Reservation()
            {
                NumberOfPeople = numberOfPeaople,
                TelephoneNumber = telephoneNumber,
                Message = message,
                When = when,
                NightClubId = nightClubId,
                NightClubOwnerId = nightClubOwnerId,
                UserId = userId,
            };

            await dbContext.Reservations.AddAsync(bookRequest);

            await dbContext.SaveChangesAsync();

            return bookRequest.Id;
        }

        public async Task<int> ApproveAsync(int id, bool isApproved, string userId)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (reservation.NightClubOwnerId != userId)
            {
                return -1;
            }

            reservation.IsApproved = isApproved;

            dbContext.Reservations.Update(reservation);

            await dbContext.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<int> RejectAsync(int id, bool isRejected, string userId)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (reservation.NightClubOwnerId != userId)
            {
                return -1;
            }

            reservation.IsRejected = isRejected;

            dbContext.Reservations.Update(reservation);

            await dbContext.SaveChangesAsync();

            return reservation.Id;
        }

        public async Task<IEnumerable<int>> GetPendigByUserId(string userId)
            => (await dbContext.Reservations.Where(x => x.NightClubOwnerId == userId && x.IsApproved == false && x.IsRejected == false).ToListAsync()).Select(x => x.Id).ToArray();
    }
}
