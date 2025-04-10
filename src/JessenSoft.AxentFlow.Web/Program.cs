using JessenSoft.AxentFlow.Infrastructure.Persistence;
using JessenSoft.AxentFlow.UI.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 🧩 Add MudBlazor services
builder.Services.AddMudServices();

// 🗃 Add EF Core with SQLite
builder.Services.AddDbContext<AxentFlowDbContext>(options =>
    options.UseSqlite("Data Source=axentflow.db"));

// 🧠 Add ReactiveUI ViewModels
builder.Services.AddScoped<DemoViewModel>();

// 🌐 Add HttpClient with NavigationManager for base URI
builder.Services.AddScoped(sp =>
{
    var navigation = sp.GetRequiredService<NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(navigation.BaseUri) };
});

// 🔐 Placeholder for authentication
// builder.Services.AddAuthentication().AddCookie();
// builder.Services.AddAuthorization();

// Optional: logging, multitenancy, etc.

var app = builder.Build();

// 🌱 Apply database migrations (optional, dev only)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AxentFlowDbContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔐 app.UseAuthentication();
// 🔐 app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();