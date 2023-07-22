using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Structs;

/// <summary>
/// An opaque struct representing the state of a keyboard keys.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroKeyboardState
{
  /// <summary>
  /// The native pointer to the display with the keyboad state.
  /// </summary>
  public IntPtr display;
  
  internal readonly uint key_down_internal1;
  internal readonly uint key_down_internal2;
  internal readonly uint key_down_internal3;
  internal readonly uint key_down_internal4;
  internal readonly uint key_down_internal5;
  internal readonly uint key_down_internal6;
  internal readonly uint key_down_internal7;
  internal readonly uint key_down_internal8;
}
