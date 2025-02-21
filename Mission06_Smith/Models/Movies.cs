using System.ComponentModel.DataAnnotations;

namespace Mission06_Smith.Models
{
    public class Movies
    {
        [Key]  // Primary key
        [Required]  // Must be provided
        public int MovieId { get; set; }

        [Required]  // Must be provided
        public string Category { get; set; }

        [Required]  // Must be provided
        public string Title { get; set; }

        [Required]  // Must be provided
        public int Year { get; set; }

        [Required]  // Must be provided
        public string Director { get; set; }

        [Required]  // Must be provided
        public string Rating { get; set; }

        public bool Edited { get; set; } = false;  // Default is false
        public string? LentTo { get; set; }  // Nullable field
        [StringLength(25)]  // Limits notes to 25 characters
        public string? Notes { get; set; }
    }
}