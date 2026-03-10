using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _context.Reviews
                .Include(r => r.User)
                .ToListAsync();
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            if (review.UserId <= 0)
                throw new ArgumentException("UserId is required.");
            var userExists = await _context.Users.AnyAsync(u => u.UserId == review.UserId);
            if (!userExists)
                throw new ArgumentException("User not found.");

            if (string.IsNullOrWhiteSpace(review.Subject))
                throw new ArgumentException("Subject is required.");

            if (string.IsNullOrWhiteSpace(review.Body))
                throw new ArgumentException("Body is required.");

            if (review.Rating < 1 || review.Rating > 5)
                throw new ArgumentException("Rating must be between 1 and 5.");

            if (review.DateCreated == default)
                throw new ArgumentException("DateCreated is required.");

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return review;
        }


        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(long userId)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

         public async Task<IEnumerable<Review>> GetReviewsByPartyHallIdAsync(long partyHallId)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Where(r => r.PartyHallId == partyHallId)
                .OrderByDescending(r => r.DateCreated)
                .ToListAsync();
        }
    }
}