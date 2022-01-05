using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

class Wraper : System.Windows.Forms.Form
{
    Wraper()
    {
        // Initial form configuration
        Width = 800;
        Height = 600;
        Text = "Loading...";
        StartPosition = FormStartPosition.CenterScreen;
        InitWebView();
    }
    
    async void InitWebView() {
        var webView = new WebView2() {Dock = DockStyle.Fill};
        var env = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Application.StartupPath, "userdata"), null);
        await webView.EnsureCoreWebView2Async(env);
        webView.CoreWebView2.SetVirtualHostNameToFolderMapping("0.0.0.0", Application.StartupPath + "wwwroot", CoreWebView2HostResourceAccessKind.Allow);
        webView.CoreWebView2.DocumentTitleChanged += (sender, e) => Text = webView.CoreWebView2.DocumentTitle;
        webView.CoreWebView2.WindowCloseRequested += (sender, e) => Application.Exit();
#if DEBUG
        // Change this to your web server
        webView.Source = new Uri("https://0.0.0.0/index.html");
#else
        webView.Source = new Uri("https://0.0.0.0/index.html");
        webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
        webView.CoreWebView2.Settings.IsStatusBarEnabled = false;
#endif
        Controls.Add(webView);
    }


    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Wraper());
    }
}
