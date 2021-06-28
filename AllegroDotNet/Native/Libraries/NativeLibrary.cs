using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Libraries
{
    internal static class NativeLibrary
    {
        public static IntPtr LoadAllegroLibrary()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Windows.LoadLibraryW(AlConstants.AllegroMonolithDllFilenameWindows);
            }
            throw new NotSupportedException("Only Windows is currently supported.");
        }

        public static T LoadNativeFunction<T>(IntPtr library, string functionName)
        {
            IntPtr functionPointer;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                functionPointer = Windows.GetProcAddress(library, functionName);
            }
            else
            {
                throw new NotSupportedException("Only Windows is currently supported.");
            }

            return functionPointer == IntPtr.Zero
                ? throw new EntryPointNotFoundException($"Could not load/find the function \"{functionName}\".")
                : Marshal.GetDelegateForFunctionPointer<T>(functionPointer);
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
