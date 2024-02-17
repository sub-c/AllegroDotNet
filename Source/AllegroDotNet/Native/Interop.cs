using System.Reflection;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static IInteropProvider? InteropProvider { get; set; }

  private static readonly ICollection<IntPtr> _loadedNativeLibraries = new List<IntPtr>();

  public static T LoadFunction<T>()
  {
    if (InteropProvider is null)
    {
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        InteropProvider = new LinuxInteropProvider();
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        InteropProvider = new OSXInteropProvider();
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        InteropProvider = new WindowsInteropProvider();
      else
        throw new PlatformNotSupportedException("The operating system is not supported by AllegroDotNet.");
    }

    if (_loadedNativeLibraries.Count == 0)
    {
      foreach (var nativeLibraryFilename in InteropProvider.NativeLibraryFilenames)
      {
        var nativeLibrary = InteropProvider.LoadLibrary(nativeLibraryFilename);
        if (nativeLibrary != IntPtr.Zero)
          _loadedNativeLibraries.Add(nativeLibrary);
      }
    }

    var nativeFunction = IntPtr.Zero;

    foreach (var nativeLibrary in _loadedNativeLibraries)
    {
      nativeFunction = InteropProvider.LoadFunction(nativeLibrary, typeof(T).Name);
      if (nativeFunction != IntPtr.Zero)
        break;
    }

    return nativeFunction == IntPtr.Zero
      ? throw new EntryPointNotFoundException($"Cannot load Allegro function '{typeof(T).Name}' from {_loadedNativeLibraries.Count} loaded libraries.")
      : Marshal.GetDelegateForFunctionPointer<T>(nativeFunction);
  }

  private sealed class LinuxInteropProvider : IInteropProvider
  {
    private const int RTLD_LAZY = 0x0001;

    public IReadOnlyCollection<string> NativeLibraryFilenames { get; } = new List<string>
    {
      "liballegro.so",
      "liballegro_acodec.so",
      "liballegro_audio.so",
      "liballegro_color.so",
      "liballegro_dialog.so",
      "liballegro_font.so",
      "liballegro_image.so",
      "liballegro_memfile.so",
      "liballegro_monolith.so",
      "liballegro_physfs.so",
      "liballegro_primitives.so",
      "liballegro_ttf.so",
      "liballegro_video.so"
    };

    public IntPtr LoadFunction(IntPtr nativeLibrary, string functionName)
    {
      return dlsym(nativeLibrary, functionName);
    }

    public IntPtr LoadLibrary(string filename)
    {
      return dlopen(filename, RTLD_LAZY);
    }

    [DllImport("libdl.so.2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlopen")]
    private static extern IntPtr dlopen(string path, int flags);

    [DllImport("libdl.so.2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlsym")]
    private static extern IntPtr dlsym(IntPtr handle, string symbol);
  }

  private sealed class OSXInteropProvider : IInteropProvider
  {
    public IReadOnlyCollection<string> NativeLibraryFilenames { get; } = new List<string>
    {
      "liballegro.so",
      "liballegro_acodec.so",
      "liballegro_audio.so",
      "liballegro_color.so",
      "liballegro_dialog.so",
      "liballegro_font.so",
      "liballegro_image.so",
      "liballegro_memfile.so",
      "liballegro_monolith.so",
      "liballegro_physfs.so",
      "liballegro_primitives.so",
      "liballegro_ttf.so",
      "liballegro_video.so"
    };

    private const int RTLD_LAZY = 0x0001;

    [DllImport("/usr/lib/libSystem.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlopen")]
    private static extern IntPtr dlopen(string path, int flags);

    [DllImport("/usr/lib/libSystem.dylib", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlsym")]
    private static extern IntPtr dlsym(IntPtr handle, string symbol);

    public IntPtr LoadFunction(IntPtr nativeLibrary, string functionName)
    {
      return dlsym(nativeLibrary, functionName);
    }

    public IntPtr LoadLibrary(string filename)
    {
      var pointer = dlopen(filename, RTLD_LAZY);

      if (pointer == IntPtr.Zero)
        pointer = dlopen(Path.Combine(Assembly.GetExecutingAssembly().Location, "..", "Frameworks", filename), RTLD_LAZY);

      return pointer;
    }
  }

  private sealed class WindowsInteropProvider : IInteropProvider
  {
    public IReadOnlyCollection<string> NativeLibraryFilenames { get; } = new List<string>
    {
      "allegro-5.2.dll",
      "allegro_acodec-5.2.dll",
      "allegro_audio-5.2.dll",
      "allegro_color-5.2.dll",
      "allegro_dialog-5.2.dll",
      "allegro_font-5.2.dll",
      "allegro_image-5.2.dll",
      "allegro_memfile-5.2.dll",
      "allegro_monolith-5.2.dll",
      "allegro_physfs-5.2.dll",
      "allegro_primitives-5.2.dll",
      "allegro_ttf-5.2.dll",
      "allegro_video-5.2.dll"
    };

    public IntPtr LoadFunction(IntPtr nativeLibrary, string functionName)
    {
      return GetProcAddress(nativeLibrary, functionName);
    }

    public IntPtr LoadLibrary(string filename)
    {
      return LoadLibraryW(filename);
    }

    [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryW", SetLastError = true)]
    private static extern IntPtr LoadLibraryW(string lpszLib);
  }
}
