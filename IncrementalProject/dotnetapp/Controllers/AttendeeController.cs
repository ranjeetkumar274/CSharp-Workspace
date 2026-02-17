using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendeeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AttendeeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetAttendees")]
    public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendees()
    {
        try
        {
            var attendees = await _context.Attendees
                .Include(attendee => attendee.Event)
                .ToListAsync();

            return Ok(attendees);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }

    [HttpPost("PostAttendee")]
    public async Task<ActionResult<Attendee>> PostAttendee(Attendee attendee)
    {
        try
        {
            _context.Attendees.Add(attendee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAttendee), new { id = attendee.Attendeeld }, attendee);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }

    [HttpPut("PutAttendee/{id:int}")]
    public async Task<IActionResult> PutAttendee(int id, Attendee attendee)
    {
        try
        {
            if (id != attendee.Attendeeld)
            {
                return BadRequest(new { Message = "Attendee ID mismatch" });
            }

            _context.Entry(attendee).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Attendees.AnyAsync(a => a.Attendeeld == id))
            {
                return NotFound(new { Message = "Attendee not found" });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Concurrency conflict" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }

    [HttpDelete("DeleteAttendee/{id:int}")]
    public async Task<IActionResult> DeleteAttendee(int id)
    {
        try
        {
            var attendee = await _context.Attendees.FindAsync(id);
            if (attendee == null)
            {
                return NotFound(new { Message = "Attendee not found" });
            }

            _context.Attendees.Remove(attendee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }

    // Optional: retain single-item fetch if needed elsewhere
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Attendee>> GetAttendee(int id)
    {
        try
        {
            var attendee = await _context.Attendees
                .Include(attendee => attendee.Event)
                .FirstOrDefaultAsync(att => att.Attendeeld == id);

            if (attendee == null)
            {
                return NotFound(new { Message = "Attendee not found" });
            }

            return Ok(attendee);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }
}
