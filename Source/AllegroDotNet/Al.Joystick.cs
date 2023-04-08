using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static bool InstallJoystick()
  {
    return NativeFunctions.AlInstallJoystick();
  }

  public static void UninstallJoystick()
  {
    NativeFunctions.AlUninstallJoystick();
  }

  public static bool IsJoystickInstalled()
  {
    return NativeFunctions.AlIsJoystickInstalled();
  }

  public static bool ReconfigureJoysticks()
  {
    return NativeFunctions.AlReconfigureJoysticks();
  }

  public static int GetNumJoysticks()
  {
    return NativeFunctions.AlGetNumJoysticks();
  }

  public static AllegroJoystick? GetJoystick(int joystickIndex)
  {
    var nativeJoy = NativeFunctions.AlGetJoystick(joystickIndex);
    return NativePointerModel.Create<AllegroJoystick>(nativeJoy);
  }

  public static void ReleaseJoystick(AllegroJoystick? joystick)
  {
    NativeFunctions.AlReleaseJoystick(NativePointerModel.GetPointer(joystick));
  }

  public static bool GetJoystickActive(AllegroJoystick? joystick)
  {
    return NativeFunctions.AlGetJoystickActive(NativePointerModel.GetPointer(joystick));
  }

  public static string? GetJoystickName(AllegroJoystick? joystick)
  {
    var nativeName = NativeFunctions.AlGetJoystickName(NativePointerModel.GetPointer(joystick));
    return Marshal.PtrToStringAnsi(nativeName);
  }

  public static string? GetJoystickStickName(AllegroJoystick? joystick, int stick)
  {
    var nativeName = NativeFunctions.AlGetJoystickStickName(NativePointerModel.GetPointer(joystick), stick);
    return Marshal.PtrToStringAnsi(nativeName);
  }

  public static string? GetJoystickAxisName(AllegroJoystick? joystick, int stick, int axis)
  {
    var nativeName = NativeFunctions.AlGetJoystickAxisName(NativePointerModel.GetPointer(joystick), stick, axis);
    return Marshal.PtrToStringAnsi(nativeName);
  }

  public static string? GetJoystickButtonName(AllegroJoystick? joystick, int button)
  {
    var nativeName = NativeFunctions.AlGetJoystickButtonName(NativePointerModel.GetPointer(joystick), button);
    return Marshal.PtrToStringAnsi(nativeName);
  }

  public static int GetJoystickStickFlags(AllegroJoystick? joystick, int stick)
  {
    return NativeFunctions.AlGetJoystickStickFlags(NativePointerModel.GetPointer(joystick), stick);
  }

  public static int GetJoystickNumSticks(AllegroJoystick? joystick)
  {
    return NativeFunctions.AlGetJoystickNumSticks(NativePointerModel.GetPointer(joystick));
  }

  public static int GetJoystickNumAxes(AllegroJoystick? joystick, int stick)
  {
    return NativeFunctions.AlGetJoystickNumAxes(NativePointerModel.GetPointer(joystick), stick);
  }

  public static int GetJoystickNumButtons(AllegroJoystick? joystick)
  {
    return NativeFunctions.AlGetJoystickNumButtons(NativePointerModel.GetPointer(joystick));
  }

  public static void GetJoystickState(AllegroJoystick? joystick, AllegroJoystickState joystickState)
  {
    NativeFunctions.AlGetJoystickState(NativePointerModel.GetPointer(joystick), ref joystickState.JoystickState);
  }

  public static AllegroEventSource? GetJoystickEventSource()
  {
    var nativeSource = NativeFunctions.AlGetJoystickEventSource();
    return NativePointerModel.Create<AllegroEventSource>(nativeSource);
  }
}
