using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static bool InstallJoystick()
  {
    return Interop.Core.AlInstallJoystick() != 0;
  }

  public static void UninstallJoystick()
  {
    Interop.Core.AlUninstallJoystick();
  }

  public static bool IsJoystickInstalled()
  {
    return Interop.Core.AlIsJoystickInstalled() != 0;
  }

  public static bool ReconfigureJoysticks()
  {
    return Interop.Core.AlReconfigureJoysticks() != 0;
  }

  public static int GetNumJoysticks()
  {
    return Interop.Core.AlGetNumJoysticks();
  }

  public static AllegroJoystick? GetJoystick(int num)
  {
    var pointer = Interop.Core.AlGetJoystick(num);
    return NativePointer.Create<AllegroJoystick>(pointer);
  }

  public static void ReleaseJoystick(AllegroJoystick? joystick)
  {
    Interop.Core.AlReleaseJoystick(NativePointer.Get(joystick));
  }

  public static bool GetJoystickActive(AllegroJoystick? joystick)
  {
    return Interop.Core.AlGetJoystickActive(NativePointer.Get(joystick)) != 0;
  }

  public static string? GetJoystickName(AllegroJoystick? joystick)
  {
    var pointer = Interop.Core.AlGetJoystickName(NativePointer.Get(joystick));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetJoystickStickName(AllegroJoystick? joystick, int stick)
  {
    var pointer = Interop.Core.AlGetJoystickStickName(NativePointer.Get(joystick), stick);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetJoystickAxisName(AllegroJoystick? joystick, int stick, int axis)
  {
    var pointer = Interop.Core.AlGetJoystickAxisName(NativePointer.Get(joystick), stick, axis);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static string? GetJoystickButtonName(AllegroJoystick? joystick, int button)
  {
    var pointer = Interop.Core.AlGetJoystickButtonName(NativePointer.Get(joystick), button);
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static JoyFlags GetJoystickStickFlags(AllegroJoystick? joystick, int stick)
  {
    return (JoyFlags)Interop.Core.AlGetJoystickStickFlags(NativePointer.Get(joystick), stick);
  }

  public static int GetJoystickNumSticks(AllegroJoystick? joystick)
  {
    return Interop.Core.AlGetJoystickNumSticks(NativePointer.Get(joystick));
  }

  public static int GetJoystickNumAxes(AllegroJoystick? joystick, int stick)
  {
    return Interop.Core.AlGetJoystickNumAxes(NativePointer.Get(joystick), stick);
  }

  public static int GetJoystickNumButtons(AllegroJoystick? joystick)
  {
    return Interop.Core.AlGetJoystickNumButtons(NativePointer.Get(joystick));
  }

  public static void GetJoystickState(AllegroJoystick? joystick, ref AllegroJoystickState state)
  {
    Interop.Core.AlGetJoystickState(NativePointer.Get(joystick), ref state);
  }

  public static AllegroEventSource? GetJoystickEventSource()
  {
    var pointer = Interop.Core.AlGetJoystickEventSource();
    return NativePointer.Create<AllegroEventSource>(pointer);
  }
}
