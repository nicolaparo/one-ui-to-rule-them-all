using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using OneUiToRuleThemAll.WinFormApp.Components;
using System.Collections.Immutable;
using System.ComponentModel;

namespace OneUiToRuleThemAll.WinFormApp
{
    [DesignerCategory("")]
    public class ApplicationWindow : Form
    {
        public ApplicationWindow(IServiceProvider serviceProvider)
        {
            var blazor = new BlazorWebView();

            blazor.Services = serviceProvider;
            blazor.HostPage = @"wwwroot/index.html";
            blazor.RootComponents.Add(new RootComponent(@"#app", typeof(App), ImmutableDictionary<string, object?>.Empty));

            blazor.BlazorWebViewInitialized = (s, e) =>
            {
                e.WebView.ZoomFactor = 1;
                e.WebView.CoreWebView2.Settings.IsZoomControlEnabled = false;
                e.WebView.CoreWebView2.Settings.IsPinchZoomEnabled = false;
            };

            blazor.Dock = DockStyle.Fill;
            Controls.Add(blazor);
            Size = new Size(1600, 1200);

            FormClosing += (s, e) =>
            {
                var result = MessageBox.Show("Did you inform Sauron you are closing this application? There might be severe consequences...", "Confirm", MessageBoxButtons.YesNo);

                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    MessageBox.Show("You better ask for his permission...");
                }
                    
            };
        }
    }
}
