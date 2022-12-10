using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroTouchInputState
  {
    public AllegroTouchState this[int index]
    {
      get
      {
        _allegroTouchStates[index].NativeTouchState = TouchInputState.touches[index];
        return _allegroTouchStates[index];
      }
    }

    internal NativeAllegroTouchInputState TouchInputState = new();

    private readonly AllegroTouchState[] _allegroTouchStates = new AllegroTouchState[16];

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroTouchInputState
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
      public AllegroTouchState.NativeAllegroTouchState[] touches;
    }
  }
}
