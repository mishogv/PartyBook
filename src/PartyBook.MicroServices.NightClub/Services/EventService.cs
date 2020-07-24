namespace PartyBook.MicroServices.NightClub.Services
{
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.NightClub.Data;
    using PartyBook.MicroServices.NightClub.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly NightClubDbContext dbContext;

        public EventService(NightClubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<int>> GetAsync()
            => await dbContext
                .Events
                .Where(x => x.When.CompareTo(DateTime.UtcNow) <= 0)
                .OrderByDescending(x => x.When)
                .Select(x => x.Id)
                .ToListAsync();

        public async Task<int> CreateAsync(string title, string description, string pictureUrl, DateTime when, string nightClubId)
        {
            var @event = new Event()
            {
                Title = title,
                Description = description,
                PictureUrl = pictureUrl,
                When = when,
                NightClubId = nightClubId,
            };

            await dbContext.Events.AddAsync(@event);

            await dbContext.SaveChangesAsync();

            return @event.Id;
        }

        public async Task<int> UpdateAsync(int id, string title, string description, string pictureUrl, DateTime when, string userId)
        {
            var @event = await dbContext.Events.Include(x => x.NightClub).FirstOrDefaultAsync(x => x.Id == id);

            if (@event?.NightClub?.UserId != userId)
            {
                return -1;
            }

            @event.Title = title;
            @event.Description = description;
            @event.PictureUrl = pictureUrl;
            @event.When = when;

            dbContext.Events.Update(@event);

            await dbContext.SaveChangesAsync();

            return @event.Id;
        }

        public async Task<int> DeleteAsync(int id, string userId)
        {
            var @event = await dbContext.Events.Include(x => x.NightClub).FirstOrDefaultAsync(x => x.Id == id);

            if (@event?.NightClub?.UserId != userId)
            {
                return -1;
            }

            dbContext.Remove(@event);

            return await dbContext.SaveChangesAsync();
        }
    }
}
