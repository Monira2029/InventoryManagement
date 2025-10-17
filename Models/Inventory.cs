using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Inventory
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool IsPublic { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
