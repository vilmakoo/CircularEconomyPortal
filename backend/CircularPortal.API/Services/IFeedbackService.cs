using CircularPortal.API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CircularPortal.API.Services
{
    // Interface for the Feedback Service
    public interface IFeedbackService
    {
        // Method to save a new feedback message.
        Task SaveFeedbackAsync(int userId, string message);

        Task<List<Feedback>> GetAllFeedbackAsync();
    }
}