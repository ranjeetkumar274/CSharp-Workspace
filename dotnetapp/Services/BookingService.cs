using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext cont;

        public BookingService(ApplicationDbContext context)
        {
            cont = context;
        }

        public async Task<Booking> GetBookingByIdAsync(long id)
        {
            return await cont.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(long userId)
        {
            return await cont.Bookings
                .Include(b => b.PartyHall)
                .Include(b => b.User)
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await cont.Bookings
                .Include(b => b.PartyHall)
                .Include(b => b.User)
                .ToListAsync();
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            cont.Bookings.Add(booking);
            await cont.SaveChangesAsync();
            return booking;
        }

        public async Task DeleteBookingAsync(long id)
        {
            var booking = await cont.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking != null)
            {
                cont.Bookings.Remove(booking);
                await cont.SaveChangesAsync();
            }
        }

        public async Task UpdateBookingStatusAsync(long id, string newStatus)
        {
            var booking = await cont.Bookings.FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking == null)
                throw new Exception("Booking not found.");

            booking.Status = newStatus;
            await cont.SaveChangesAsync();
        }
    }
}