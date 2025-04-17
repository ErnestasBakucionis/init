using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Init.Client.Services;
using Init.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var serverUrl = builder.Configuration.GetValue<string>("ServerUrl");
if (string.IsNullOrEmpty(serverUrl))
{
    throw new InvalidOperationException("API Base URL is not configured in appsettings.json.");
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(serverUrl) });

builder.Services.AddHttpClient("FrontendClient", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.Services.AddSingleton<ITranslationService, TranslationService>();

await InitializeAppAsync(builder);

async Task InitializeAppAsync(WebAssemblyHostBuilder builder)
{
    var serviceProvider = builder.Services.BuildServiceProvider();
    var translationService = serviceProvider.GetRequiredService<ITranslationService>();
    var jsRuntime = serviceProvider.GetRequiredService<IJSRuntime>();

    var lang = await jsRuntime.InvokeAsync<string>("localStorage.getItem", "lang") ?? "en";

    await translationService.LoadTranslationsAsync(lang);

    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    await builder.Build().RunAsync();
}
