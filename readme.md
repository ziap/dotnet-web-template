# .NET web template

Create windows app with web technology

## Requirements
 - Windows operating system with [WebView2](https://docs.microsoft.com/en-us/microsoft-edge/webview2/) support.
 - .NET 6.0 SDK or newer. You can download the latest version of the .NET SDK [here](https://dotnet.microsoft.com/en-us/download/).
 - For Visual Studio user: Visual Studio 2022 or newer.

## Usage
 - Download [Wrapper.cs](Wrapper.cs) and [[project].csproj]([project].csproj) to your project directory.
 - (Optional) Rename `[project].csproj` to your project name.
 - Copy your existing static web app into the `wwwroot` folder.
 - Open the .csproj file with Visual Studio or use the .NET CLI to build and run the program.

## Framework integration
You can use any web framework you want as long as your website is static (i.e served with HTML files instead of a web server).

Make sure to set the export path to `wwwroot`.

Example: 
 - [SvelteKit](sveltekit.md)
 - [Gatsby](gatsby.md)

# License
This project is licensed under the [MIT LICENSE](LICENSE)
