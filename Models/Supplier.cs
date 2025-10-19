using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        public string ContactEmail { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<Product>? Products { get; set; }
    }
}
