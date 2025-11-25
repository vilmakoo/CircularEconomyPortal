using System;
using System.ComponentModel.DataAnnotations;

namespace CircularPortal.API.Data
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        // The user who submitted the feedback (foreign key to the User table)
        public int UserId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty; 

        // Timestamp for when the feedback was created
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}