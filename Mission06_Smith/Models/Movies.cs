using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Smith.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int Year { get; set; }

        [StringLength(100)]
        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Edited status is required")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Copied to Plex status is required")]
        public bool CopiedToPlex { get; set; }

        public string? Notes { get; set; }

        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}