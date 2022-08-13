using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static bool InstallMouse()
    {
      return NativeFunctions.AlInstallMouse();
    }

    public static bool IsMouseInstalled()
    {
      return NativeFunctions.AlIsMouseInstalled();
    }

    public static void UninstallMouse()
    {
      NativeFunctions.AlUninstallMouse();
    }

    public static uint GetMouseNumAxes()
    {
      return NativeFunctions.AlGetMouseNumAxes();
    }

    public static uint GetMouseNumButtons()
    {
      return NativeFunctions.AlGetMouseNumButtons();
    }

    public static void GetMouseState(AllegroMouseState mouseState)
    {
      NativeFunctions.AlGetMouseState(ref mouseState.MouseState);
    }

    public static int GetMouseStateAxis(AllegroMouseState mouseState, int axis)
    {
      return NativeFunctions.AlGetMouseStateAxis(ref mouseState.MouseState, axis);
    }

    public static bool MouseButtonDown(AllegroMouseState mouseState, int button)
    {
      return NativeFunctions.AlMouseButtonDown(ref mouseState.MouseState, button);
    }

    public static bool SetMouseXY(AllegroDisplay? display, int x, int y)
    {
      return NativeFunctions.AlSetMouseXY(NativePointerModel.GetPointer(display), x, y);
    }

    public static bool SetMouseZ(int z)
    {
      return NativeFunctions.AlSetMouseZ(z);
    }

    public static bool SetMouseW(int w)
    {
      return NativeFunctions.AlSetMouseW(w);
    }

    public static bool SetMouseAxis(int axis, int value)
    {
      return NativeFunctions.AlSetMouseAxis(axis, value);
    }

    public static AllegroEventSource? GetMouseEventSource()
    {
      var nativeSource = NativeFunctions.AlGetMouseEventSource();
      return NativePointerModel.Create<AllegroEventSource>(nativeSource);
    }

    public static void SetMouseWheelPrecision(int precision)
    {
      NativeFunctions.AlSetMouseWheelPrecision(precision);
    }

    public static int GetMouseWheelPrecision()
    {
      return NativeFunctions.AlGetMouseWheelPrecision();
    }

    public static AllegroMouseCursor? CreateMouseCursor(AllegroBitmap? bitmap, int xFocus, int yFocus)
    {
      var nativeCursor = NativeFunctions.AlCreateMouseCursor(NativePointerModel.GetPointer(bitmap), xFocus, yFocus);
      return NativePointerModel.Create<AllegroMouseCursor>(nativeCursor);
    }

    public static void DestroyMouseCursor(AllegroMouseCursor? cursor)
    {
      NativeFunctions.AlDestroyMouseCursor(NativePointerModel.GetPointer(cursor));
    }

    public static bool SetMouseCursor(AllegroDisplay? display, AllegroMouseCursor? cursor)
    {
      return NativeFunctions.AlSetMouseCursor(NativePointerModel.GetPointer(display), NativePointerModel.GetPointer(cursor));
    }

    public static bool SetSystemMouseCursor(AllegroDisplay? display, MouseCursor cursor)
    {
      return NativeFunctions.AlSetSystemMouseCursor(NativePointerModel.GetPointer(display), (int)cursor);
    }

    public static bool GetMouseCursorPosition(ref int x, ref int y)
    {
      return NativeFunctions.AlGetMouseCursorPosition(ref x, ref y);
    }

    public static bool HideMouseCursor(AllegroDisplay? display)
    {
      return NativeFunctions.AlHideMouseCursor(NativePointerModel.GetPointer(display));
    }

    public static bool ShowMouseCursor(AllegroDisplay? display)
    {
      return NativeFunctions.AlShowMouseCursor(NativePointerModel.GetPointer(display));
    }

    public static bool GrabMouse(AllegroDisplay? display)
    {
      return NativeFunctions.AlGrabMouse(NativePointerModel.GetPointer(display));
    }

    public static bool UngrabMouse()
    {
      return NativeFunctions.AlUngrabMouse();
    }
  }
}