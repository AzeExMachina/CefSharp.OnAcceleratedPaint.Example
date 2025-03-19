using System;
using System.IO;
using System.Windows.Forms;
using CefSharp.OffScreen;

namespace CefSharp.WinForms.Direct3D.Example
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Monitor parent process exit and close subprocesses if parent process exits first
            CefSharpSettings.SubprocessExitIfParentProcessClosed = true;

            var settings = new CefSettings();
            settings.EnableAudio();
            settings.CachePath = Path.GetFullPath("cache");

            var success = Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            if (!success)
            {
                var exitCode = Cef.GetExitCode();

                throw new Exception($"Cef.Initialize failed with {exitCode}, check the log file for more details.");
            }

            Application.Run(new DXForm());
        }
    }
}
