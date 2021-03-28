using System;
using System.Threading;
using AllegroDotNet.Models.Enums;

namespace AllegroDotNet.Sandbox
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting.");
            Console.WriteLine("Al.Init(): " + Al.Init());

            Console.WriteLine("ExeNamePath #: " + (int)StandardPath.ExeNamePath);
            var exeNamePath = Al.GetStandardPath(StandardPath.ExeNamePath);
            Al.SetOrgName("fart");
            Console.WriteLine("AppName: " + Al.GetAppName());
            Console.WriteLine("OrgName: " + Al.GetOrgName());

            Console.WriteLine("SystemID: " + Al.GetSystemID());
            Console.WriteLine("CPUs: " + Al.GetCpuCount());
            Console.WriteLine("RAM: " + Al.GetRamSize());

            Console.WriteLine("GetNewDisplayOption: " + Al.GetNewDisplayOption(DisplayOption.OpenGLMajorVersion, out var importance));
            Al.SetNewDisplayFlags(DisplayFlags.Windowed | DisplayFlags.Resizable);
            Console.WriteLine("GetNewDisplayFlags: " + Al.GetNewDisplayFlags());

            var display = Al.CreateDisplay(1920, 1080);

            var clipboardText = Al.GetClipboardText(display);

            Thread.Sleep(1000);
            Al.DestroyDisplay(display);

            Al.UninstallSystem();
            Console.WriteLine("Done.");
            Thread.Sleep(2000);
        }
    }
}
