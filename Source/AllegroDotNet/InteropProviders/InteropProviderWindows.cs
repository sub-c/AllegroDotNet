using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.InteropProviders;

internal sealed class InteropProviderWindows : IInteropProvider
{
    [DllImport(
        "kernel32.dll",
        CallingConvention = CallingConvention.Cdecl,
        CharSet = CharSet.Ansi,
        EntryPoint = "GetProcAddress",
        ExactSpelling = true,
        SetLastError = true)]
    private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport(
        "kernel32.dll",
        CallingConvention = CallingConvention.Cdecl,
        CharSet = CharSet.Unicode,
        EntryPoint = "LoadLibraryW",
        SetLastError = true)]
    private static extern IntPtr LoadLibraryW(string lpszLib);


    private readonly IntPtr[] _loadedNativeLibraries;
    private readonly string[] _nativeLibraryFilenames =
    [
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
    ];

    public InteropProviderWindows()
    {
        _loadedNativeLibraries = _nativeLibraryFilenames
            .Select(LoadLibraryW)
            .Where(x => x != IntPtr.Zero)
            .ToArray();
    }

    public T GetFunctionPointer<T>()
        where T : Delegate
    {
        var functionName = typeof(T).Name;

        var functionPointer = _loadedNativeLibraries
            .Select(x => GetProcAddress(x, functionName))
            .FirstOrDefault(x => x != IntPtr.Zero);

        return functionPointer == default
            ? throw new EntryPointNotFoundException($"Unable to load '{functionName}' function from {_loadedNativeLibraries.Length} loaded Allegro libraries.")
            : Marshal.GetDelegateForFunctionPointer<T>(functionPointer);
    }
}
