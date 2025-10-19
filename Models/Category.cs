using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        // ✅ Navigation property for related entities
        public ICollection<Inventory>? Inventories { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
