using System;
using System.Collections.Generic;
using System.Threading;
using AllegroDotNet.Wrapper;

namespace AllegroDotNet.Sandbox
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Init: " + Al.Init());
            Console.WriteLine("Version: " + Al.GetAllegroVersion());
            Console.WriteLine("AppName: " + Al.GetAppName());
            Console.WriteLine("OrgName: " + Al.GetOrgName());
            Console.WriteLine("CpuCount: " + Al.GetCpuCount());
            Console.WriteLine("RamSize: " + Al.GetRamSize());

            Al.RegisterAssertHandler(HandleAssert);
            Al.RegisterTraceHandler(HandleTrace);

            var allegroEvent = new AllegroEvent();
            var allegroEventQueue = Al.CreateEventQueue();
            Al.DestroyEventQueue(allegroEventQueue);

            var display = Al.CreateDisplay(1280, 720);
            Thread.Sleep(3000);
            Al.DestroyDisplay(display);

            var config = Al.CreateConfig();
            Al.SetConfigValue(config, "MainSection", "MainKey", "55");
            var configSection = Al.GetFirstConfigEntry(config, "MainSection", out var iterator);

            Al.UninstallSystem();
            Console.WriteLine("Done.");
        }

        private static void HandleAssert(string a, string b, int line, string func)
        {
        }

        private static void HandleTrace(string message)
        {
        }
    }
}
