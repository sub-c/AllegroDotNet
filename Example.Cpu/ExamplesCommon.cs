using System;

namespace AllegroDotNet.Example.Cpu
{
    public static class ExamplesCommon
    {
        public static void AbortExample(string format)
        {
            Console.WriteLine(format);
            Environment.Exit(1);
        }

        public static void InitPlatformSpecific()
        {
        }
    }
}
