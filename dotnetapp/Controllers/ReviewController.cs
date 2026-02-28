using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService ser;

        public ReviewController(ReviewService reviewService)
        {
            ser = reviewService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await ser.GetAllReviewsAsync();
            return Ok(reviews);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await ser.GetReviewByIdAsync(id);
            if (review == null)
                return NotFound(new { message = "Review not found" });

            return Ok(review);
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await ser.CreateReviewAsync(review);
                return CreatedAtAction(nameof(GetReviewById), new { id = created.ReviewId }, created);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await ser.UpdateReviewAsync(id, review);
                if (updated == null)
                    return NotFound(new { message = "Review not found" });

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var result = await ser.DeleteReviewAsync(id);
            if (!result)
                return NotFound(new { message = "Review not found" });

            return Ok(new { message = "Review deleted successfully" });
        }
    }
}
