namespace PartyBook.MicroServices.NightClub.Services
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.NightClub.Data;
    using PartyBook.MicroServices.NightClub.Data.Models;
    using System;
    using System.Threading.Tasks;

    public class BookService : IBookService
    {
        private readonly NightClubDbContext dbContext;

        public BookService(NightClubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateAsync(string telephoneNumber, int numberOfPeaople, DateTime when, string nightClubId, string userId, string message = "")
        {
            var bookRequest = new BookRequest()
            {
                NumberOfPeople = numberOfPeaople,
                TelephoneNumber = telephoneNumber,
                Message = message,
                When = when,
                NightClubId = nightClubId,
                UserId = userId,
            };

            await dbContext.BookRequests.AddAsync(bookRequest);

            await dbContext.SaveChangesAsync();

            return bookRequest.Id;
        }

        public async Task<int> UpdateStatusAsync(bool status, int id, string userId)
        {
            var bookRequest = await dbContext.BookRequests.Include(x => x.NightClub).FirstOrDefaultAsync(x => x.Id == id);

            if (bookRequest.NightClub.UserId != userId)
            {
                return -1;
            }

            dbContext.BookRequests.Update(bookRequest);

            await dbContext.SaveChangesAsync();

            return bookRequest.Id;
        }
    }
}
