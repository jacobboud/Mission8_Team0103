using System.ComponentModel.DataAnnotations;

namespace Mission8_Team0103.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public required string CategoryName { get; set; }
    }
}