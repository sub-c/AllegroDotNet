using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static bool InstallTouchInput()
  {
    return Interop.Core.AlInstallTouchInput() != 0;
  }

  public static void UninstallTouchInput()
  {
    Interop.Core.AlUninstallTouchInput();
  }

  public static bool IsTouchInputInstalled()
  {
    return Interop.Core.AlIsTouchInputInstalled() != 0;
  }

  public static void GetTouchInputState(ref AllegroTouchInputState touchState)
  {
    Interop.Core.AlGetTouchInputState(ref touchState);
  }

  public static AllegroEventSource? GetTouchInputEventSource()
  {
    var pointer = Interop.Core.AlGetTouchInputEventSource();
    return NativePointer.Create<AllegroEventSource>(pointer);
  }
}
