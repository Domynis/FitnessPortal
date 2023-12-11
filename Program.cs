using FitnessPortal.Authentication;
using FitnessPortal.Components;
using FitnessPortal.Data;
using FitnessPortal.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Razor Components and update the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();

// Add ProtectedSessionStorage for server-side Blazor
builder.Services.AddScoped<ProtectedSessionStorage>();

// Configure authentication services
builder.Services.AddAuthenticationCore();
builder.Services.AddAuthorization();
builder.Services.AddOptions();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodJournalService, FoodJournalService>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthentication();

// Add Entity Framework Core DbContext for the application
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
try
{
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // Use exception handler and HSTS in production
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
    }

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<ApplicationDbContext>();

        // Apply pending migrations
        dbContext.Database.Migrate();
    }

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseAntiforgery();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
    app.Run();
}
catch (Exception ex)
{
    // Handle any exceptions during startup and print details to the console
    Console.WriteLine(ex.ToString());
}
