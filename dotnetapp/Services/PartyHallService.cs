using dotnetapp.Models;
using dotnetapp.Data;
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
            return await cont.PartyHalls
                .Include(p => p.Bookings)
                .ToListAsync();
        }

    
        public async Task<PartyHall?> GetPartyHallByIdAsync(long id)
        {
            return await cont.PartyHalls
                .Include(p => p.Bookings)
                .FirstOrDefaultAsync(p => p.PartyHallId == id);
        }

        
        public async Task<PartyHall> CreatePartyHallAsync(PartyHall partyHall)
        {
           
            bool exists = await cont.PartyHalls
                .AnyAsync(p => p.HallName == partyHall.HallName);

            if (exists)
                throw new Exception("A Party Hall with this name already exists.");

            partyHall.HallAvailableStatus = "Available"; 

            cont.PartyHalls.Add(partyHall);
            await cont.SaveChangesAsync();
            return partyHall;
        }

        
        public async Task<PartyHall?> UpdatePartyHallAsync(long id, PartyHall updatedHall)
        {
            var partyHall = await cont.PartyHalls.FindAsync(id);
            if (partyHall == null) return null;

            partyHall.HallName = updatedHall.HallName;
            partyHall.HallImageUrl = updatedHall.HallImageUrl;
            partyHall.HallLocation = updatedHall.HallLocation;
            partyHall.HallAvailableStatus = updatedHall.HallAvailableStatus;
            partyHall.Price = updatedHall.Price;
            partyHall.Capacity = updatedHall.Capacity;
            partyHall.Description = updatedHall.Description;

            await cont.SaveChangesAsync();
            return partyHall;
        }

        
        public async Task<bool> DeletePartyHallAsync(long id)
        {
            var partyHall = await cont.PartyHalls.FindAsync(id);
            if (partyHall == null) return false;

            cont.PartyHalls.Remove(partyHall);
            await cont.SaveChangesAsync();
            return true;
        }
    }
}