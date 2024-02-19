using parcelfy_blazor.Components;
using parcelfy_blazor.Components.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json")
   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
   .AddEnvironmentVariables()
   .Build();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<IParcelTrackerApiService, ParcelTrackerApiService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ParcelfyApi:BaseUrl")!);
    c.DefaultRequestHeaders.Add("Accept", "application/json");
})
.SetHandlerLifetime(TimeSpan.FromMinutes(5));  // Set lifetime to five minutes


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
