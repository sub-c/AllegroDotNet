using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroDisplayExtensions
  {
    public static void DestroyDisplay(this AllegroDisplay? display)
      => Al.DestroyDisplay(display);

    public static AllegroEventSource? GetDisplayEventSource(this AllegroDisplay? display)
      => Al.GetDisplayEventSource(display);

    public static AllegroBitmap? GetBackbuffer(this AllegroDisplay? display)
      => Al.GetBackbuffer(display);

    public static int GetDisplayWidth(this AllegroDisplay? display)
      => Al.GetDisplayWidth(display);

    public static int GetDisplayHeight(this AllegroDisplay? display)
      => Al.GetDisplayHeight(display);

    public static bool ResizeDisplay(this AllegroDisplay? display, int width, int height)
      => Al.ResizeDisplay(display, width, height);

    public static bool AcknowledgeResize(this AllegroDisplay? display)
      => Al.AcknowledgeResize(display);

    public static void GetWindowPosition(this AllegroDisplay? display, ref int x, ref int y)
      => Al.GetWindowPosition(display, ref x, ref y);

    public static void SetWindowPosition(this AllegroDisplay? display, int x, int y)
      => Al.SetWindowPosition(display, x, y);

    public static bool GetWindowConstraints(this AllegroDisplay? display, ref int minWidth, ref int minHeight, ref int maxWidth, ref int maxHeight)
      => Al.GetWindowConstraints(display, ref minWidth, ref minHeight, ref maxWidth, ref maxHeight);

    public static bool SetWindowConstraints(this AllegroDisplay? display, int minWidth, int minHeight, int maxWidth, int maxHeight)
      => Al.SetWindowConstraints(display, minWidth, minHeight, maxWidth, maxHeight);

    public static void ApplyWindowConstraints(this AllegroDisplay? display, bool onOff)
      => Al.ApplyWindowConstraints(display, onOff);

    public static DisplayFlags GetDisplayFlags(this AllegroDisplay? display)
      => Al.GetDisplayFlags(display);

    public static bool SetDisplayFlag(this AllegroDisplay? display, DisplayFlags flag, bool onOff)
      => Al.SetDisplayFlag(display, flag, onOff);

    public static int GetDisplayOption(this AllegroDisplay? display, DisplayOption option)
      => Al.GetDisplayOption(display, option);

    public static void SetDisplayOption(this AllegroDisplay? display, DisplayOption option, int value)
      => Al.SetDisplayOption(display, option, value);

    public static PixelFormat GetDisplayFormat(this AllegroDisplay? display)
      => Al.GetDisplayFormat(display);

    public static DisplayOrientation GetDisplayOrientation(this AllegroDisplay? display)
      => Al.GetDisplayOrientation(display);

    public static int GetDisplayRefreshRate(this AllegroDisplay? display)
      => Al.GetDisplayRefreshRate(display);

    public static void SetWindowTitle(this AllegroDisplay? display, string title)
      => Al.SetWindowTitle(display, title);

    public static void SetDisplayIcon(this AllegroDisplay? display, AllegroBitmap? icon)
      => Al.SetDisplayIcon(display, icon);

    public static void SetDisplayIcons(this AllegroDisplay? display, int numIcons, AllegroBitmap?[] icons)
      => Al.SetDisplayIcons(display, numIcons, icons);

    public static void AcknowledgeDrawingHalt(this AllegroDisplay? display)
      => Al.AcknowledgeDrawingHalt(display);

    public static void AcknowledgeDrawingResume(this AllegroDisplay? display)
      => Al.AcknowledgeDrawingResume(display);

    public static string? GetClipboardText(this AllegroDisplay? display)
      => Al.GetClipboardText(display);

    public static bool SetClipboardText(this AllegroDisplay? display, string text)
      => Al.SetClipboardText(display, text);

    public static bool ClipboardHasText(this AllegroDisplay? display)
      => Al.ClipboardHasText(display);

    public static void SetTargetBackbuffer(this AllegroDisplay? display)
      => Al.SetTargetBackbuffer(display);
  }
}
