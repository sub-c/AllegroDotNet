using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Native;
using SubC.AllegroDotNet.Native.Structs;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  /// <summary>
  /// Retrieves a fullscreen mode. Display parameters should not be changed between a call of
  /// <see cref="GetNumDisplayModes"/> and <see cref="GetDisplayMode"/>. index must be between 0 and the number
  /// returned from <see cref="GetNumDisplayModes"/>-1. mode must be an allocated <see cref="AllegroDisplayMode"/>
  /// structure. This function will return <c>null</c> on failure, and the mode parameter that was passed in on success.
  /// </summary>
  /// <param name="index">The index number between 0 and <see cref="GetNumDisplayModes"/> - 1.</param>
  /// <param name="mode">The display mode.</param>
  /// <returns></returns>
  public static AllegroDisplayMode GetDisplayMode(int index, ref AllegroDisplayMode mode)
  {
    var pointer = Interop.Context.Core.AlGetDisplayMode(index, ref mode);
    return Marshal.PtrToStructure<AllegroDisplayMode>(pointer);
  }

  /// <summary>
  /// Get the number of available fullscreen display modes for the current set of display parameters. This will use
  /// the values set with <see cref="SetNewDisplayRefreshRate"/>, and <see cref="SetNewDisplayFlags"/> to find the
  /// number of modes that match. Settings the new display parameters to zero will give a list of all modes for
  /// the default driver.
  /// </summary>
  /// <returns>The number of available fullscreen display modes for the current set of display parameters.</returns>
  public static int GetNumDisplayModes()
  {
    return Interop.Context.Core.AlGetNumDisplayModes();
  }
}