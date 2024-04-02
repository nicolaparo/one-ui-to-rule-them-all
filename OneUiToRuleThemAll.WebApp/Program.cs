using OneUiToRuleThemAll.Abstractions;
using OneUiToRuleThemAll.Services;
using OneUiToRuleThemAll.WebApp.Components;
using OneUiToRuleThemAll.WebApp.Components.Pages;

namespace OneUiToRuleThemAll.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddSingleton<IRingLocatorService, RingLocatorService>();
            builder.Services.AddSingleton<ICatalogService, CatalogService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
