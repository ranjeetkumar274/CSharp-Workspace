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

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await cont.Bookings
                .Include(b => b.User)
                .Include(b => b.PartyHall)
                .ToListAsync();
        }

        public async Task<Booking?> GetBookingByIdAsync(long id)
        {
            return await cont.Bookings
                .Include(b => b.User)
                .Include(b => b.PartyHall)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {

            bool isAvailable = !await cont.Bookings.AnyAsync(b =>
                b.PartyHallId == booking.PartyHallId &&
                b.Status != "Cancelled" &&
                b.FromDate < booking.ToDate &&
                b.ToDate > booking.FromDate);

            if (!isAvailable)
                throw new Exception("Party Hall is not available for the selected dates.");

            booking.Status = "Pending";

            cont.Bookings.Add(booking);
            await cont.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking?> UpdateBookingAsync(long id, Booking updatedBooking)
        {
            var booking = await cont.Bookings.FindAsync(id);
            if (booking == null) return null;

            booking.NoOfPersons = updatedBooking.NoOfPersons;
            booking.FromDate = updatedBooking.FromDate;
            booking.ToDate = updatedBooking.ToDate;
            booking.Status = updatedBooking.Status;
            booking.TotalPrice = updatedBooking.TotalPrice;
            booking.Address = updatedBooking.Address;
            booking.PartyHallId = updatedBooking.PartyHallId;

            await cont.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteBookingAsync(long id)
        {
            var booking = await cont.Bookings.FindAsync(id);
            if (booking == null) return false;

            cont.Bookings.Remove(booking);
            await cont.SaveChangesAsync();
            return true;
        }
    }
}