using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Data
{
    public static class SeedData
    {
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "User" };

            // ✅ 1️⃣ Ensure Roles Exist
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // ✅ 2️⃣ Create Default Admin User
            string adminEmail = "admin@example.com";
            string adminPassword = "Admin@12345";

            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var createResult = await userManager.CreateAsync(adminUser, adminPassword);
                if (createResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    Console.WriteLine($"✅ Admin user created: {adminEmail}");
                }
                else
                {
                    Console.WriteLine("❌ Failed to create admin user:");
                    foreach (var error in createResult.Errors)
                        Console.WriteLine($" - {error.Description}");
                }
            }
            else
            {
                Console.WriteLine("ℹ️ Admin user already exists.");
                if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    Console.WriteLine("✅ Admin role assigned to existing admin.");
                }
            }

            Console.WriteLine("✅ Role and user seeding complete.");
        }
    }
}
