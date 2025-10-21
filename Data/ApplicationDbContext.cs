using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;

namespace InventoryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<InventoryTag> InventoryTags { get; set; }
        public DbSet<InventoryAccess> InventoryAccesses { get; set; }
        public DbSet<CustomField> CustomFields { get; set; }
        public DbSet<ItemFieldValue> ItemFieldValues { get; set; }
        public DbSet<ItemLike> ItemLikes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InventoryTag>()
                .HasKey(it => new { it.InventoryId, it.TagId });

            modelBuilder.Entity<InventoryTag>()
                .HasOne(it => it.Inventory)
                .WithMany(i => i.InventoryTags)
                .HasForeignKey(it => it.InventoryId);

            modelBuilder.Entity<InventoryTag>()
                .HasOne(it => it.Tag)
                .WithMany(t => t.InventoryTags)
                .HasForeignKey(it => it.TagId);
        }
    }
}
