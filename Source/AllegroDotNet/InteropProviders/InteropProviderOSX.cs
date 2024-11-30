using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.InteropProviders;

internal sealed class InteropProviderOSX : IInteropProvider
{
    private const int RTLD_LAZY = 0x0001;

    [DllImport(
        "/usr/lib/libSystem.dylib",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "dlopen",
        CharSet = CharSet.Ansi)]
    private static extern IntPtr dlopen(string path, int flags);

    [DllImport(
        "/usr/lib/libSystem.dylib",
        CallingConvention = CallingConvention.Cdecl,
        EntryPoint = "dlsym",
        CharSet = CharSet.Ansi)]
    private static extern IntPtr dlsym(IntPtr handle, string symbol);


    private readonly IntPtr[] _loadedNativeLibraries;
    private readonly string[] _nativeLibraryFilenames =
    [
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
    ];

    public InteropProviderOSX()
    {
        _loadedNativeLibraries = _nativeLibraryFilenames
            .Select(x => dlopen(x, RTLD_LAZY))
            .Where(x => x != IntPtr.Zero)
            .ToArray();
    }

    public T GetFunctionPointer<T>() where T : Delegate
    {
        var functionName = typeof(T).Name;

        var functionPointer = _loadedNativeLibraries
            .Select(x => dlsym(x, functionName))
            .FirstOrDefault(x => x != IntPtr.Zero);

        return functionPointer == IntPtr.Zero
            ? throw new EntryPointNotFoundException($"Unable to load '{functionName}' function from {_loadedNativeLibraries.Length} loaded Allegro libraries.")
            : Marshal.GetDelegateForFunctionPointer<T>(functionPointer);

    }
}
