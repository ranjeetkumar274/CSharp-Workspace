using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingService ser;

        public BookingController(BookingService bookingService)
        {
            ser = bookingService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await ser.GetAllBookingsAsync();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(long id)
        {
            var booking = await ser.GetBookingByIdAsync(id);
            if (booking == null)
                return NotFound(new { message = "Booking not found" });

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await ser.CreateBookingAsync(booking);
                return CreatedAtAction(nameof(GetBookingById), new { id = created.BookingId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(long id, [FromBody] Booking booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await ser.UpdateBookingAsync(id, booking);
            if (updated == null)
                return NotFound(new { message = "Booking not found" });

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(long id)
        {
            var result = await ser.DeleteBookingAsync(id);
            if (!result)
                return NotFound(new { message = "Booking not found" });

            return Ok(new { message = "Booking deleted successfully" });
        }
    }
}