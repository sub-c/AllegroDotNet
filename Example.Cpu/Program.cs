using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Dependencies;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace AllegroDotNet.Example.Cpu
{
    internal static class Program
    {
        private const double Interval = 0.1;

        public static void Main(string[] args)
        {
            AllegroDisplay display = null;
            AllegroTimer timer = null;
            AllegroEventQueue queue = null;
            AllegroFont font = null;
            bool done = false;
            bool redraw = true;

            AlDependencyManager.ExtractAllegroDotNetDlls();
            if (!Al.Init())
            {
                ExamplesCommon.AbortExample("Failed to init Allegro.");
            }

            Al.InitFontAddon();
            ExamplesCommon.InitPlatformSpecific();

            display = Al.CreateDisplay(640, 480);
            if (display == null)
            {
                ExamplesCommon.AbortExample("Error creating display.");
            }

            if (!Al.InstallKeyboard())
            {
                ExamplesCommon.AbortExample("Error installing keyboard.");
            }

            font = Al.CreateBuiltInFont();

            timer = Al.CreateTimer(Interval);

            queue = Al.CreateEventQueue();
            Al.RegisterEventSource(queue, Al.GetKeyboardEventSource());
            Al.RegisterEventSource(queue, Al.GetTimerEventSource(timer));
            Al.RegisterEventSource(queue, Al.GetDisplayEventSource(display));

            Al.StartTimer(timer);

            Al.SetBlender(BlendOperation.Add, BlendMode.One, BlendMode.InverseAlpha);

            AllegroEvent allegroEvent = new AllegroEvent();
            while (!done)
            {
                if (redraw && Al.IsEventQueueEmpty(queue))
                {
                    Al.ClearToColor(Al.MapRgbAF(0, 0, 0, 1.0f));
                    Al.DrawText(font, Al.MapRgbAF(1, 1, 0, 1.0f), 16, 16, DrawFontFlags.AlignLeft,
                        $"Amount of CPU cores detected: {Al.GetCpuCount()}");
                    Al.DrawText(font, Al.MapRgbAF(0, 1, 1, 1.0f), 16, 32, 0,
                        $"Size of random access memory: {Al.GetRamSize()}");
                    Al.FlipDisplay();
                    redraw = false;
                }

                Al.WaitForEvent(queue, allegroEvent);
                switch (allegroEvent.Type)
                {
                    case EventType.KeyDown:
                        if (allegroEvent.Keyboard.KeyCode == KeyCode.KeyEscape)
                        {
                            done = true;
                        }
                        break;

                    case EventType.DisplayClose:
                        done = true;
                        break;

                    case EventType.Timer:
                        redraw = true;
                        break;
                }
            }

            Al.DestroyFont(font);

            return;
        }
    }
}
