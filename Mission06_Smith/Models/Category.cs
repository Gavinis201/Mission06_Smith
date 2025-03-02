using System.ComponentModel.DataAnnotations;

namespace Mission06_Smith.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty; // Initialize to avoid CS8618

        public ICollection<Movies> Movies { get; set; } = new List<Movies>(); // Initialize to avoid CS8618
    }
}