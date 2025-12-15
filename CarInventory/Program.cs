using CarInventory.Components;
using CarInventory.Data;
using CarInventory.Models;
using CarInventory.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// === Configure SQLite Database ===
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=carinventory.db"));

// === Add Services ===
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options =>
    {
        options.DetailedErrors = true;
    });

builder.Services.AddScoped<CarService>();
builder.Services.AddHttpClient<VehicleLookupService>();

var app = builder.Build();

// === Ensure DB is created + apply migrations + seed ===
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Creates DB file + tables if missing
    db.Database.EnsureCreated();
}

// === Configure the HTTP request pipeline ===
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