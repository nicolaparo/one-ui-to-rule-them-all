using Microsoft.Extensions.Logging;
using OneUiToRuleThemAll.Abstractions;
using OneUiToRuleThemAll.Services;

namespace OneUiToRuleThemAll.MauiHybridApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IRingLocatorService, RingLocatorService>();
            builder.Services.AddSingleton<ICatalogService, CatalogService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
