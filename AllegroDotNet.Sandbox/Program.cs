using System;
using System.Threading;
using AllegroDotNet.Models;

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

            Al.UninstallSystem();
            Console.WriteLine("Done.");
            Thread.Sleep(2000);
        }
    }
}
