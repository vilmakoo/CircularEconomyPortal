namespace CircularPortal.API.Models;

public class WasteBin
{
    public int Id { get; set; }

    public string Address { get; set; } = string.Empty;

    public string EmptyingSchedule { get; set; } = string.Empty; // e.g., "Every Tuesday"

    public DateTime LastEmptiedAt { get; set; }
    
    public int UserId { get; set; } // Foreign Key
}