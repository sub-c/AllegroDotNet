using System;
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
