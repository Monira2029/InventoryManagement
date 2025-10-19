using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey(nameof(Supplier))]
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
