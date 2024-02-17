using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static LinuxContext Linux => _linuxContext ??= new();

  private static LinuxContext? _linuxContext;

  public sealed class LinuxContext
  {
    #region Linux Routines

    public al_get_x_window_id AlGetXWindowId { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_x_window_id(IntPtr display);

    #endregion

    public LinuxContext()
    {
      AlGetXWindowId = LoadFunction<al_get_x_window_id>();
    }
  }
}
