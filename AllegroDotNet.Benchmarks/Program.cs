using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Dependencies;
using SubC.AllegroDotNet.Enums;
using System;

namespace AllegroDotNet.Benchmarks
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            AlDependencyManager.ExtractAllegroDotNetDlls();
            Al.Init();
            
            var display = Al.CreateDisplay(1280, 720);
            var displayClearColor = Al.MapRgb(33, 66, 99);
            Al.ClearToColor(displayClearColor);
            Al.FlipDisplay();
            
            var bitmap = Al.CreateBitmap(512, 512);
            Al.SetTargetBitmap(bitmap);
            Al.ClearToColor(Al.MapRgb(99, 33, 66));

            var startTimestamp = Al.GetTime();
            double endTimestamp;
            var random = new Random();
            var framesDrawn = 0;

            while (true)
            {
                if (Al.GetTime() - startTimestamp > 10)
                {
                    endTimestamp = Al.GetTime();
                    break;
                }

                //Al.SetTargetBackbuffer(display);
                //Al.ClearToColor(displayClearColor);
                //Al.DrawBitmap(bitmap, 64, 64, FlipFlags.None);
                //Al.FlipDisplay();

                Al.SetTargetBackbufferDllImport(display);
                Al.AlClearToColorDllImport(displayClearColor);
                Al.DrawBitmapDllImport(bitmap, 64, 64, FlipFlags.None);
                Al.AlFlipDisplayDllImport();

                ++framesDrawn;
            }

            Console.WriteLine("Frames drawn: " + framesDrawn);
            Console.WriteLine("Ran " + (endTimestamp - startTimestamp) + " seconds.");

            /*
             * FUNC LOADED:
             * 82,940
             * 96,665
             * 97,374
             * 
             * 
             * 
             * 
             * 
             * DLL IMPORT:
             * 97,459
             * 83,872
             * 83,846
             * 
             */
        }
    }
}
