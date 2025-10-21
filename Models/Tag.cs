namespace InventoryManagement.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<InventoryTag>? InventoryTags { get; set; }
    }

    public class InventoryTag
    {
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
