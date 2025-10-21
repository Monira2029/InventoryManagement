using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public interface ICustomIdGenerator
    {
        Task<string> GenerateAsync(int inventoryId, List<IdElement> template);
    }
}
