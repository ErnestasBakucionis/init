using Init.Client.Models;
using System.Text.Json;

namespace Init.Client.Services;

public class TranslationService : ITranslationService
{
    private readonly HttpClient _frontendHttpClient;
    private Dictionary<string, string> _translations = new();

    public string CurrentLanguage { get; private set; } = "en";

    private readonly LanguageOption[] _availableLanguages = new[]
    {
        new LanguageOption("en", "English", "🇬🇧"),
        new LanguageOption("lt", "Lietuvių", "🇱🇹")
    };

    public event Action? OnLanguageChanged;

    public TranslationService(IHttpClientFactory clientFactory)
    {
        _frontendHttpClient = clientFactory.CreateClient("FrontendClient");
    }

    public LanguageOption[] GetAvailableLanguages() => _availableLanguages;

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