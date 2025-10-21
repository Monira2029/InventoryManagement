using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        // 🔗 Foreign key to Inventory
        [Required]
        public int InventoryId { get; set; }

        public Inventory? Inventory { get; set; }

        // 🧾 Unique per Inventory, editable identifier
        [Required]
        [StringLength(50)]
        public string CustomId { get; set; } = string.Empty;

        // 🏷️ Main fields
        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Note { get; set; }

        // 📅 Metadata
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public string CreatedById { get; set; } = string.Empty;

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        // 🔗 Navigation properties
        public ICollection<ItemFieldValue>? FieldValues { get; set; }
        public ICollection<ItemLike>? Likes { get; set; }
    }
}
