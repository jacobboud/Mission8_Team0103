using System;
using System.ComponentModel.DataAnnotations;

namespace Mission8_Team0103.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        

        [Required]
        public required string TaskName { get; set; } // Add required

        public DateTime? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; } // ✅ Allow it to be null

        public bool Completed { get; set; } = false;
    }

}