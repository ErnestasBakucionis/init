using Init.Client.Constants;
using Init.Client.Models;
using Init.Client.Services;

namespace Init.Client.Data;

public static class SearchData
{
    public static List<SearchResultItem> GetSearchItems(ITranslationService translationService)
    {
        var allItems = new List<SearchResultItem>
        {
            // Pages
            new SearchResultItem { Title = translationService.Translate("HOME"), Path = AppRoutes.Home, Category = translationService.Translate("PAGES") },
            new SearchResultItem { Title = translationService.Translate("ABOUT"), Path = AppRoutes.About, Category = translationService.Translate("PAGES") },
            new SearchResultItem { Title = translationService.Translate("SERVICES"), Path = AppRoutes.Services, Category = translationService.Translate("PAGES") },
            new SearchResultItem { Title = translationService.Translate("CONTACTS"), Path = AppRoutes.Contact, Category = translationService.Translate("PAGES") },

            // FAQs (test)
            new SearchResultItem { Title = translationService.Translate("HOW_TO_CONTACT_SUPPORT"), Path = "/faq/contact-support", Category = "FAQs" },

            // Articles (test)
            new SearchResultItem { Title = translationService.Translate("GETTING_STARTED"), Path = "/articles/getting-started", Category = "Articles" }
        };

        return allItems;
    }
}
