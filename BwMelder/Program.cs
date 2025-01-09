using BwMelder.Components;
using BwMelder.Data;
using BwMelder.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add Razor component rendering.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add database connection via EF Core.
// Use a supplied connection string or fall back to a default in the settings.
var connectionString = builder.Configuration["Database"] ?? builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<BwMelderDbContext>(options =>
    options.UseSqlite(connectionString)
);

// Add application services.
builder.Services.AddBwMelderServices();

// Set up authentication.
builder.Services.AddBwMelderAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapBwMelderEndpoints();

// Enable authentication.
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
