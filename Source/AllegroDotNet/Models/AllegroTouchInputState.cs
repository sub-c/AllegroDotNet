using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroTouchInputState
{
  public AllegroTouchState[] Touches
  {
    readonly get => touches;
    set => touches = value;
  }

  private const int MaxTouchStates = 16;

  [MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxTouchStates)]
  private AllegroTouchState[] touches;

  public AllegroTouchInputState()
  {
    touches = new AllegroTouchState[MaxTouchStates];
  }
}
