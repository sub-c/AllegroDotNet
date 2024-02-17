using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroJoystickState
{
  public int[] Button
  {
    readonly get => button;
    set => button = value;
  }

  public AllegroJoystickStick[] Stick
  {
    readonly get => stick;
    set => stick = value;
  }

  private const int MaxJoystickSticks = 16;
  private const int MaxJoystickButtons = 32;

  [MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxJoystickSticks)]
  private AllegroJoystickStick[] stick = new AllegroJoystickStick[MaxJoystickSticks];

  [MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxJoystickButtons)]
  private int[] button = new int[MaxJoystickButtons];

  public AllegroJoystickState()
  {
  }
}

[StructLayout(LayoutKind.Sequential)]
public struct AllegroJoystickStick
{
  public float[] Axis
  {
    readonly get => axis;
    set => axis = value;
  }

  private const int MaxJoystickAxes = 3;

  [MarshalAs(UnmanagedType.ByValArray, SizeConst = MaxJoystickAxes)]
  private float[] axis = new float[MaxJoystickAxes];

  public AllegroJoystickStick()
  {
  }
}
