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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attendee>>> GetAttendees()
    {
        return await _context.Attendees
            .Include(attendee => attendee.Event)
            .ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Attendee>> GetAttendee(int id)
    {
        var attendee = await _context.Attendees
            .Include(attendee => attendee.Event)
            .FirstOrDefaultAsync(att => att.Attendeeld == id);

        if (attendee == null)
        {
            return NotFound();
        }

        return attendee;
    }

    [HttpPost]
    public async Task<ActionResult<Attendee>> CreateAttendee(Attendee attendee)
    {
        _context.Attendees.Add(attendee);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAttendee), new { id = attendee.Attendeeld }, attendee);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAttendee(int id, Attendee attendee)
    {
        if (id != attendee.Attendeeld)
        {
            return BadRequest();
        }

        _context.Entry(attendee).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAttendee(int id)
    {
        var attendee = await _context.Attendees.FindAsync(id);
        if (attendee == null)
        {
            return NotFound();
        }

        _context.Attendees.Remove(attendee);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}