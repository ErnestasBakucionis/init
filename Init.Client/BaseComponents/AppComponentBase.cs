using Init.Client.Services;
using Microsoft.AspNetCore.Components;

namespace Init.Client.BaseComponents;

public abstract class AppComponentBase : ComponentBase, IDisposable
{
    [Inject] protected ITranslationService TranslateService { get; set; }

    protected override void OnInitialized()
    {
        TranslateService.OnLanguageChanged += LanguageChanged;
    }

    private void LanguageChanged()
    {
        InvokeAsync(StateHasChanged);
    }

    public virtual void Dispose()
    {
        TranslateService.OnLanguageChanged -= LanguageChanged;
    }
}
