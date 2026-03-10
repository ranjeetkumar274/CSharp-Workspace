using dotnetapp.Models;
using dotnetapp.Data;
using dotnetapp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class PartyHallService
    {
        private readonly ApplicationDbContext _context;

        public PartyHallService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PartyHall>> GetAllPartyHallsAsync()
        {
            return await _context.PartyHalls.ToListAsync();
        }

        public async Task<PartyHall> AddPartyHallAsync(PartyHall partyHall)
        {
            if (string.IsNullOrWhiteSpace(partyHall.HallName))
                throw new ArgumentException("HallName is required.");
 
            if (string.IsNullOrWhiteSpace(partyHall.HallLocation))
                throw new ArgumentException("HallLocation is required.");
 
            if (string.IsNullOrWhiteSpace(partyHall.HallAvailableStatus))
                throw new ArgumentException("HallAvailableStatus is required.");
 
            if (partyHall.Price < 0)
                throw new ArgumentException("Price must be a positive value.");
 
            if (partyHall.Capacity < 1)
                throw new ArgumentException("Capacity must be at least 1.");
 
            if (string.IsNullOrWhiteSpace(partyHall.Description))
                throw new ArgumentException("Description is required.");
 
            bool exists = await _context.PartyHalls
                .AnyAsync(p => p.HallName == partyHall.HallName);
 
            if (exists)
                throw new PartyHallException("A party hall with the same name already exists");
 
            _context.PartyHalls.Add(partyHall);
            await _context.SaveChangesAsync();
            return partyHall;
        }
 

        public async Task<PartyHall> UpdatePartyHallAsync(long id, PartyHall partyHall)
        {
            var existingHall = await _context.PartyHalls.FindAsync(id);
            if (existingHall == null) return null;

            existingHall.HallName = partyHall.HallName;
            existingHall.HallImageUrl = partyHall.HallImageUrl;
            existingHall.HallLocation = partyHall.HallLocation;
            existingHall.HallAvailableStatus = partyHall.HallAvailableStatus;
            existingHall.Price = partyHall.Price;
            existingHall.Capacity = partyHall.Capacity;
            existingHall.Description = partyHall.Description;

            await _context.SaveChangesAsync();
            return existingHall;
        }

        public async Task<PartyHall> DeletePartyHallAsync(long id)
        {
            var partyHall = await _context.PartyHalls.FindAsync(id);
            if (partyHall == null) return null;

            _context.PartyHalls.Remove(partyHall);
            await _context.SaveChangesAsync();
            return partyHall;
        }

        public async Task<PartyHall> GetPartyHallByIdAsync(long id)
        {
            return await _context.PartyHalls.FirstOrDefaultAsync(p => p.PartyHallId == id);
        }
    }
}