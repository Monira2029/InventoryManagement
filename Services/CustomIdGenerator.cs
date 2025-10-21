using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class CustomIdGenerator : ICustomIdGenerator
    {
        private readonly ApplicationDbContext _db;

        public CustomIdGenerator(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<string> GenerateAsync(int inventoryId, List<IdElement> template)
        {
            var parts = new List<string>();

            foreach (var e in template)
            {
                switch (e.Type.ToLower())
                {
                    case "fixed":
                        parts.Add(e.Text);
                        break;
                    case "year":
                        parts.Add(DateTime.UtcNow.ToString(e.Format ?? "yyyy"));
                        break;
                    case "random32":
                        parts.Add(RandomNumber32Formatted(e.Format));
                        break;
                    case "guid":
                        parts.Add(Guid.NewGuid().ToString("N"));
                        break;
                    case "sequence":
                        var seq = await GetNextSequence(inventoryId);
                        parts.Add(seq.ToString().PadLeft(e.Padding ?? 3, '0'));
                        break;
                }
            }

            return string.Join("-", parts);
        }

        private string RandomNumber32Formatted(string? format)
        {
            var rnd = new Random();
            return rnd.Next(0, int.MaxValue).ToString(format ?? "D8");
        }

        private Task<int> GetNextSequence(int inventoryId)
        {
            // TODO: implement real sequence logic from DB
            return Task.FromResult(1);
        }
    }
}
