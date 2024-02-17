using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static bool InstallKeyboard()
  {
    return Interop.Core.AlInstallKeyboard() != 0;
  }

  public static bool IsKeyboardInstalled()
  {
    return Interop.Core.AlIsKeyboardInstalled() != 0;
  }

  public static void UninstallKeyboard()
  {
    Interop.Core.AlUninstallKeyboard();
  }

  public static void GetKeyboardState(ref AllegroKeyboardState retState)
  {
    Interop.Core.AlGetKeyboardState(ref retState);
  }

  public static bool KeyDown(ref AllegroKeyboardState state, KeyCode keyCode)
  {
    return Interop.Core.AlKeyDown(ref state, (int)keyCode) != 0;
  }

  public static string? KeycodeToName(KeyCode keyCode)
  {
    var pointer = Interop.Core.AlKeycodeToName((int)keyCode);
    return Marshal.PtrToStringAnsi(pointer);
  }

  public static bool SetKeyboardLeds(KeyCode keyCode)
  {
    return Interop.Core.AlSetKeyboardLeds((int)keyCode) != 0;
  }

  public static AllegroEventSource? GetKeyboardEventSource()
  {
    var pointer = Interop.Core.AlGetKeyboardEventSource();
    return NativePointer.Create<AllegroEventSource>(pointer);
  }
}
