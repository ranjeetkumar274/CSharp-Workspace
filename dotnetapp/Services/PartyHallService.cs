using dotnetapp.Models;
using dotnetapp.Data;
using dotnetapp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class PartyHallService
    {
        private readonly ApplicationDbContext cont;

        public PartyHallService(ApplicationDbContext context)
        {
            cont = context;
        }

        public async Task<IEnumerable<PartyHall>> GetAllPartyHallsAsync()
        {
            return await cont.PartyHalls.ToListAsync();
        }

        public async Task<PartyHall> AddPartyHallAsync(PartyHall partyHall)
        {
            bool exists = await cont.PartyHalls
                .AnyAsync(p => p.HallName == partyHall.HallName);

            if (exists)
                throw new PartyHallException("A party hall with the same name already exists");

            cont.PartyHalls.Add(partyHall);
            await cont.SaveChangesAsync();
            return partyHall;
        }

        public async Task<PartyHall> UpdatePartyHallAsync(long id, PartyHall partyHall)
        {
            var existingHall = await cont.PartyHalls.FindAsync(id);
            if (existingHall == null) return null;

            existingHall.HallName = partyHall.HallName;
            existingHall.HallImageUrl = partyHall.HallImageUrl;
            existingHall.HallLocation = partyHall.HallLocation;
            existingHall.HallAvailableStatus = partyHall.HallAvailableStatus;
            existingHall.Price = partyHall.Price;
            existingHall.Capacity = partyHall.Capacity;
            existingHall.Description = partyHall.Description;

            await cont.SaveChangesAsync();
            return existingHall;
        }

        public async Task<PartyHall> DeletePartyHallAsync(long id)
        {
            var partyHall = await cont.PartyHalls.FindAsync(id);
            if (partyHall == null) return null;

            cont.PartyHalls.Remove(partyHall);
            await cont.SaveChangesAsync();
            return partyHall;
        }

        public async Task<PartyHall> GetPartyHallByIdAsync(long id)
        {
            return await cont.PartyHalls.FirstOrDefaultAsync(p => p.PartyHallId == id);
        }
    }
}