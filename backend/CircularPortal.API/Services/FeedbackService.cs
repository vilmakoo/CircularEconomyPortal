using CircularPortal.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CircularPortal.API.Services
{
    // Implementation of the IFeedbackService
    public class FeedbackService : IFeedbackService
    {
        private readonly AppDbContext _context;

        // Dependency Injection of the database context
        public FeedbackService(AppDbContext context)
        {
            _context = context;
        }

        // Saves the feedback to the database
        public async Task SaveFeedbackAsync(int userId, string message)
        {
            var feedback = new Feedback
            {
                UserId = userId,
                Message = message,
            };

            _context.Feedback.Add(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Feedback>> GetAllFeedbackAsync()
        {
            // Use ToListAsync to fetch all records from the Feedback DbSet
            return await _context.Feedback.ToListAsync();
        }
    }
}