using System;
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

            Al.RegisterTraceHandler(HandleTrace);

            Al.UninstallSystem();
            Console.WriteLine("Done.");
        }

        private static void HandleTrace(string message)
        {
        }
    }
}
