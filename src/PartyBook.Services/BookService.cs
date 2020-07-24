//namespace PartyBook.Services
//{
//    using Microsoft.EntityFrameworkCore;
//    using PartyBook.Data.NightClub;
//    using PartyBook.Data.NightClub.Models;
//    using System;
//    using System.Threading.Tasks;

//    public class BookService : IBookService
//    {
//        private readonly NightClubDbContext dbContext;

//        public BookService(NightClubDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public async Task<int> CreateAsync(string telephoneNumber, int numberOfPeaople, DateTime when, string nightClubId, string userId, string message = "")
//        {
//            var bookRequest = new BookRequest()
//            {
//                NumberOfPeople = numberOfPeaople,
//                TelephoneNumber = telephoneNumber,
//                Message = message,
//                When = when,
//                NightClubId = nightClubId,
//                UserId = userId,
//            };

//            await this.dbContext.BookRequests.AddAsync(bookRequest);

//            await this.dbContext.SaveChangesAsync();

//            return bookRequest.Id;
//        }

//        public async Task<int> UpdateStatusAsync(bool status, int id, string userId)
//        {
//            var bookRequest = await this.dbContext.BookRequests.Include(x => x.NightClub).FirstOrDefaultAsync(x => x.Id == id);

//            if (bookRequest.NightClub.UserId != userId)
//            {
//                return -1;
//            }

//            this.dbContext.BookRequests.Update(bookRequest);

//            await this.dbContext.SaveChangesAsync();

//            return bookRequest.Id;
//        }
//    }
//}
