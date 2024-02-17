using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static bool InstallMouse()
  {
    return Interop.Core.AlInstallMouse() != 0;
  }

  public static bool IsMouseInstalled()
  {
    return Interop.Core.AlIsMouseInstalled() != 0;
  }

  public static void UninstallMouse()
  {
    Interop.Core.AlUninstallMouse();
  }

  public static uint GetMouseNumAxes()
  {
    return Interop.Core.AlGetMouseNumAxes();
  }

  public static uint GetMouseNumButtons()
  {
    return Interop.Core.AlGetMouseNumButtons();
  }

  public static void GetMouseState(ref AllegroMouseState state)
  {
    Interop.Core.AlGetMouseState(ref state);
  }

  public static int GetMouseStateAxis(ref AllegroMouseState state, int axis)
  {
    return Interop.Core.AlGetMouseStateAxis(ref state, axis);
  }

  public static bool MouseButtonDown(ref AllegroMouseState state, int button)
  {
    return Interop.Core.AlMouseButtonDown(ref state, button) != 0;
  }

  public static bool SetMouseXY(AllegroDisplay? display, int x, int y)
  {
    return Interop.Core.AlSetMouseXY(NativePointer.Get(display), x, y) != 0;
  }

  public static bool SetMouseZ(int z)
  {
    return Interop.Core.AlSetMouseZ(z) != 0;
  }

  public static bool SetMouseW(int w)
  {
    return Interop.Core.AlSetMouseW(w) != 0;
  }

  public static bool SetMouseAxis(int axis, int value)
  {
    return Interop.Core.AlSetMouseAxis(axis, value) != 0;
  }

  public static AllegroEventSource? GetMouseEventSource()
  {
    var pointer = Interop.Core.AlGetMouseEventSource();
    return NativePointer.Create<AllegroEventSource>(pointer);
  }

  public static void SetMouseWheelPrecision(int precision)
  {
    Interop.Core.AlSetMouseWheelPrecision(precision);
  }

  public static int GetMouseWheelPrecision()
  {
    return Interop.Core.AlGetMouseWheelPrecision();
  }

  public static AllegroMouseCursor? CreateMouseCursor(AllegroBitmap? bitmap, int xFocus, int yFocus)
  {
    var pointer = Interop.Core.AlCreateMouseCursor(NativePointer.Get(bitmap), xFocus, yFocus);
    return NativePointer.Create<AllegroMouseCursor>(pointer);
  }

  public static void DestroyMouseCursor(AllegroMouseCursor? cursor)
  {
    Interop.Core.AlDestroyMouseCursor(NativePointer.Get(cursor));
  }

  public static bool SetMouseCursor(AllegroDisplay? display, AllegroMouseCursor? cursor)
  {
    return Interop.Core.AlSetMouseCursor(NativePointer.Get(display), NativePointer.Get(cursor)) != 0;
  }

  public static bool SetSystemMouseCursor(AllegroDisplay? display, SystemMouseCursor cursor)
  {
    return Interop.Core.AlSetSystemMouseCursor(NativePointer.Get(display), (int)cursor) != 0;
  }

  public static bool GetMouseCursorPosition(ref int x, ref int y)
  {
    return Interop.Core.AlGetMouseCursorPosition(ref x, ref y) != 0;
  }

  public static bool HideMouseCursor(AllegroDisplay? display)
  {
    return Interop.Core.AlHideMouseCursor(NativePointer.Get(display)) != 0;
  }

  public static bool ShowMouseCursor(AllegroDisplay? display)
  {
    return Interop.Core.AlShowMouseCursor(NativePointer.Get(display)) != 0;
  }

  public static bool GrabMouse(AllegroDisplay? display)
  {
    return Interop.Core.AlGrabMouse(NativePointer.Get(display)) != 0;
  }

  public static bool UngrabMouse()
  {
    return Interop.Core.AlUngrabMouse() != 0;
  }
}
