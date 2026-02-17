using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EventController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("GetEvents")]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        try
        {
            var events = await _context.Events
                .Include(evt => evt.Attendees)
                .ToListAsync();

            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }

    [HttpPost("PostEvent")]
    public async Task<ActionResult<Event>> PostEvent(Event eventObj)
    {
        try
        {
            _context.Events.Add(eventObj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), new { id = eventObj.Eventld }, eventObj);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }

    [HttpPut("PutEvent/{id:int}")]
    public async Task<IActionResult> PutEvent(int id, Event eventObj)
    {
        try
        {
            if (id != eventObj.Eventld)
            {
                return BadRequest(new { Message = "Event ID mismatch" });
            }

            _context.Entry(eventObj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Events.AnyAsync(e => e.Eventld == id))
            {
                return NotFound(new { Message = "Event not found" });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Concurrency conflict" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }

    [HttpDelete("DeleteEvent/{id:int}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        try
        {
            var evt = await _context.Events.FindAsync(id);
            if (evt == null)
            {
                return NotFound(new { Message = "Event not found" });
            }

            _context.Events.Remove(evt);
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
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        try
        {
            var evt = await _context.Events
                .Include(e => e.Attendees)
                .FirstOrDefaultAsync(e => e.Eventld == id);

            if (evt == null)
            {
                return NotFound(new { Message = "Event not found" });
            }

            return Ok(evt);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { Message = ex.Message });
        }
    }
}
