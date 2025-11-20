using Microsoft.AspNetCore.Mvc;
using CircularPortal.API.Data;
using CircularPortal.API.Models;

namespace CircularPortal.API.Controllers;

[ApiController]
[Route("[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly AppDbContext _context;

    public FeedbackController(AppDbContext context)
    {
        _context = context;
    }

    // POST: /feedback
    [HttpPost]
    public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
    {
        // Simulate user 1
        feedback.UserId = 1; 
        feedback.CreatedAt = DateTime.UtcNow;

        _context.Feedbacks.Add(feedback);
        await _context.SaveChangesAsync();

        // Return 201 Created
        return CreatedAtAction(nameof(PostFeedback), new { id = feedback.Id }, feedback);
    }
}