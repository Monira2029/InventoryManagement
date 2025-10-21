using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement.Models
{
    public class Inventory
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    // image stored as external URL (do not upload to server)
    public string? ImageUrl { get; set; }

    public bool IsPublic { get; set; } = false;
    public string CreatedById { get; set; } = string.Empty; // IdentityUser.Id
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public class InventorySequence { public int InventoryId {get;set;} public long NextValue {get;set;} }

    public ICollection<InventoryTag>? InventoryTags { get; set; }
    public ICollection<CustomField>? CustomFields { get; set; }
    public ICollection<InventoryAccess>? AccessList { get; set; }
    public string? CustomIdTemplateJson { get; set; } // JSON array of elements and format

}

}

   
