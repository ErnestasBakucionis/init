using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Init.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var serverUrl = builder.Configuration.GetValue<string>("ServerUrl");

if (string.IsNullOrEmpty(serverUrl))
{
    throw new InvalidOperationException("API Base URL is not configured in appsettings.json.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(serverUrl) });

await builder.Build().RunAsync();
