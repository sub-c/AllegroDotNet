using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroDisplay? CreateDisplay(int width, int height)
    {
      var nativePointer = NativeFunctions.AlCreateDisplay(width, height);
      return NativePointerModel.Create<AllegroDisplay>(nativePointer);
    }

    public static void DestroyDisplay(AllegroDisplay? display)
    {
      NativeFunctions.AlDestroyDisplay(NativePointerModel.GetPointer(display));
    }

    public static DisplayFlags GetNewDisplayFlags()
    {
      return (DisplayFlags)NativeFunctions.AlGetNewDisplayFlags();
    }

    public static void SetNewDisplayFlags(DisplayFlags flags)
    {
      NativeFunctions.AlSetNewDisplayFlags((int)flags);
    }

    public static int GetNewDisplayOption(DisplayOption option, ref DisplayImportance importance)
    {
      int importanceInt = (int)importance;
      var returnValue = NativeFunctions.AlGetNewDisplayOption((int)option, ref importanceInt);
      importance = (DisplayImportance)importanceInt;
      return returnValue;
    }

    public static void SetNewDisplayOption(DisplayOption option, int value, DisplayImportance importance)
    {
      NativeFunctions.AlSetNewDisplayOption((int)option, value, (int)importance);
    }

    public static void ResetNewDisplayOptions()
    {
      NativeFunctions.AlResetNewDisplayOptions();
    }

    public static void GetNewWindowPosition(ref int x, ref int y)
    {
      NativeFunctions.AlGetNewWindowPosition(ref x, ref y);
    }

    public static void SetNewWindowPosition(int x, int y)
    {
      NativeFunctions.AlSetNewWindowPosition(x, y);
    }

    public static int GetNewDisplayRefreshRate()
    {
      return NativeFunctions.AlGetNewDisplayRefreshRate();
    }

    public static void SetNewDisplayRefreshRate(int refreshRate)
    {
      NativeFunctions.AlSetNewDisplayRefreshRate(refreshRate);
    }

    public static AllegroEventSource? GetDisplayEventSource(AllegroDisplay? display)
    {
      var sourcePtr = NativeFunctions.AlGetDisplayEventSource(NativePointerModel.GetPointer(display));
      return NativePointerModel.Create<AllegroEventSource>(sourcePtr);
    }

    public static AllegroBitmap? GetBackbuffer(AllegroDisplay? display)
    {
      var nativePointer = NativeFunctions.AlGetBackbuffer(NativePointerModel.GetPointer(display));
      return NativePointerModel.Create<AllegroBitmap>(nativePointer);
    }

    public static void FlipDisplay()
    {
      NativeFunctions.AlFlipDisplay();
    }

    public static void UpdateDisplayRegion(int x, int y, int width, int height)
    {
      NativeFunctions.AlUpdateDisplayRegion(x, y, width, height);
    }

    public static bool WaitForVSync()
    {
      return NativeFunctions.AlWaitForVSync();
    }

    public static int GetDisplayWidth(AllegroDisplay? display)
    {
      return NativeFunctions.AlGetDisplayWidth(NativePointerModel.GetPointer(display));
    }

    public static int GetDisplayHeight(AllegroDisplay? display)
    {
      return NativeFunctions.AlGetDisplayHeight(NativePointerModel.GetPointer(display));
    }

    public static bool ResizeDisplay(AllegroDisplay? display, int width, int height)
    {
      return NativeFunctions.AlResizeDisplay(NativePointerModel.GetPointer(display), width, height);
    }

    public static bool AcknowledgeResize(AllegroDisplay? display)
    {
      return NativeFunctions.AlAcknowledgeResize(NativePointerModel.GetPointer(display));
    }

    public static void GetWindowPosition(AllegroDisplay? display, ref int x, ref int y)
    {
      NativeFunctions.AlGetWindowPosition(NativePointerModel.GetPointer(display), ref x, ref y);
    }

    public static void SetWindowPosition(AllegroDisplay? display, int x, int y)
    {
      NativeFunctions.AlSetWindowPosition(NativePointerModel.GetPointer(display), x, y);
    }

    public static bool GetWindowConstraints(AllegroDisplay? display, ref int minW, ref int minH, ref int maxW, ref int maxH)
    {
      return NativeFunctions.AlGetWindowConstraints(NativePointerModel.GetPointer(display), ref minW, ref minH, ref maxW, ref maxH);
    }

    public static bool SetWindowConstraints(AllegroDisplay? display, int minW, int minH, int maxW, int maxH)
    {
      return NativeFunctions.AlSetWindowConstraints(NativePointerModel.GetPointer(display), minW, minH, maxW, maxH);
    }

    public static void ApplyWindowConstraints(AllegroDisplay? display, bool onOff)
    {
      NativeFunctions.AlApplyWindowConstraints(NativePointerModel.GetPointer(display), onOff);
    }

    public static DisplayFlags GetDisplayFlags(AllegroDisplay? display)
    {
      return (DisplayFlags)NativeFunctions.AlGetDisplayFlags(NativePointerModel.GetPointer(display));
    }

    public static bool SetDisplayFlag(AllegroDisplay? display, DisplayFlags flag, bool onOff)
    {
      return NativeFunctions.AlSetDisplayFlag(NativePointerModel.GetPointer(display), (int)flag, onOff);
    }

    public static int GetDisplayOption(AllegroDisplay? display, DisplayOption option)
    {
      return NativeFunctions.AlGetDisplayOption(NativePointerModel.GetPointer(display), (int)option);
    }

    public static void SetDisplayOption(AllegroDisplay? display, DisplayOption option, int value)
    {
      NativeFunctions.AlSetDisplayOption(NativePointerModel.GetPointer(display), (int)option, value);
    }

    public static PixelFormat GetDisplayFormat(AllegroDisplay? display)
    {
      return (PixelFormat)NativeFunctions.AlGetDisplayFormat(NativePointerModel.GetPointer(display));
    }

    public static DisplayOrientation GetDisplayOrientation(AllegroDisplay? display)
    {
      return (DisplayOrientation)NativeFunctions.AlGetDisplayOrientation(NativePointerModel.GetPointer(display));
    }

    public static int GetDisplayRefreshRate(AllegroDisplay? display)
    {
      return NativeFunctions.AlGetDisplayRefreshRate(NativePointerModel.GetPointer(display));
    }

    public static void SetWindowTitle(AllegroDisplay? display, string title)
    {
      var nativeString = Marshal.StringToHGlobalAnsi(title);
      NativeFunctions.AlSetWindowTitle(NativePointerModel.GetPointer(display), nativeString);
      Marshal.FreeHGlobal(nativeString);
    }

    public static void SetNewWindowTitle(string title)
    {
      var nativeString = Marshal.StringToHGlobalAnsi(title);
      NativeFunctions.AlSetNewWindowTitle(nativeString);
      Marshal.FreeHGlobal(nativeString);
    }

    public static string? GetNewWindowTitle()
    {
      var nativeString = NativeFunctions.AlGetNewWindowTitle();
      return Marshal.PtrToStringAnsi(nativeString);
    }

    public static void SetDisplayIcon(AllegroDisplay? display, AllegroBitmap? icon)
    {
      NativeFunctions.AlSetDisplayIcon(NativePointerModel.GetPointer(display), NativePointerModel.GetPointer(icon));
    }

    public static void SetDisplayIcons(AllegroDisplay? display, int numIcons, AllegroBitmap?[] icons)
    {
      var nativeIcons = new IntPtr[numIcons];
      for (var i = 0; i < numIcons; ++i)
      {
        nativeIcons[i] = NativePointerModel.GetPointer(icons[i]);
      }
      NativeFunctions.AlSetDisplayIcons(NativePointerModel.GetPointer(display), numIcons, ref nativeIcons);
    }

    public static void AcknowledgeDrawingHalt(AllegroDisplay? display)
    {
      NativeFunctions.AlAcknowledgeDrawingHalt(NativePointerModel.GetPointer(display));
    }

    public static void AcknowledgeDrawingResume(AllegroDisplay? display)
    {
      NativeFunctions.AlAcknowledgeDrawingResume(NativePointerModel.GetPointer(display));
    }

    public static bool InhibitScreensaver(bool inhibit)
    {
      return NativeFunctions.AlInhibitScreensaver(inhibit);
    }

    public static string? GetClipboardText(AllegroDisplay? display)
    {
      var nativeString = NativeFunctions.AlGetClipboardText(NativePointerModel.GetPointer(display));
      var managedString = Marshal.PtrToStringAnsi(nativeString);
      Al.Free(nativeString);
      return managedString;
    }

    public static bool SetClipboardText(AllegroDisplay? display, string text)
    {
      var nativeString = Marshal.StringToHGlobalAnsi(text);
      var returnValue = NativeFunctions.AlSetClipboardText(NativePointerModel.GetPointer(display), nativeString);
      Marshal.FreeHGlobal(nativeString);
      return returnValue;
    }

    public static bool ClipboardHasText(AllegroDisplay? display)
    {
      return NativeFunctions.AlClipboardHasText(NativePointerModel.GetPointer(display));
    }
  }
}