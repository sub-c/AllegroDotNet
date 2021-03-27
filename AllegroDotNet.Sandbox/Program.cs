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

            var display = Al.CreateDisplay(1920, 1080);
            Thread.Sleep(1000);
            Al.DestroyDisplay(display);

            Al.UninstallSystem();
            Console.WriteLine("Done.");
            Thread.Sleep(2000);
        }
    }
}
