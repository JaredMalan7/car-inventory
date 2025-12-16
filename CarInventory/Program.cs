using CarInventory.Components;
using CarInventory.Data;
using CarInventory.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// === Configure SQLite Database ===
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=carinventory.db"));

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Antiforgery is required for EditForm posts (e.g., /login)
builder.Services.AddAntiforgery();

// === App Services ===
builder.Services.AddScoped<CarService>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// === Ensure DB is created ===
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// === Middleware ===
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();