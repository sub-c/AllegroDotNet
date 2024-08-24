using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static IntPtr GetWinWindowHandle(AllegroDisplay? display)
    {
        return Interop.Windows.AlGetWinWindowHandle(NativePointer.Get(display));
    }

    public static bool WinAddWindowCallback(AllegroDisplay? display, Delegates.WindowsCallbackDelegate callback, IntPtr userdata)
    {
        return Interop.Windows.AlWinAddWindowCallback(NativePointer.Get(display), callback, userdata) != 0;
    }

    public static bool WinRemoveWindowCallback(AllegroDisplay? display, Delegates.WindowsCallbackDelegate callback, IntPtr userdata)
    {
        return Interop.Windows.AlWinRemoveWindowCallback(NativePointer.Get(display), callback, userdata) != 0;
    }

    public static IntPtr OsxGetWindow(AllegroDisplay? display)
    {
        return Interop.Mac.AlOsxGetWindow(NativePointer.Get(display));
    }

    public static int GetXWindowID(AllegroDisplay? display)
    {
        return Interop.Linux.AlGetXWindowId(NativePointer.Get(display));
    }
}
