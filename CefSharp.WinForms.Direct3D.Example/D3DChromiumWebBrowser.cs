using System;
using CefSharp.OffScreen;
using System.IO;

namespace CefSharp.WinForms.Direct3D.Example
{
    public partial class DXForm
    {
        class D3DChromiumWebBrowser : ChromiumWebBrowser
        {
            public D3DChromiumWebBrowser(string url, bool externalFrameTrigger) : base(url, null,
                new RequestContext(new RequestContextSettings() { CachePath = Path.GetFullPath("cache") }), false)
            {
                WindowInfo windowInfo = new WindowInfo();
                windowInfo.SetAsWindowless(IntPtr.Zero);
                windowInfo.WindowlessRenderingEnabled = true;
                windowInfo.ExternalBeginFrameEnabled = externalFrameTrigger;
                windowInfo.SharedTextureEnabled = true;

                CreateBrowser(windowInfo, new BrowserSettings()
                {
                    WindowlessFrameRate = 60
                });
            }
        }
    }
}
