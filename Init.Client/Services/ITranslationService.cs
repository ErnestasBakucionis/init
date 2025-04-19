using Init.Client.Models;

namespace Init.Client.Services;

public interface ITranslationService
{
    string CurrentLanguage { get; }
    event Action? OnLanguageChanged;

    Task LoadTranslationsAsync(string language);
    string Translate(string key);

    LanguageOption[] GetAvailableLanguages();
}
