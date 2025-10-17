namespace InventoryManagement.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string CustomId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
