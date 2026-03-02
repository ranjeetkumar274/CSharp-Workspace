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
        private readonly PartyHallService _partyHallService;

        public PartyHallController(PartyHallService partyHallService)
        {
            _partyHallService = partyHallService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartyHall>>> Get()
        {
            var partyHalls = await _partyHallService.GetAllPartyHallsAsync();
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

                var created = await _partyHallService.AddPartyHallAsync(partyHall);
                return StatusCode(201, created);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut("{partyHallId}")]
        public async Task<IActionResult> Put(long partyHallId, [FromBody] PartyHall partyHall)
        {
            try
            {
                if (partyHall == null || partyHallId != partyHall.PartyHallId)
                    return BadRequest("Invalid party hall data or ID mismatch");

                var updated = await _partyHallService.UpdatePartyHallAsync(partyHallId, partyHall);
                if (updated == null)
                    return NotFound();

                return Ok(updated);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{partyHallId}")]
        public async Task<IActionResult> Delete(long partyHallId)
        {
            try
            {
                var deleted = await _partyHallService.DeletePartyHallAsync(partyHallId);
                if (deleted == null)
                    return NotFound();

                return Ok(deleted);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{partyHallId}")]
        public async Task<ActionResult<PartyHall>> Get(long partyHallId)
        {
            try
            {
                var partyHall = await _partyHallService.GetPartyHallByIdAsync(partyHallId);
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