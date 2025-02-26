using System;
using System.ComponentModel.DataAnnotations;

namespace Mission8_Team0103.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        [Required]
        public string Quadrant { get; set; } // Quadrant I, II, III, IV

        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; } // Navigation Property

        public bool Completed { get; set; } = false; // Default to false
    }
}