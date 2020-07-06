namespace PartyBook.MicroServices.NightClub.Services
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using PartyBook.MicroServices.NightClub.Data;
    using PartyBook.Services.Mapping;
    using PartyBook.ViewModels.NightClub;
    using PartyBook.MicroServices.NightClub.Data.Models;
    using System.Collections.Generic;

    public class NightClubService : INightClubService
    {
        private readonly NightClubDbContext dbContext;

        public NightClubService(NightClubDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<NightClubGetAllViewModel>> GetAllAsync()
            => await this.dbContext.NightClubs.To<NightClubGetAllViewModel>().ToListAsync();

        public async Task<NightClubCreateViewModel> GetByIdAsync(string id)
            => (await dbContext.NightClubs.FindAsync(id))?.MapTo<NightClubCreateViewModel>();

        public async Task<NightClubCreateViewModel> GetByNameAsync(string name)
            => (await dbContext.NightClubs.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()))?.MapTo<NightClubCreateViewModel>();

        public async Task<NightClubCreateViewModel> CreateAsync(string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations, string userId)
        {
            var nightClub = new NightClub() { Name = name, CoverUrl = coverUrl, Description = description, BusinessHours = businessHours, Location = location, TelephoneForReservations = telephoneForReservations, UserId = userId };

            await dbContext.NightClubs.AddAsync(nightClub);

            await dbContext.SaveChangesAsync();

            return nightClub.MapTo<NightClubCreateViewModel>();
        }

        public async Task<NightClubCreateViewModel> UpdateAsync(string id, string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations)
        {
            var nightClub = await dbContext.NightClubs.FindAsync(id);

            nightClub.Name = name;
            nightClub.CoverUrl = coverUrl;
            nightClub.Description = description;
            nightClub.BusinessHours = businessHours;
            nightClub.Location = location;
            nightClub.TelephoneForReservations = telephoneForReservations;

            dbContext.Update(nightClub);
            await dbContext.SaveChangesAsync();

            return nightClub.MapTo<NightClubCreateViewModel>();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var nightClub = await dbContext.NightClubs.FindAsync(id);

            dbContext.NightClubs.Remove(nightClub);
            return await dbContext.SaveChangesAsync() > 0;
        }
    }
}
