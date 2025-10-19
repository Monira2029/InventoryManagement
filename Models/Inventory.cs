using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public bool IsPublic { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
