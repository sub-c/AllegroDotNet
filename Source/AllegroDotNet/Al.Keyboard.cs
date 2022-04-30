using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static bool InstallKeyboard()
    {
      return NativeFunctions.AlInstallKeyboard();
    }

    public static bool IsKeyboardInstalled()
    {
      return NativeFunctions.AlIsKeyboardInstalled();
    }

    public static void UninstallKeyboard()
    {
      NativeFunctions.AlUninstallKeyboard();
    }

    public static void GetKeyboardState(AllegroKeyboardState keyboardState)
    {
      NativeFunctions.AlGetKeyboardState(ref keyboardState.KeyboardState);
    }

    public static bool KeyDown(AllegroKeyboardState keyboardState, KeyCode keyCode)
    {
      return NativeFunctions.AlKeyDown(ref keyboardState.KeyboardState, (int)keyCode);
    }

    public static string? KeycodeToName(KeyCode keyCode)
    {
      var nativeName = NativeFunctions.AlKeycodeToName((int)keyCode);
      return Marshal.PtrToStringAnsi(nativeName);
    }

    public static bool SetKeyboardLeds(KeyCode keyCode)
    {
      return NativeFunctions.AlSetKeyboardLeds((int)keyCode);
    }

    public static AllegroEventSource? GetKeyboardEventSource()
    {
      var nativeSource = NativeFunctions.AlGetKeyboardEventSource();
      return NativePointerModel.Create<AllegroEventSource>(nativeSource);
    }
  }
}