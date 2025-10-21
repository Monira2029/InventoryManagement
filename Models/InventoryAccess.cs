using InventoryManagement.Models; // ✅ Add this if referencing other models in same namespace

namespace InventoryManagement.Models // ✅ Ensure it's in the right namespace
{
    public class InventoryAccess
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public Inventory? Inventory { get; set; }

        public string UserId { get; set; } = string.Empty; // IdentityUser.Id
        public bool CanWrite { get; set; } = false;
    }
}
