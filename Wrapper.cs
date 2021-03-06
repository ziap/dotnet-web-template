using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

class Wraper : System.Windows.Forms.Form
{
    Wraper()
    {
        // Initial form configuration
        Width = 800;
        Height = 600;
        Text = Application.ProductName;
        StartPosition = FormStartPosition.CenterScreen;
        InitWebView();
    }

    async void InitWebView() {
        // Create the WebView
        var webView = new WebView2() {Dock = DockStyle.Fill};
        var env = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Path.GetTempPath(), Application.ProductName), null);
        await webView.EnsureCoreWebView2Async(env);
        webView.CoreWebView2.SetVirtualHostNameToFolderMapping("0.0.0.0", Path.Combine(Application.StartupPath, "wwwroot"), CoreWebView2HostResourceAccessKind.Allow);

        // Listen to some events
        webView.NavigationCompleted += (sender, e) => webView.Focus();
        webView.CoreWebView2.DocumentTitleChanged += (sender, e) => Text = webView.CoreWebView2.DocumentTitle;

        // Use window.close() in JavaScript to close the application
        webView.CoreWebView2.WindowCloseRequested += (sender, e) => Application.Exit();
#if DEBUG
        // Change this to your dev server
        webView.Source = new Uri("https://0.0.0.0/index.html");
#else
        webView.Source = new Uri("https://0.0.0.0/index.html");

        // Production settings
        webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
        webView.CoreWebView2.Settings.IsStatusBarEnabled = false;
#endif
        Controls.Add(webView);
    }

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Wraper());
    }
}
