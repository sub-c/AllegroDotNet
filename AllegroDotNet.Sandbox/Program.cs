using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using AllegroDotNet.Wrapper;

namespace AllegroDotNet.Sandbox
{
    internal static class Program
    {
        [DllImport("allegro-5.2.dll")]
        public static extern bool al_install_system(int version, IntPtr atExitPtr);

        [DllImport("allegro-5.2.dll")]
        public static extern void al_uninstall_system();

        [DllImport("allegro-5.2.dll")]
        public static extern IntPtr al_create_display(int w, int h);

        [DllImport("allegro-5.2.dll")]
        public static extern void al_destroy_display(IntPtr display);

        [DllImport("allegro-5.2.dll")]
        public static extern IntPtr al_create_bitmap(int w, int h);

        [DllImport("allegro-5.2.dll")]
        public extern static void al_destroy_bitmap(IntPtr bitmap);

        [DllImport("allegro-5.2.dll")]
        public extern static void al_draw_bitmap(IntPtr bitmap, float x, float y, int flags);

        [DllImport("allegro-5.2.dll")]
        public extern static void al_flip_display();

        public static void Main(string[] args)
        {
            //84018689

            const int iterations = 50000;
            for (int iter = 0; iter < 3; ++iter)
            {
                {
                    Al.Init();
                    var dis = Al.CreateDisplay(1920, 1080);
                    var bmp = Al.CreateBitmap(512, 512);

                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < iterations; ++i)
                    {
                        Al.DrawBitmap(bmp, 128, 200, 0);
                        Al.FlipDisplay();
                    }
                    stopwatch.Stop();

                    Al.DestroyBitmap(bmp);
                    Al.DestroyDisplay(dis);
                    Al.UninstallSystem();
                    Console.WriteLine($"CPP/CLI bitmap test: {stopwatch.ElapsedMilliseconds}ms");
                }
                {
                    al_install_system(84018689, IntPtr.Zero);
                    var dis = al_create_display(1920, 1080);
                    var bmp = al_create_bitmap(512, 512);

                    var stopwatch = new Stopwatch();
                    stopwatch.Start();
                    for (int i = 0; i < iterations; ++i)
                    {
                        al_draw_bitmap(bmp, 128, 200, 0);
                        al_flip_display();
                    }
                    stopwatch.Stop();

                    al_destroy_bitmap(bmp);
                    al_destroy_display(dis);
                    al_uninstall_system();
                    Console.WriteLine($"PInvoke bitmap test: {stopwatch.ElapsedMilliseconds}ms");
                }
            }

            Thread.Sleep(5000);
            return;

            //const int iterations = 1000;
            //var stopwatch = new Stopwatch();
            //for(int a = 0; a < 3; ++a)
            //{
            //    stopwatch.Reset();
            //    stopwatch.Start();
            //    for (int i = 0; i < iterations; ++i)
            //    {
            //        al_install_system(84018689, IntPtr.Zero);
            //        al_uninstall_system();
            //    }
            //    stopwatch.Stop();
            //    Console.WriteLine($"{a}-PINVOKE: " + stopwatch.ElapsedMilliseconds + "ms");

            //    stopwatch.Reset();
            //    stopwatch.Start();
            //    for (int i = 0; i < iterations; ++i)
            //    {
            //        Al.Init();
            //        Al.UninstallSystem();
            //    }
            //    stopwatch.Stop();
            //    Console.WriteLine($"{a}-CPP/CLI: " + stopwatch.ElapsedMilliseconds + "ms");
            //}
            //Thread.Sleep(5000);

            Console.WriteLine("Init: " + Al.Init());
            Console.WriteLine("Version: " + Al.GetAllegroVersion());
            Console.WriteLine("AppName: " + Al.GetAppName());
            Console.WriteLine("OrgName: " + Al.GetOrgName());
            Console.WriteLine("CpuCount: " + Al.GetCpuCount());
            Console.WriteLine("RamSize: " + Al.GetRamSize());

            Al.RegisterAssertHandler(HandleAssert);
            Al.RegisterTraceHandler(HandleTrace);

            Console.WriteLine("Install Joystick: " + Al.InstallJoystick());
            Console.WriteLine("Joysticks: " + Al.GetNumJoysticks());

            var allegroEvent = new AllegroEvent();
            var allegroEventQueue = Al.CreateEventQueue();
            Al.DestroyEventQueue(allegroEventQueue);

            var display = Al.CreateDisplay(1280, 720);

            AllegroColor color = Al.MapRgb(200, 50, 100);
            Al.ClearToColor(color);
            Al.FlipDisplay();
            Al.Rest(3);

            Al.DestroyDisplay(display);

            var config = Al.CreateConfig();
            Al.SetConfigValue(config, "MainSection", "MainKey", "55");
            var configSection = Al.GetFirstConfigEntry(config, "MainSection", out var iterator);

            Al.UninstallJoystick();
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
