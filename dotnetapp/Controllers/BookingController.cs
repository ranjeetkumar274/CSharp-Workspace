using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;
        private readonly UserService _userService;

        public BookingController(BookingService bookingService, UserService userService)
        {
            _bookingService = bookingService;
            _userService = userService;
        }

        [HttpGet("{bookingId}")]
        public async Task<IActionResult> GetBooking(long bookingId)
        {
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            if (booking == null)
                return NotFound();

            return Ok(booking);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBookingsByUserId(long userId)
        {
            try
            {
                var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
                return Ok(bookings);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsAsync();
                return Ok(bookings);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]

public async Task<IActionResult> AddBooking([FromBody] Booking booking)

{

    try

    {

        if (booking == null)

            return BadRequest("Booking data is null");

        if (booking.UserId > 0)

            booking.User = null;

        var existingBooking = await _bookingService.GetAllBookingsAsync();

        var conflict = existingBooking.FirstOrDefault(b =>

            b.PartyHallId == booking.PartyHallId &&

            b.Status != "Cancelled" &&

            booking.FromDate <= b.ToDate &&

            booking.ToDate >= b.FromDate

        );

        if (conflict != null)

        {

            return BadRequest(new

            {

                message = "This hall is already booked for the selected dates."

            });

        }

        var addedBooking = await _bookingService.AddBookingAsync(booking);

        var user = await _userService.GetUserByIdAsync(booking.UserId);

        return Ok(new { Booking = addedBooking, User = user });

    }

    catch (Exception)

    {

        return StatusCode(500, "Internal Server Error");

    }

}
 
 

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> DeleteBooking(long bookingId)
        {
            try
            {
                await _bookingService.DeleteBookingAsync(bookingId);
                return Ok(new { message = "Booking deleted successfully" });
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{bookingId}")]
        public async Task<IActionResult> UpdateBooking(long bookingId, [FromBody] Booking updatedBooking)
        {
            if (bookingId != updatedBooking.BookingId)
                return BadRequest("Booking ID mismatch");

            var existingBooking = await _bookingService.GetBookingByIdAsync(bookingId);
            if (existingBooking == null)
                return NotFound();

            await _bookingService.UpdateBookingStatusAsync(bookingId, updatedBooking.Status);

            var updated = await _bookingService.GetBookingByIdAsync(bookingId);
            return Ok(updated);
        }
    }
}
