using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext cont;

        public ReviewService(ApplicationDbContext context)
        {
            cont = context;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await cont.Reviews
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            cont.Reviews.Add(review);
            await cont.SaveChangesAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(long userId)
        {
            return await cont.Reviews
                .Include(r => r.User)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
    }
}