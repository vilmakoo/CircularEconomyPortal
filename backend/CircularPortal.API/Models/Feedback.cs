namespace CircularPortal.API.Models;

public class Feedback
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Message { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}