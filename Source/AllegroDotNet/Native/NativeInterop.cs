using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native
{
  internal static class NativeInterop
  {
    private const string LinuxLibraryFilename = "./liballegro_monolith.so";
    private const string OSXLibraryFilename = "liballegro_monolith.so";
    private const int RTLD_LAZY = 0x0001;
    private const string WindowsLibraryFilename = "allegro_monolith-5.2.dll";

    public static IntPtr LoadAllegroLibrary()
    {
      IntPtr library;
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        library = Windows.LoadLibraryW(WindowsLibraryFilename);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      {
        library = Linux.dlopen(LinuxLibraryFilename, RTLD_LAZY);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
      {
        library = OSX.dlopen(OSXLibraryFilename, RTLD_LAZY);
        if (library == IntPtr.Zero)
        {
          // Look in Frameworks for .app bundles
          library = OSX.dlopen(Path.Combine(Assembly.GetExecutingAssembly().Location, "..", "Frameworks", OSXLibraryFilename), RTLD_LAZY);
        }
      }
      else
      {
        throw new NotSupportedException("This OS is not supported by AllegroDotNet.");
      }
      return library == IntPtr.Zero
          ? throw new BadImageFormatException("Could not load Allegro library file.")
          : library;
    }

    public static T LoadFunction<T>(IntPtr library)
    {
      return LoadFunction<T>(library, typeof(T).Name);
    }

    public static T LoadFunction<T>(IntPtr library, string functionName)
    {
      IntPtr function;
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        function = Windows.GetProcAddress(library, functionName);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      {
        function = Linux.dlsym(library, functionName);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
      {
        function = OSX.dlsym(library, functionName);
      }
      else
      {
        throw new NotSupportedException("This OS is not supported by AllegroDotNet.");
      }
      return function == IntPtr.Zero
          ? throw new BadImageFormatException($"Could not load the function \"{functionName}\" from the library.")
          : Marshal.GetDelegateForFunctionPointer<T>(function);
    }

    private static class Linux
    {
      [DllImport("libdl.so.2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlopen")]
      public static extern IntPtr dlopen(string path, int flags);

      [DllImport("libdl.so.2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlsym")]
      public static extern IntPtr dlsym(IntPtr handle, string symbol);
    }

    private static class OSX
    {
      [DllImport("/usr/lib/libSystem.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlopen")]
      public static extern IntPtr dlopen(string path, int flags);

      [DllImport("/usr/lib/libSystem.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlsym")]
      public static extern IntPtr dlsym(IntPtr handle, string symbol);
    }

    private static class Windows
    {
      [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true)]
      public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

      [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryW", SetLastError = true)]
      public static extern IntPtr LoadLibraryW(string lpszLib);
    }
  }
}