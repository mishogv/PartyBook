//namespace PartyBook.Services
//{
//    using Microsoft.EntityFrameworkCore;
//    using PartyBook.Data.NightClub;
//    using PartyBook.Data.NightClub.Models;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Threading.Tasks;

//    public class EventService : IEventService
//    {
//        private readonly NightClubDbContext dbContext;

//        public EventService(NightClubDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public async Task<IEnumerable<int>> GetAsync()
//            => await this.dbContext
//                .Events
//                .Where(x => x.When.CompareTo(DateTime.UtcNow) <= 0)
//                .OrderByDescending(x => x.When)
//                .Select(x => x.Id)
//                .ToListAsync();

//        public async Task<int> CreateAsync(string title, string description, string pictureUrl, DateTime when, string nightClubId)
//        {
//            var @event = new Event()
//            {
//                Title = title,
//                Description = description,
//                PictureUrl = pictureUrl,
//                When = when,
//                NightClubId = nightClubId,
//            };

//            await this.dbContext.Events.AddAsync(@event);

//            await this.dbContext.SaveChangesAsync();

//            return @event.Id;
//        }

//        public async Task<int> UpdateAsync(int id, string title, string description, string pictureUrl, DateTime when, string userId)
//        {
//            var @event = await this.dbContext.Events.Include(x => x.NightClub).FirstOrDefaultAsync(x => x.Id == id);

//            if (@event?.NightClub?.UserId != userId)
//            {
//                return -1;
//            }

//            @event.Title = title;
//            @event.Description = description;
//            @event.PictureUrl = pictureUrl;
//            @event.When = when;

//            this.dbContext.Events.Update(@event);

//            await this.dbContext.SaveChangesAsync();

//            return @event.Id;
//        }

//        public async Task<int> DeleteAsync(int id, string userId)
//        {
//            var @event = await this.dbContext.Events.Include(x => x.NightClub).FirstOrDefaultAsync(x => x.Id == id);

//            if (@event?.NightClub?.UserId != userId)
//            {
//                return -1;
//            }

//            this.dbContext.Remove(@event);

//            return await this.dbContext.SaveChangesAsync();
//        }
//    }
//}
