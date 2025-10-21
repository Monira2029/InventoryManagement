using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    public class ItemFieldValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }

        public Item? Item { get; set; }

        // Foreign key to CustomField (or however you named it)
        [Required]
        public int FieldId { get; set; }

        [Required]
        public string Value { get; set; } = string.Empty;
    }
}
