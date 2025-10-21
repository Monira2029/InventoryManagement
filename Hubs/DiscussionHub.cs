using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace InventoryManagement.Hubs
{
    public class DiscussionHub : Hub
    {
        public async Task JoinInventory(int inventoryId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"inv-{inventoryId}");
        }

        public async Task LeaveInventory(int inventoryId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"inv-{inventoryId}");
        }

        public async Task SendComment(int inventoryId, string content, string userName)
        {
            var msg = new
            {
                InventoryId = inventoryId,
                Content = content,
                UserName = userName,
                CreatedAt = DateTime.UtcNow
            };

            await Clients.Group($"inv-{inventoryId}").SendAsync("ReceiveComment", msg);
        }
    }
}
