using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Init.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");

if (string.IsNullOrEmpty(apiBaseUrl))
{
    throw new InvalidOperationException("API Base URL is not configured in appsettings.json.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

await builder.Build().RunAsync();
