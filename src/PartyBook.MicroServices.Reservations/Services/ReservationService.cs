namespace PartyBook.MicroServices.Reservations.Services
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.Reservations.Data;
    using PartyBook.MicroServices.Reservations.Data.Models;
    using System;
    using System.Threading.Tasks;

    public class ReservationService : IReservationService
    {
        private readonly ReservationDbContext dbContext;

        public ReservationService(ReservationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string telephoneNumber, int numberOfPeaople, DateTime when, string nightClubId, string userId, string message = "")
        {
            var bookRequest = new Reservation()
            {
                NumberOfPeople = numberOfPeaople,
                TelephoneNumber = telephoneNumber,
                Message = message,
                When = when,
                NightClubId = nightClubId,
                UserId = userId,
            };

            await dbContext.Reservations.AddAsync(bookRequest);

            await dbContext.SaveChangesAsync();

            return bookRequest.Id;
        }

        //TODO : Implement correctly
        public async Task<int> UpdateStatusAsync(bool status, int id, string userId)
        {
            var bookRequest = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            //if (bookRequest.NightClub.UserId != userId)
            //{
            //    return -1;
            //}

            dbContext.Reservations.Update(bookRequest);

            await dbContext.SaveChangesAsync();

            return bookRequest.Id;
        }
    }
}
