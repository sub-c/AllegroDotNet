using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  private static class Linux
  {
    private const int RTLD_LAZY = 0x0001;
    
    [DllImport("libdl.so.2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlopen")]
    public static extern IntPtr dlopen(string path, int flags);

    [DllImport("libdl.so.2", CallingConvention = CallingConvention.Cdecl, EntryPoint = "dlsym")]
    public static extern IntPtr dlsym(IntPtr handle, string symbol);
    
    private static readonly Dictionary<string, IntPtr> NativeLibraries = new Dictionary<string, IntPtr>
    {
      { "liballegro.so", IntPtr.Zero },
      { "liballegro_image.so", IntPtr.Zero },
      { "liballegro_monolith.so", IntPtr.Zero },
    };

    public static T LoadFunction<T>()
    {
      
      var isLibraryLoaded = NativeLibraries.Any(x => x.Value != IntPtr.Zero);
      if (!isLibraryLoaded)
        foreach (var nativeLibrary in NativeLibraries)
          NativeLibraries[nativeLibrary.Key] = dlopen(nativeLibrary.Key, RTLD_LAZY);
      
      var nativeFunction = IntPtr.Zero;
      foreach (var nativeLibrary in NativeLibraries)
      {
        nativeFunction = dlsym(nativeLibrary.Value, typeof(T).Name);
        if (nativeFunction != IntPtr.Zero)
          break;
      }

      return nativeFunction == IntPtr.Zero
        ? throw new Exception($"Cannot find Allegro library when loading {typeof(T).Name}")
        : Marshal.GetDelegateForFunctionPointer<T>(nativeFunction);
    }
  }
}