using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> GetBookingByIdAsync(long id)
        {
            return await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(long userId)
        {
            return await _context.Bookings
                .Include(b => b.PartyHall)
                .Include(b => b.User)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings
                .Include(b => b.PartyHall)
                .Include(b => b.User)
                .ToListAsync();
        }

       public async Task<Booking> AddBookingAsync(Booking booking)
        {
            if (booking.NoOfPersons < 1)
                throw new ArgumentException("NoOfPersons must be at least 1.");
            if (booking.NoOfPersons > 1500)
                throw new ArgumentException("NoOfPersons must be less than or equal to capacity.");
 
            if (booking.FromDate == default)
                throw new ArgumentException("FromDate is required.");
 
            if (booking.ToDate == default)
                throw new ArgumentException("ToDate is required.");
 
            if (booking.TotalPrice < 0)
                throw new ArgumentException("Total Price must be a positive value.");
 
            if (string.IsNullOrWhiteSpace(booking.Address))
                throw new ArgumentException("Address is required.");
 
            if (booking.UserId <= 0)
                throw new ArgumentException("UserId is required.");
            var userExists = await _context.Users.AnyAsync(u => u.UserId == booking.UserId);
            if (!userExists)
                throw new ArgumentException("User not found.");
 
            if (booking.PartyHallId <= 0)
                throw new ArgumentException("PartyHallId is required.");
            var hallExists = await _context.PartyHalls.AnyAsync(p => p.PartyHallId == booking.PartyHallId);
            if (!hallExists)
                throw new ArgumentException("PartyHall not found.");
 
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
 

        public async Task DeleteBookingAsync(long id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateBookingStatusAsync(long id, string newStatus)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking == null)
                throw new Exception("Booking not found.");

            booking.Status = newStatus;
            await _context.SaveChangesAsync();
        }
    }
}