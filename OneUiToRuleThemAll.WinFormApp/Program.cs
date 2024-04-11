using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using OneUiToRuleThemAll.Abstractions;
using OneUiToRuleThemAll.Services;
using System.Collections.Immutable;

namespace OneUiToRuleThemAll.WinFormApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IRingLocatorService, RingLocatorService>();
            services.AddSingleton<ICatalogService, CatalogService>();

            services.AddSingleton<ApplicationWindow>();
            services.AddWindowsFormsBlazorWebView();
            services.AddBlazorWebViewDeveloperTools();

            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<ApplicationWindow>());
        }
    }
}