using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Web.WebView2.Core;

class Wrapper : System.Windows.Forms.Form
{
    Wrapper()
    {
        Width = 800;
        Height = 600;
        StartPosition = FormStartPosition.CenterScreen;
        var blazor = new BlazorWebView()
        {
            Dock = DockStyle.Fill,
            HostPage = Application.StartupPath + @"wwwroot\index.html",
            Services = (new ServiceCollection()).AddBlazorWebView().BuildServiceProvider()
        };
        InitializeAsync(blazor);
        Controls.Add(blazor);
    }

    async void InitializeAsync(BlazorWebView blazor)
    {
        var op = new CoreWebView2EnvironmentOptions("--disable-web-security");
        var env = await CoreWebView2Environment.CreateAsync(null, null, op);
        await blazor.WebView.EnsureCoreWebView2Async(env);
        blazor.WebView.CoreWebView2.DocumentTitleChanged += (sender, e) => Text = blazor.WebView.CoreWebView2.DocumentTitle;
    }

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Wrapper());
    }
}