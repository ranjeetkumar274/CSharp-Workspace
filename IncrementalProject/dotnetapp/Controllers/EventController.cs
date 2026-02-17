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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
        return await _context.Events
            .Include(evt => evt.Attendees)
            .ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var evt = await _context.Events
            .Include(e => e.Attendees)
            .FirstOrDefaultAsync(e => e.Eventld == id);

        if (evt == null)
        {
            return NotFound();
        }

        return evt;
    }

    [HttpPost]
    public async Task<ActionResult<Event>> CreateEvent(Event evt)
    {
        _context.Events.Add(evt);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEvent), new { id = evt.Eventld }, evt);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEvent(int id, Event evt)
    {
        if (id != evt.Eventld)
        {
            return BadRequest();
        }

        _context.Entry(evt).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        var evt = await _context.Events.FindAsync(id);
        if (evt == null)
        {
            return NotFound();
        }

        _context.Events.Remove(evt);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}