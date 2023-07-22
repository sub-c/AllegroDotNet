using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  private static class Windows
  {
    [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryW", SetLastError = true)]
    private static extern IntPtr LoadLibraryW(string lpszLib);

    private static readonly Dictionary<string, IntPtr> NativeLibraries = new Dictionary<string, IntPtr>
    {
      { "allegro-5.2.dll", IntPtr.Zero },
      { "allegro_acodec-5.2.dll", IntPtr.Zero },
      { "allegro_audio-5.2.dll", IntPtr.Zero },
      { "allegro_color-5.2.dll", IntPtr.Zero },
      { "allegro_dialog-5.2.dll", IntPtr.Zero },
      { "allegro_font-5.2.dll", IntPtr.Zero },
      { "allegro_image-5.2.dll", IntPtr.Zero },
      { "allegro_memfile-5.2.dll", IntPtr.Zero },
      { "allegro_monolith-5.2.dll", IntPtr.Zero },
      { "allegro_physfs-5.2.dll", IntPtr.Zero },
      { "allegro_primitives-5.2.dll", IntPtr.Zero },
      { "allegro_ttf-5.2.dll", IntPtr.Zero },
      { "allegro_video-5.2.dll", IntPtr.Zero },
    };

    public static T LoadFunction<T>()
    {
      var isLibraryLoaded = NativeLibraries.Any(x => x.Value != IntPtr.Zero);
      if (!isLibraryLoaded)
        foreach (var nativeLibrary in NativeLibraries)
          NativeLibraries[nativeLibrary.Key] = LoadLibraryW(nativeLibrary.Key);

      var nativeFunction = IntPtr.Zero;
      foreach (var nativeLibrary in NativeLibraries)
      {
        nativeFunction = GetProcAddress(nativeLibrary.Value, typeof(T).Name);
        if (nativeFunction != IntPtr.Zero)
          break;
      }

      return nativeFunction == IntPtr.Zero
        ? throw new Exception($"Cannot find Allegro library when loading {typeof(T).Name}")
        : Marshal.GetDelegateForFunctionPointer<T>(nativeFunction);
    }
  }
}