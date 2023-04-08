using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static bool InstallTouchInput()
  {
    return NativeFunctions.AlInstallTouchInput();
  }

  public static void UninstallTouchInput()
  {
    NativeFunctions.AlUninstallTouchInput();
  }

  public static bool IsTouchInputInstalled()
  {
    return NativeFunctions.AlIsTouchInputInstalled();
  }

  public static void GetTouchInputState(AllegroTouchInputState touchState)
  {
    NativeFunctions.AlGetTouchInputState(ref touchState.TouchInputState);
  }

  public static AllegroEventSource? GetTouchInputEventSource()
  {
    var nativeSource = NativeFunctions.AlGetTouchInputEventSource();
    return NativePointerModel.Create<AllegroEventSource>(nativeSource);
  }
}
