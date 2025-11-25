using CircularPortal.API.Data;
using CircularPortal.API.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CircularPortal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        // DTO for incoming feedback data (Data Transfer Object)
        public class FeedbackRequest
        {
            public string Message { get; set; } = string.Empty;
        }

        // Dependency Injection of the Feedback Service
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // POST /feedback
        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] FeedbackRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest(new { message = "Feedback message cannot be empty." });
            }

            // Since there's no real authentication at this point, we hardcode the user ID 1
            const int simulatedUserId = 1;

            // Save the feedback using the Service Layer
            await _feedbackService.SaveFeedbackAsync(simulatedUserId, request.Message);

            // Return a standard 201 Created status, indicating successful receipt and storage.
            return StatusCode(201);
        }

        // GET /feedback
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedback()
        {
            var feedbackList = await _feedbackService.GetAllFeedbackAsync();
            return Ok(feedbackList);
        }
    }
}