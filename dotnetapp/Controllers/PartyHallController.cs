using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartyHallController : ControllerBase
    {
        private readonly PartyHallService partySer;

        public PartyHallController(PartyHallService partyHallService)
        {
            partySer = partyHallService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartyHall>>> Get()
        {
            var partyHalls = await partySer.GetAllPartyHallsAsync();
            return Ok(partyHalls);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PartyHall partyHall)
        {
            try
            {
                if (partyHall == null)
                    return BadRequest("Party hall data is null");

                partyHall.Bookings = null;

                var created = await partySer.AddPartyHallAsync(partyHall);
                return StatusCode(201, created);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{PartyHallId}")]
        public async Task<IActionResult> Put(long PartyHallId, [FromBody] PartyHall partyHall)
        {
            try
            {
                if (partyHall == null || PartyHallId != partyHall.PartyHallId)
                    return BadRequest("Invalid party hall data or ID mismatch");

                var updated = await partySer.UpdatePartyHallAsync(PartyHallId, partyHall);
                if (updated == null)
                    return NotFound();

                return Ok(updated);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{PartyHallId}")]
        public async Task<IActionResult> Delete(long PartyHallId)
        {
            try
            {
                var deleted = await partySer.DeletePartyHallAsync(PartyHallId);
                if (deleted == null)
                    return NotFound();

                return Ok(deleted);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{PartyHallId}")]
        public async Task<ActionResult<PartyHall>> Get(long PartyHallId)
        {
            try
            {
                var partyHall = await partySer.GetPartyHallByIdAsync(PartyHallId);
                if (partyHall == null)
                    return NotFound();

                return Ok(partyHall);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}