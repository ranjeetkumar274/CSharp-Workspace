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

        public async Task<IEnumerable<Review>> GetAllReviewsAsync()
        {
            return await cont.Reviews
                .Include(r => r.User)
                .ToListAsync();
        }

        
        public async Task<Review?> GetReviewByIdAsync(int id)
        {
            return await cont.Reviews
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.ReviewId == id);
        }

        public async Task<Review> CreateReviewAsync(Review review)
        {
           
            if (review.Rating < 1 || review.Rating > 5)
                throw new Exception("Rating must be between 1 and 5.");

           
            bool alreadyReviewed = await cont.Reviews
                .AnyAsync(r => r.UserId == review.UserId);

            if (alreadyReviewed)
                throw new Exception("User has already submitted a review.");

            review.DateCreated = DateTime.Now; 

            cont.Reviews.Add(review);
            await cont.SaveChangesAsync();
            return review;
        }

        
        public async Task<Review?> UpdateReviewAsync(int id, Review updatedReview)
        {
            var review = await cont.Reviews.FindAsync(id);
            if (review == null) return null;

            if (updatedReview.Rating < 1 || updatedReview.Rating > 5)
                throw new Exception("Rating must be between 1 and 5.");

            review.Subject = updatedReview.Subject;
            review.Body = updatedReview.Body;
            review.Rating = updatedReview.Rating;

            await cont.SaveChangesAsync();
            return review;
        }

     
        public async Task<bool> DeleteReviewAsync(int id)
        {
            var review = await cont.Reviews.FindAsync(id);
            if (review == null) return false;

            cont.Reviews.Remove(review);
            await cont.SaveChangesAsync();
            return true;
        }
    }
}