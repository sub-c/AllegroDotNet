using System;
using System.Threading;
using AllegroDotNet.Models;
using AllegroDotNet.Enums;
using System.IO;
using AllegroDotNet.Dependencies;
using System.Diagnostics;

namespace AllegroDotNet.Sandbox
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var isAllegroDllFound = File.Exists("allegro_monolith-debug-5.2.dll");
            Console.WriteLine("Is Allegro DLL found: " + isAllegroDllFound);

            AlDependencyManager.ExtractAllegroDotNetDlls();
            //AlDependencyManager.ExtractAllegroDlls(Directory.GetCurrentDirectory());
            //AlDependencyManager.ExtractThirdPartyDlls(Directory.GetCurrentDirectory());

            Console.WriteLine("Starting.");
            //Console.WriteLine("Al.Init(): " + Al.Init());
            Console.WriteLine("Al.InstallSystem(): " + Al.InstallSystem(AlConstants.AllegroVersionInt));
            Console.WriteLine("Last Error: " + Al.GetErrNo());
            Console.WriteLine("Al.InitImageAddon(): " + Al.InitImageAddon());
            Console.WriteLine("Al.InstallAudio(): " + Al.InstallAudio());
            Console.WriteLine("Al.InitACodecAddon(): " + Al.InitACodecAddon());
            Console.WriteLine("Al.InitFontAddon(): " + Al.InitFontAddon());
            Console.WriteLine("Al.al_init_native_dialog_addon(): " + Al.InitNativeDialogAddon());

            //var messageBoxReturn = Al.ShowNativeMessageBox(null, "myTitle", "myHeading", "myText", "Button!", MessageBoxFlags.Question | MessageBoxFlags.YesNo);
            var textLog = Al.OpenNativeTextLog("AllegroDotNet Test Text Log", TextLogFlags.Monospace | TextLogFlags.NoClose);
            Al.AppendNativeTextLog(textLog, "ALLEGRODOTNET - Some message here.");

            Console.WriteLine("Al.ReserveSamples(8): " + Al.ReserveSamples(8));
            //var sample = Al.LoadSample(@"E:\Videos\Assets\Golden Mission OP-98.ogg");
            //if (sample != null )
            //{ 
            //    Console.WriteLine("Loaded Sample!");
            //    //Al.PlaySample(sample, 1, 0, 1, PlayMode.Once, null);
            //}

            Console.WriteLine("ExeNamePath #: " + (int)StandardPath.ExeNamePath);
            //var exeNamePath = Al.GetStandardPath(StandardPath.ExeNamePath);
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
            var timer = Al.CreateTimer(AlMacros.BpsToSecs(60));
            Al.RegisterEventSource(eventQueue, Al.GetTimerEventSource(timer));
            Al.RegisterEventSource(eventQueue, Al.GetDisplayEventSource(display));
            Al.StartTimer(timer);
            AllegroEvent allegroEvent = new AllegroEvent();
            var aColor = Al.MapRgb(255, 64, 128);
            var bitmap = Al.CreateBitmap(300, 300);
            Al.SetTargetBitmap(bitmap);
            Al.ClearToColor(aColor);
            Al.SetTargetBackbuffer(display);

            Al.InstallKeyboard();
            var keyboardState = new AllegroKeyboardState();

            Al.InstallMouse();
            var mouseState = new AllegroMouseState();

            Al.InstallJoystick();
            Console.WriteLine("Joysticks: " + Al.GetNumJoysticks());

            Console.WriteLine("Shader Source:\n" + Al.GetDefaultShaderSource(ShaderPlatform.Auto, ShaderType.PixelShader));

            Console.WriteLine("Video adapters: " + Al.GetNumVideoAdapters());

            var fontColor = Al.MapRgb(255, 255, 255);
            var clearColor = Al.MapRgb(32, 32, 32);

            Al.SetNewBitmapFlags(BitmapFlags.NoPreserveTexture);
            var frameBuffer = Al.CreateBitmap(1920, 1080);

            var builtinFont = Al.CreateBuiltInFont();
            if (builtinFont != null)
            {
                Console.WriteLine("Loaded builtin font!");
            }
            else
            {
                Console.WriteLine("COULDN'T LOAD BUILTIN FONT!");
                return;
            }

            while (true)
            {
                Al.WaitForEvent(eventQueue, ref allegroEvent);
                if (allegroEvent.Type == EventType.DisplayClose)
                {
                    break;
                }
                else if (allegroEvent.Type == EventType.Timer)
                {
                    Al.GetMouseState(mouseState);

                    Al.SetTargetBitmap(frameBuffer);

                    Al.ClearToColor(clearColor);
                    Al.DrawBitmap(bitmap, mouseState.X, mouseState.Y, FlipFlags.None);
                    Al.DrawText(builtinFont, fontColor, 0, 0, DrawFontFlags.AlignLeft, "This is some text to make sure drawing text is working.");

                    Al.SetTargetBackbuffer(display);
                    Al.DrawBitmap(frameBuffer, 0, 0, FlipFlags.None);
                    Al.FlipDisplay();

                    Al.GetKeyboardState(keyboardState);
                    if (Al.KeyDown(keyboardState, KeyCode.KeyD))
                    {
                        break;
                    }
                }
            }

            Al.DestroyBitmap(frameBuffer);

            if (builtinFont != null)
            {
                Al.DestroyFont(builtinFont);
            }

            //if (sample != null)
            //{
            //    Al.DestroySample(sample);
            //}

            Al.CloseNativeTextLog(textLog);

            Al.DestroyBitmap(bitmap);
            Al.DestroyTimer(timer);
            Al.DestroyEventQueue(eventQueue);
            Al.DestroyDisplay(display);

            Al.ShutdownNativeDialogAddon();
            Al.ShutdownFontAddon();
            Al.UninstallJoystick();
            Al.UninstallMouse();
            Al.UninstallKeyboard();
            Al.UninstallSystem();

            Console.WriteLine("Done.");
            Thread.Sleep(1000);
        }
    }
}
