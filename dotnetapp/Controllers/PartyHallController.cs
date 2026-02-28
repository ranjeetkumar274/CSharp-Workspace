using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyHallController : ControllerBase
    {
        private readonly PartyHallService ser;

        public PartyHallController(PartyHallService partyHallService)
        {
            ser = partyHallService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllPartyHalls()
        {
            var halls = await ser.GetAllPartyHallsAsync();
            return Ok(halls);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPartyHallById(long id)
        {
            var hall = await ser.GetPartyHallByIdAsync(id);
            if (hall == null)
                return NotFound(new { message = "Party Hall not found" });

            return Ok(hall);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreatePartyHall([FromBody] PartyHall partyHall)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await ser.CreatePartyHallAsync(partyHall);
                return CreatedAtAction(nameof(GetPartyHallById), new { id = created.PartyHallId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePartyHall(long id, [FromBody] PartyHall partyHall)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await ser.UpdatePartyHallAsync(id, partyHall);
            if (updated == null)
                return NotFound(new { message = "Party Hall not found" });

            return Ok(updated);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartyHall(long id)
        {
            var result = await ser.DeletePartyHallAsync(id);
            if (!result)
                return NotFound(new { message = "Party Hall not found" });

            return Ok(new { message = "Party Hall deleted successfully" });
        }
    }
}