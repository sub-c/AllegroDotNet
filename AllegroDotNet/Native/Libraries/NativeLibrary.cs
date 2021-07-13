using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Libraries
{
    internal static class NativeLibrary
    {
        public static IntPtr LoadAllegroLibrary()
        {
            IntPtr nativeLibrary;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                nativeLibrary = Windows.LoadLibraryW(AlConstants.AllegroMonolithDllFilenameWindows);
            }
            else
            {
                throw new NotSupportedException("Only Windows is currently supported.");
            }
            return nativeLibrary == IntPtr.Zero
                ? throw new BadImageFormatException("Could not load/find the Allegro library.")
                : nativeLibrary;
        }

        public static T LoadNativeFunction<T>(IntPtr library, string functionName)
        {
            IntPtr nativeFunction;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                nativeFunction = Windows.GetProcAddress(library, functionName);
            }
            else
            {
                throw new NotSupportedException("Only Windows is currently supported.");
            }

            return nativeFunction == IntPtr.Zero
                ? throw new EntryPointNotFoundException($"Could not load/find the function \"{functionName}\".")
                : Marshal.GetDelegateForFunctionPointer<T>(nativeFunction);
        }

        private static class Windows
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern IntPtr LoadLibraryW(string lpszLib);
        }
    }
}
