﻿namespace PartyBook.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<NightClubCreateViewModel> GetByIdAsync(string id)
        {
            var nightClub = await this.dbContext.NightClubs.FindAsync(id);

            return new NightClubCreateViewModel() { Id = nightClub.Id, Name = nightClub.Name, CoverUrl = nightClub.CoverUrl, Description = nightClub.Description, BusinessHours = nightClub.BusinessHours, Location = nightClub.Location, TelephoneForReservations = nightClub.TelephoneForReservations };
        }

        public async Task<NightClubCreateViewModel> GetByNameAsync(string name)
        {
            var nightClub = await this.dbContext.NightClubs.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            return new NightClubCreateViewModel() { Id = nightClub.Id, Name = nightClub.Name, CoverUrl = nightClub.CoverUrl, Description = nightClub.Description, BusinessHours = nightClub.BusinessHours, Location = nightClub.Location, TelephoneForReservations = nightClub.TelephoneForReservations };
        }

        public async Task<NightClubCreateViewModel> CreateAsync(string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations, string userId)
        {
            var user = await this.dbContext.Users.FindAsync(userId);
            var nightClub = new NightClub() { Name = name, CoverUrl = coverUrl, Description = description, BusinessHours = businessHours, Location = location, TelephoneForReservations = telephoneForReservations, User = user };

            var result = await this.dbContext.NightClubs.AddAsync(nightClub);

            await this.dbContext.SaveChangesAsync();

            return new NightClubCreateViewModel() { Id = result.Entity.Id, Name = name, CoverUrl = coverUrl, Description = description, BusinessHours = businessHours, Location = location, TelephoneForReservations = telephoneForReservations };
        }

        public async Task<NightClubCreateViewModel> UpdateAsync(string id, string name, string coverUrl, string description, string businessHours, string location, string telephoneForReservations)
        {
            var nightClub = await this.dbContext.NightClubs.FindAsync(id);

            nightClub.Name = name;
            nightClub.CoverUrl = coverUrl;
            nightClub.Description = description;
            nightClub.BusinessHours = businessHours;
            nightClub.Location = location;
            nightClub.TelephoneForReservations = telephoneForReservations;

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
