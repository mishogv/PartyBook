//namespace PartyBook.Services
//{
//    using System.Threading.Tasks;
//    using Microsoft.EntityFrameworkCore;
//    using PartyBook.Data.NightClub;
//    using PartyBook.Data.NightClub.Models;
//    using PartyBook.Services.Mapping;
//    using PartyBook.ViewModels.NightClub;

//    public class NightClubService : INightClubService
//    {
//        private readonly NightClubDbContext dbContext;

//        public NightClubService(NightClubDbContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }

//        public async Task<NightClubCreateViewModel> GetByIdAsync(string id)
//            => (await this.dbContext.NightClubs.FindAsync(id))?.MapTo<NightClubCreateViewModel>();

//        public async Task<NightClubCreateViewModel> GetByNameAsync(string name)
//            => (await this.dbContext.NightClubs.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()))?.MapTo<NightClubCreateViewModel>();

//        public async Task<NightClubCreateViewModel> CreateAsync(string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations, string userId)
//        {
//            var nightClub = new NightClub() { Name = name, CoverUrl = coverUrl, Description = description, BusinessHours = businessHours, Location = location, TelephoneForReservations = telephoneForReservations, UserId = userId };

//            await this.dbContext.NightClubs.AddAsync(nightClub);

//            await this.dbContext.SaveChangesAsync();

//            return nightClub.MapTo<NightClubCreateViewModel>();
//        }

//        public async Task<NightClubCreateViewModel> UpdateAsync(string id, string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations)
//        {
//            var nightClub = await this.dbContext.NightClubs.FindAsync(id);

//            nightClub.Name = name;
//            nightClub.CoverUrl = coverUrl;
//            nightClub.Description = description;
//            nightClub.BusinessHours = businessHours;
//            nightClub.Location = location;
//            nightClub.TelephoneForReservations = telephoneForReservations;

//            this.dbContext.Update(nightClub);
//            await this.dbContext.SaveChangesAsync();

//            return nightClub.MapTo<NightClubCreateViewModel>();
//        }

//        public async Task<bool> DeleteAsync(string id)
//        {
//            var nightClub = await this.dbContext.NightClubs.FindAsync(id);

//            this.dbContext.NightClubs.Remove(nightClub);
//            return (await this.dbContext.SaveChangesAsync()) > 0;
//        }
//    }
//}
