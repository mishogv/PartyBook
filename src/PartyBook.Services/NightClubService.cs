namespace PartyBook.Services
{
    using System;
    using System.Threading.Tasks;
    using PartyBook.Data;
    using PartyBook.Data.Models;
    using PartyBook.ViewModels.NightClub;

    public class NightClubService : INightClubService
    {
        private readonly ApplicationDbContext dbContext;

        public NightClubService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<NightClubCreateViewModel> CreateAsync(string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations, string userId)
        {
            var user = await this.dbContext.Users.FindAsync(userId);
            var nightClub = new NightClub() { Name = name, CoverUrl = coverUrl, Description = description, BusinessHours = businessHours, TelephoneForReservations = telephoneForReservations, User = user };

            var result = await this.dbContext.NightClubs.AddAsync(nightClub);

            await this.dbContext.SaveChangesAsync();

            return new NightClubCreateViewModel() { Id = result.Entity.Id, Name = name, CoverUrl = coverUrl, Description = description, BusinessHours = businessHours, Location = location, TelephoneForReservations = telephoneForReservations };
        }

        public async Task<NightClubCreateViewModel> UpdateAsync(string id, string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations)
        {
            var nightClub = new NightClub
            {
                Id = id,
                Name = name,
                CoverUrl = coverUrl,
                Description = description,
                BusinessHours = businessHours,
                Location = location,
                TelephoneForReservations = telephoneForReservations
            };

            //TODO : Test if it works without Update only with tacking
            this.dbContext.Update(nightClub);
            await this.dbContext.SaveChangesAsync();

            return new NightClubCreateViewModel() { Id = nightClub.Id, Name = name, CoverUrl = coverUrl, Description = description, BusinessHours = businessHours, Location = location, TelephoneForReservations = telephoneForReservations };
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var nightClub = await this.dbContext.NightClubs.FindAsync(id);

            this.dbContext.NightClubs.Remove(nightClub);

            return (await this.dbContext.SaveChangesAsync()) > 0;
        }
    }
}
