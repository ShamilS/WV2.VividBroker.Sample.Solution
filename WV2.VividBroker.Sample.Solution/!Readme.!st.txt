Run the following commands in teh Package Manager to properly set
Microsoft WebView2 packages for .NET Framework 4.8.1 projects:

Get-Project WV2.VividBroker | Uninstall-Package Microsoft.Web.WebView2
Get-Project WV2.VividBroker.NetFramework.WinFormsApp | Uninstall-Package Microsoft.Web.WebView2
Get-Project WV2.VividBroker | Install-Package Microsoft.Web.WebView2
Get-Project WV2.VividBroker.NetFramework.WinFormsApp | Install-Package Microsoft.Web.WebView2
	