using System;
using System.Threading;
using AllegroDotNet.Models;
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

            var config = Al.CreateConfig();
            Al.SetConfigValue(config, "TestSection", "TestKey", "TestValue");
            Console.WriteLine("Get config value: " + Al.GetConfigValue(config, "TestSection", "TestKey"));
            Al.DestroyConfig(config);

            var display = Al.CreateDisplay(1920, 1080);
            var eventQueue = Al.CreateEventQueue();
            var timer = Al.CreateTimer(1);
            Al.RegisterEventSource(eventQueue, Al.GetTimerEventSource(timer));
            Al.RegisterEventSource(eventQueue, Al.GetDisplayEventSource(display));
            Al.StartTimer(timer);
            AllegroEvent allegroEvent = new AllegroEvent();
            while (true)
            {
                Al.WaitForEvent(eventQueue, ref allegroEvent);
                if (allegroEvent.Type == EventType.DisplayClose)
                {
                    break;
                }
                else if (allegroEvent.Type == EventType.Timer)
                {
                    Console.WriteLine("Timer elapsed one sec");
                }
            }

            Al.DestroyTimer(timer);
            Al.DestroyEventQueue(eventQueue);
            Al.DestroyDisplay(display);

            Al.UninstallSystem();
            Console.WriteLine("Done.");
            Thread.Sleep(2000);
        }
    }
}
