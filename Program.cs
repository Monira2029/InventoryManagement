using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Data;
using Blazored.LocalStorage;
using InventoryManagement.Services;
using InventoryManagement.Hubs;
using InventoryManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// --- Database ---
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // or UseSqlServer

// --- Identity ---
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // adjust as needed
})
.AddRoles<IdentityRole>()                     // Add role support
.AddEntityFrameworkStores<ApplicationDbContext>(); // link to your DbContext

// --- Custom services ---
builder.Services.AddScoped<ICustomIdGenerator, CustomIdGenerator>();

// --- Blazor and SignalR ---
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();

// --- Third-party services ---
builder.Services.AddBlazoredLocalStorage();

var app = builder.Build();

// --- Seed data ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        await SeedData.EnsureSeedData(services); // your own seeding method
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error seeding: {ex.Message}");
    }
}

// --- Middleware ---
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();  // ✅ Only once
app.UseAuthorization();   // ✅ Only once

// --- Endpoints ---
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Map SignalR hub
app.MapHub<DiscussionHub>("/hubs/discussion");

await app.RunAsync();
