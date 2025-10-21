namespace InventoryManagement.Models
{
    public class IdElement
    {
        public string Type { get; set; } = "";      // "fixed", "year", "random32", "guid", "sequence"
        public string Text { get; set; } = "";      // for fixed
        public string? Format { get; set; }         // optional format
        public int? Padding { get; set; }           // for sequence
    }
}
