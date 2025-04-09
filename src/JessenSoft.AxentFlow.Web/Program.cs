using JessenSoft.AxentFlow.UI.ViewModels;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 🧩 Add MudBlazor services
builder.Services.AddMudServices();

// 🧠 Add ReactiveUI ViewModels
builder.Services.AddScoped<DemoViewModel>();

// 🔐 Placeholder for authentication
// builder.Services.AddAuthentication().AddCookie();
// builder.Services.AddAuthorization();

// 🌐 Add HTTP client(s) if needed
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Environment.EnvironmentName) });

// Optional: add logging, configuration, multitenancy middleware, etc.

var app = builder.Build();

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