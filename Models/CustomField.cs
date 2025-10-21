using InventoryManagement.Models; 
namespace InventoryManagement.Models 
{
    public enum FieldType { SingleLine, MultiLine, Number, Link, Boolean }

    public class CustomField
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public FieldType Type { get; set; } = FieldType.SingleLine;
        public int Order { get; set; } = 0;
        public bool ShowInTable { get; set; } = false;
    }
}
