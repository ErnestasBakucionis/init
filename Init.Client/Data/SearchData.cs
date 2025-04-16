using Init.Client.Constants;
using Init.Client.Models;

namespace Init.Client.Data;

public static class SearchData
{
    public static readonly List<SearchResultItem> AllItems = new()
    {
        // Pages
        new() { Title = "Home", Path = AppRoutes.Home, Category = "Pages" },
        new() { Title = "About", Path = AppRoutes.About, Category = "Pages" },
        new() { Title = "Services", Path = AppRoutes.Services, Category = "Pages" },
        new() { Title = "Contact", Path = AppRoutes.Contact, Category = "Pages" },

        // FAQs (test)
        new() { Title = "How to contact support?", Path = "/faq/contact-support", Category = "FAQs" },

        // Articles (test)
        new() { Title = "Getting Started with Our Services", Path = "/articles/getting-started", Category = "Articles" }
    };
}
