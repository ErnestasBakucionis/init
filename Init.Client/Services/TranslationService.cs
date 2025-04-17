using System.Text.Json;

namespace Init.Client.Services;

public class TranslationService : ITranslationService
{
    private readonly HttpClient _frontendHttpClient;
    private Dictionary<string, string> _translations = new();

    public string CurrentLanguage { get; private set; } = "en";
    private readonly string[] _availableLanguages = new[] { "en", "lt" };

    public event Action? OnLanguageChanged;

    public TranslationService(IHttpClientFactory clientFactory)
    {
        _frontendHttpClient = clientFactory.CreateClient("FrontendClient");
    }

    public string[] GetAvailableLanguages() => _availableLanguages;

    public async Task LoadTranslationsAsync(string language)
    {
        var json = await _frontendHttpClient.GetStringAsync($"i18n/{language}.json");
        _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
                        ?? new Dictionary<string, string>();

        CurrentLanguage = language;
        OnLanguageChanged?.Invoke();
    }

    public string Translate(string key)
    {
        return _translations.TryGetValue(key, out var value) ? value : $"[{key}]";
    }
}
