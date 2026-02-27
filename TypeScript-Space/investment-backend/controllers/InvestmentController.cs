using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvestmentBackend.Data;
using InvestmentBackend.Models;

namespace InvestmentBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
 
        public InvestmentController(ApplicationDbContext context)
        {
            _context = context;
        }
 
        // =========================
        // BASIC CRUD
        // =========================
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Investment>>> GetAll()
        {
            return await _context.Investments.ToListAsync();
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<Investment>> GetById(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
 
            if (investment == null)
                return NotFound();
 
            return investment;
        }
 
        [HttpPost]
        public async Task<ActionResult<Investment>> Create(Investment investment)
        {
            investment.CreatedOn = DateTime.Now;
 
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();
 
            return CreatedAtAction(nameof(GetById),
                new { id = investment.InvestmentId },
                investment);
        }
 
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Investment investment)
        {
            if (id != investment.InvestmentId)
                return BadRequest();
 
            _context.Entry(investment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
 
            return NoContent();
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var investment = await _context.Investments.FindAsync(id);
 
            if (investment == null)
                return NotFound();
 
            _context.Investments.Remove(investment);
            await _context.SaveChangesAsync();
 
            return NoContent();
        }
 
        // =========================
        // SEARCH / FILTER / SORT
        // =========================
 
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<Investment>>> Search(string query)
        {
            return await _context.Investments
                .Where(i =>
                    i.InvestmentName.Contains(query) ||
                    i.Description.Contains(query) ||
                    i.Tags.Contains(query))
                .ToListAsync();
        }
 
        [HttpGet("SortByCreatedOn")]
        public async Task<ActionResult<IEnumerable<Investment>>> Sort(string order)
        {
            var data = order == "desc"
                ? _context.Investments.OrderByDescending(i => i.CreatedOn)
                : _context.Investments.OrderBy(i => i.CreatedOn);
 
            return await data.ToListAsync();
        }
 
        [HttpGet("FilterByRisk")]
        public async Task<ActionResult<IEnumerable<Investment>>> FilterByRisk(string riskLevel)
        {
            return await _context.Investments
                .Where(i => i.RiskLevel == riskLevel)
                .ToListAsync();
        }
 
        [HttpGet("SearchByAmountRange")]
        public async Task<ActionResult<IEnumerable<Investment>>> FilterByAmount(decimal min, decimal max)
        {
            return await _context.Investments
                .Where(i => i.InvestmentAmount >= min && i.InvestmentAmount <= max)
                .ToListAsync();
        }
 
        [HttpGet("FilterByType")]
        public async Task<ActionResult<IEnumerable<Investment>>> FilterByType(string type)
        {
            return await _context.Investments
                .Where(i => i.InvestmentType == type)
                .ToListAsync();
        }
    }
}