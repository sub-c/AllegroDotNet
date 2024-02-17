using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static WindowsContext Windows => _windowsContext ??= new();

  private static WindowsContext? _windowsContext;

  public sealed class WindowsContext
  {
    #region Platform Specific Routines - Windows

    public al_get_win_window_handle AlGetWinWindowHandle { get; }
    public al_win_add_window_callback AlWinAddWindowCallback { get; }
    public al_win_remove_window_callback AlWinRemoveWindowCallback { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_win_window_handle(IntPtr display);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_win_add_window_callback(IntPtr display, Delegates.WindowsCallbackDelegate callback, IntPtr userdata);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_win_remove_window_callback(IntPtr display, Delegates.WindowsCallbackDelegate callback, IntPtr userdata);

    #endregion

    public WindowsContext()
    {
      AlGetWinWindowHandle = LoadFunction<al_get_win_window_handle>();
      AlWinAddWindowCallback = LoadFunction<al_win_add_window_callback>();
      AlWinRemoveWindowCallback = LoadFunction<al_win_remove_window_callback>();
    }
  }
}
