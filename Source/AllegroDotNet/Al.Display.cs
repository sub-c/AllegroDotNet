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
  /// <summary>
  /// Create a display, or window, with the specified dimensions. The parameters of the display are determined by the
  /// last calls to <see cref="SetNewDisplayFlags"/>. Default parameters are used if none are set explicitly. Creating
  /// a new display will automatically make it the active one, with the backbuffer selected for drawing.
  /// <para>
  /// Each display that uses OpenGL as a backend has a distinct OpenGL rendering context associated with it.
  /// </para>
  /// </summary>
  /// <param name="width">Width of the display in pixels.</param>
  /// <param name="height">Height of the display in pixels.</param>
  /// <returns>An <see cref="AllegroDisplay"/> instance if successful, otherwise <c>null</c>.</returns>
  public static AllegroDisplay? CreateDisplay(int width, int height)
  {
    var pointer = Interop.Core.AlCreateDisplay(width, height);
    return NativePointer.Create<AllegroDisplay>(pointer);
  }

  /// <summary>
  /// Destroys a display.
  /// <para>
  /// If the target bitmap of the calling thread is tied to the display, then it implies a call to
  /// "<c>SetTargetBitmap(null)</c>” before the display is destroyed.
  /// </para>
  /// <para>
  /// That special case notwithstanding, you should make sure no threads are currently targeting a bitmap which is
  /// tied to the display before you destroy it.
  /// </para>
  /// </summary>
  /// <param name="display">The display instance to destroy.</param>
  public static void DestroyDisplay(AllegroDisplay? display)
  {
    Interop.Core.AlDestroyDisplay(NativePointer.Get(display));
  }

  /// <summary>
  /// Gets the display flags used when creating new displays on the calling thread.
  /// </summary>
  /// <returns>The display flags used when creating new displays on the calling thread.</returns>
  public static DisplayFlags GetNewDisplayFlags()
  {
    return (DisplayFlags)Interop.Core.AlGetNewDisplayFlags();
  }

  /// <summary>
  /// Sets various flags to be used when creating new displays on the calling thread.
  /// </summary>
  /// <param name="flags">Flags to be used when creating new displays on the calling thread.</param>
  public static void SetNewDisplayFlags(DisplayFlags flags)
  {
    Interop.Core.AlSetNewDisplayFlags((int)flags);
  }

  /// <summary>
  /// Retrieve an extra display setting which was previously set with <see cref="SetNewDisplayOption"/>.
  /// </summary>
  /// <param name="option">The display option.</param>
  /// <param name="importance">The importance of the display option.</param>
  /// <returns>The value of the display option.</returns>
  public static int GetNewDisplayOption(DisplayOption option, out DisplayImportance importance)
  {
    var nativeImportance = 0;
    var value = Interop.Core.AlGetNewDisplayOption((int)option, ref nativeImportance);
    importance = (DisplayImportance)nativeImportance;
    return value;
  }

  /// <summary>
  /// Set an extra display option, to be used when creating new displays on the calling thread. Display options differ
  /// from display flags, and specify some details of the context to be created within the window itself. These mainly
  /// have no effect on Allegro itself, but you may want to specify them, for example if you want to use multisampling.
  /// </summary>
  /// <param name="option">The display option.</param>
  /// <param name="value">The value of the display option.</param>
  /// <param name="importance">The importance of the display option.</param>
  public static void SetNewDisplayOption(DisplayOption option, int value, DisplayImportance importance)
  {
    Interop.Core.AlSetNewDisplayOption((int)option, value, (int)importance);
  }

  /// <summary>
  /// Undoes any previous call to <see cref="SetNewDisplayOption"/> on the calling thread.
  /// </summary>
  public static void ResetNewDisplayOptions()
  {
    Interop.Core.AlResetNewDisplayOptions();
  }

  /// <summary>
  /// Gets the position where new non-fullscreen displays are created by the calling thread will be placed.
  /// </summary>
  /// <param name="x">The X position.</param>
  /// <param name="y">The Y position.</param>
  public static void GetNewWindowPosition(out int x, out int y)
  {
    x = y = 0;
    Interop.Core.AlGetNewWindowPosition(ref x, ref y);
  }

  /// <summary>
  /// Sets where the top left pixel of the client area of newly created windows (non-fullscreen) will be on screen,
  /// for displays created by the calling thread. Negative values are allowed on some multi-head systems.
  /// To reset to the default behavior, pass (INT_MAX, INT_MAX).
  /// </summary>
  /// <param name="x">The X position.</param>
  /// <param name="y">The Y position.</param>
  public static void SetNewWindowPosition(int x, int y)
  {
    Interop.Core.AlSetNewWindowPosition(x, y);
  }

  /// <summary>
  /// Gets the requested refresh rate to be used when creating new displays on the calling thread.
  /// </summary>
  /// <returns>The requested refresh rate to be used when creating new displays on the calling thread.</returns>
  public static int GetNewDisplayRefreshRate()
  {
    return Interop.Core.AlGetNewDisplayRefreshRate();
  }

  /// <summary>
  /// Sets the refresh rate to use when creating new displays on the calling thread. If the refresh rate is not
  /// available, <see cref="CreateDisplay"/> will fail. A list of modes with refresh rates can be found with
  /// <see cref="GetNumDisplayModes"/> and <see cref="GetDisplayMode"/>. The default setting is 0 (do not care).
  /// </summary>
  /// <param name="refreshRate">The refresh rate to use when creating new displays on the calling thread.</param>
  public static void SetNewDisplayRefreshRate(int refreshRate)
  {
    Interop.Core.AlSetNewDisplayRefreshRate(refreshRate);
  }

  /// <summary>
  /// Retrieve the associated event source of a display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The display event source instance if successful, otherwise <c>null</c>.</returns>
  public static AllegroEventSource? GetDisplayEventSource(AllegroDisplay? display)
  {
    var pointer = Interop.Core.AlGetDisplayEventSource(NativePointer.Get(display));
    return NativePointer.Create<AllegroEventSource>(pointer);
  }

  /// <summary>
  /// <para>
  /// Return a special bitmap representing the back-buffer of the display.
  /// </para>
  /// <para>
  /// Care should be taken when using the backbuffer bitmap (and its sub-bitmaps) as the source bitmap (e.g as the
  /// bitmap argument to al_draw_bitmap). Only untransformed operations are hardware accelerated. These consist of
  /// <see cref="DrawBitmap"/> and <see cref="DrawBitmapRegion"/> when the current transformation is the identity.
  /// If the transformation is not the identity, or some other drawing operation is used, the call will be routed
  /// through the memory bitmap routines, which are slow. If you need those operations to be accelerated, then first
  /// copy a region of the backbuffer into a temporary bitmap (via the <see cref="DrawBitmap"/> and
  /// <see cref="DrawBitmapRegion"/>), and then use that temporary bitmap as the source bitmap.
  /// </para>
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The display's backbuffer if successful, otherwise <c>null</c>.</returns>
  public static AllegroBitmap? GetBackbuffer(AllegroDisplay? display)
  {
    var pointer = Interop.Core.AlGetBackbuffer(NativePointer.Get(display));
    return NativePointer.Create<AllegroBitmap>(pointer);
  }

  /// <summary>
  /// <para>
  /// Copies or updates the front and back buffers so that what has been drawn previously on the currently selected
  /// display becomes visible on screen. Pointers to the special back buffer bitmap remain valid and retain their
  /// semantics as the back buffer, although the contents may have changed.
  /// </para>
  /// <para>
  /// If not using the <see cref="DisplayOption.SingleBuffer"/> option, you typically want to redraw every pixel of
  /// the backbuffer bitmap to avoid uninitialized memory artifacts.
  /// </para>
  /// <para>
  /// Several display options change how this function behaves:
  /// </para>
  /// <list type="table">
  /// <item>
  /// With <see cref="DisplayOption.SingleBuffer"/>, no flipping is done.
  /// You still have to call this function to display graphics, depending on how the used graphics system works.
  /// </item>
  /// <item>
  /// The <see cref="DisplayOption.SwapMethod"/> option may have additional information about what kind of operation is
  /// used internally to flip the front and back buffers.
  /// </item>
  /// <item>
  /// If <see cref="DisplayOption.VSync"/> is 1, this function will force waiting for vsync.
  /// If <see cref="DisplayOption.VSync"/> is 2, this function will not wait for vsync.
  /// With many drivers the vsync behavior is controlled by the user and not the application, and
  /// <see cref="DisplayOption.VSync"/> will not be set; in this case <see cref="FlipDisplay"/> will wait for vsync
  /// depending on the settings set in the system’s graphics preferences.
  /// </item>
  /// </list>
  /// </summary>
  public static void FlipDisplay()
  {
    Interop.Core.AlFlipDisplay();
  }

  /// <summary>
  /// Does the same as <see cref="FlipDisplay"/>, but tries to update only the specified region.
  /// With many drivers this is not possible, but for some it can improve performance. If this is not supported,
  /// this function falls back to the behavior of <see cref="FlipDisplay"/>. You can query the support for this
  /// function using <see cref="GetDisplayOption"/> with the <see cref="DisplayOption.UpdateDisplayRegion"/> option.
  /// </summary>
  /// <param name="x">The X position.</param>
  /// <param name="y">The Y position.</param>
  /// <param name="width">The width.</param>
  /// <param name="height">The height.</param>
  public static void UpdateDisplayRegion(int x, int y, int width, int height)
  {
    Interop.Core.AlUpdateDisplayRegion(x, y, width, height);
  }

  /// <summary>
  /// Wait for the beginning of a vertical retrace. Some driver/card/monitor combinations may not be capable of this.
  /// </summary>
  /// <returns>True if successful, otherwise false.</returns>
  public static bool WaitForVSync()
  {
    return Interop.Core.AlWaitForVsync() == 1;
  }

  /// <summary>
  /// Gets the width of the display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The width of the display.</returns>
  public static int GetDisplayWidth(AllegroDisplay? display)
  {
    return Interop.Core.AlGetDisplayWidth(NativePointer.Get(display));
  }

  /// <summary>
  /// Gets the height of the display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The height of the display.</returns>
  public static int GetDisplayHeight(AllegroDisplay? display)
  {
    return Interop.Core.AlGetDisplayHeight(NativePointer.Get(display));
  }

  /// <summary>
  /// Resize the display. Returns true on success, or false on error. This works on both fullscreen and windowed
  /// displays, regardless of the <see cref="DisplayFlags.Resizable"/> flag.
  /// Adjusts the clipping rectangle to the full size of the backbuffer.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="width">The new width in pixels.</param>
  /// <param name="height">The new height in pixels.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool ResizeDisplay(AllegroDisplay? display, int width, int height)
  {
    return Interop.Core.AlResizeDisplay(NativePointer.Get(display), width, height) == 1;
  }

  /// <summary>
  /// <para>
  /// When the user receives a resize event from a resizable display, if they wish the display to be resized they must
  /// call this function to let the graphics driver know that it can now resize the display. Returns true on success.
  /// </para>
  /// <para>
  /// Adjusts the clipping rectangle to the full size of the backbuffer. This also resets the back buffers projection
  /// transform to default orthographic transform (see <see cref="UseProjectionTransform"/>).
  /// </para>
  /// <para>
  /// Note that a resize event may be outdated by the time you acknowledge it; there could be further resize events
  /// generated in the meantime.
  /// </para>
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>True on success, otherwise false.</returns>
  public static bool AcknowledgeResize(AllegroDisplay? display)
  {
    return Interop.Core.AlAcknowledgeResize(NativePointer.Get(display)) == 1;
  }

  /// <summary>
  /// Gets the position of a non-fullscreen display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="x">The X position.</param>
  /// <param name="y">The Y position.</param>
  public static void GetWindowPosition(AllegroDisplay? display, out int x, out int y)
  {
    x = y = 0;
    Interop.Core.AlGetWindowPosition(NativePointer.Get(display), ref x, ref y);
  }

  /// <summary>
  /// Sets the position on screen of a non-fullscreen display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="x">The X position.</param>
  /// <param name="y">The Y position.</param>
  public static void SetWindowPosition(AllegroDisplay? display, int x, int y)
  {
    Interop.Core.AlSetWindowPosition(NativePointer.Get(display), x, y);
  }

  /// <summary>
  /// Gets the constraints for a non-fullscreen resizable display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="minWidth">The minimum window width.</param>
  /// <param name="minHeight">The minimum window height.</param>
  /// <param name="maxWidth">The maximum window width.</param>
  /// <param name="maxHeight">The maximum window height.</param>
  /// <returns>True if successful, otherwise false.</returns>
  public static bool GetWindowConstraints(
    AllegroDisplay? display,
    out int minWidth,
    out int minHeight,
    out int maxWidth,
    out int maxHeight)
  {
    minWidth = minHeight = maxWidth = maxHeight = 0;
    return Interop.Core.AlGetWindowConstraints(
      NativePointer.Get(display),
      ref minWidth,
      ref minHeight,
      ref maxWidth,
      ref maxHeight)
      == 1;
  }

  /// <summary>
  /// Constrains a non-fullscreen resizable display. The constraints are a hint only, and are not necessarily respected
  /// by the window environment. A value of 0 for any of the parameters indicates no constraint for that parameter.
  /// The constraints will be applied to a display only after the <see cref="ApplyWindowConstraints"/> function call.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="minWidth">The minimum window width.</param>
  /// <param name="minHeight">The minimum window height.</param>
  /// <param name="maxWidth">The maximum window width.</param>
  /// <param name="maxHeight">The maximum window height.</param>
  /// <returns>True if successful, otherwise false.</returns>
  public static bool SetWindowConstraints(AllegroDisplay? display, int minWidth, int minHeight, int maxWidth, int maxHeight)
  {
    return Interop.Core.AlSetWindowConstraints(
      NativePointer.Get(display),
      minWidth,
      minHeight,
      maxWidth,
      maxHeight)
      == 1;
  }

  /// <summary>
  /// <para>
  /// Enable or disable previously set constraints by <see cref="SetWindowConstraints"/> function.
  /// </para>
  /// <para>
  /// If enabled, the specified display will be automatically resized to new sizes to conform constraints in next cases:
  /// </para>
  /// <list type="table">
  /// <item>
  /// The specified display is resizable, not maximized and is not in fullscreen mode.
  /// </item>
  /// <item>
  /// If the appropriate current display size (width or height) is less than the value of constraint.
  /// Applied to minimum constraints.
  /// </item>
  /// <item>
  /// If the appropriate current display size (width or height) is greater than the value of constraint.
  /// Applied to maximum constraints.
  /// </item>
  /// </list>
  /// <para>
  /// Constrains are not applied when a display is toggle from windowed to maximized or fullscreen modes. When a
  /// display is toggle from maximized/fullscreen to windowed mode, then the display may be resized as described
  /// above. The later case is also possible when a user drags the maximized display via mouse.
  /// </para>
  /// <para>
  /// If disabled, the specified display will stop using constraints.
  /// </para>
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="onOff">Enables the window constraints if true, otherwise disables constraints if false.</param>
  public static void ApplyWindowConstraints(AllegroDisplay? display, bool onOff)
  {
    Interop.Core.AlApplyWindowConstraints(NativePointer.Get(display), (byte)(onOff ? 1 : 0));
  }

  /// <summary>
  /// Gets the flags of the display. In addition to the flags set for the display at creation time with
  /// <see cref="SetNewDisplayFlags"/> it can also have the <see cref="DisplayFlags.Minimized"/> flag set,
  /// indicating that the window is currently minimized. This flag is very platform-dependent as even a minimized
  /// application may still render a preview version so normally you should not care whether it is minimized or not.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The flags of the display.</returns>
  public static DisplayFlags GetDisplayFlags(AllegroDisplay? display)
  {
    return (DisplayFlags)Interop.Core.AlGetDisplayFlags(NativePointer.Get(display));
  }

  /// <summary>
  /// Enable or disable one of the display flags. The flags are the same as for <see cref="SetNewDisplayFlags"/>.
  /// The only flags that can be changed after creation are: <see cref="DisplayFlags.FullscreenWindow"/>,
  /// <see cref="DisplayFlags.Frameless"/>, and <see cref="DisplayFlags.Maximized"/>. You can use
  /// <see cref="GetDisplayFlags"/> to query whether the given display property actually changed.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="flag">The display flags.</param>
  /// <param name="onOff">Enabling or disabling the flag.</param>
  /// <returns>True if the driver supports toggling the specified flag, otherwise false.</returns>
  public static bool SetDisplayFlag(AllegroDisplay? display, DisplayFlags flag, bool onOff)
  {
    return Interop.Core.AlSetDisplayFlag(NativePointer.Get(display), (int)flag, (byte)(onOff ? 1 : 0)) == 1;
  }

  /// <summary>
  /// Return an extra display setting of the display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="option">The display option.</param>
  /// <returns>Returns an extra display setting of the display.</returns>
  public static int GetDisplayOption(AllegroDisplay? display, DisplayOption option)
  {
    return Interop.Core.AlGetDisplayOption(NativePointer.Get(display), (int)option);
  }

  /// <summary>
  /// Change an option that was previously set for a display. After displays are created, they take on the options set
  /// with <see cref="SetNewDisplayOption"/>. Calling <see cref="SetNewDisplayOption"/> subsequently only changes
  /// options for newly created displays, and doesn't touch the options of already created displays.
  /// <see cref="SetDisplayOption"/> allows changing some of these values. Not all display options can be changed or
  /// changing them will have no effect. Changing options other than those listed below is undefined.
  /// <list type="table">
  /// <item>
  /// <see cref="DisplayOption.SupportedOrientations"/> - This can be changed to allow new or restrict previously
  /// enabled orientations of the screen/device. See <see cref="SetNewDisplayOption"/> for more information on
  /// this option.
  /// </item>
  /// </list>
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="option">The display option.</param>
  /// <param name="value">The value to set the display option.</param>
  public static void SetDisplayOption(AllegroDisplay? display, DisplayOption option, int value)
  {
    Interop.Core.AlSetDisplayOption(NativePointer.Get(display), (int)option, value);
  }

  /// <summary>
  /// Gets the pixel format of the display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The pixel format of the display.</returns>
  public static PixelFormat GetDisplayFormat(AllegroDisplay? display)
  {
    return (PixelFormat)Interop.Core.AlGetDisplayFormat(NativePointer.Get(display));
  }

  /// <summary>
  /// Return the display orientation.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The display orientation.</returns>
  public static DisplayOrientation GetDisplayOrientation(AllegroDisplay? display)
  {
    return (DisplayOrientation)Interop.Core.AlGetDisplayOrientation(NativePointer.Get(display));
  }

  /// <summary>
  /// Gets the refresh rate of the display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>The refresh rate of the display.</returns>
  public static int GetDisplayRefreshRate(AllegroDisplay? display)
  {
    return Interop.Core.AlGetDisplayRefreshRate(NativePointer.Get(display));
  }

  /// <summary>
  /// Set the title on a display.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="title">The title on a display.</param>
  public static void SetWindowTitle(AllegroDisplay? display, string title)
  {
    using var nativeTitle = new CStringAnsi(title);
    Interop.Core.AlSetWindowTitle(NativePointer.Get(display), nativeTitle.Pointer);
  }

  /// <summary>
  /// Set the title that will be used when a new display is created.
  /// </summary>
  /// <param name="title">The title that will be used when a new display is created.</param>
  public static void SetNewWindowTitle(string title)
  {
    using var nativeTitle = new CStringAnsi(title);
    Interop.Core.AlSetNewWindowTitle(nativeTitle.Pointer);
  }

  /// <summary>
  /// Returns the title that will be used when a new display is created. This returns the value that
  /// <see cref="SetWindowTitle"/> was called with. If that function wasn't called yet, the value of
  /// <see cref="GetAppName"/> is returned as a default.
  /// </summary>
  /// <returns>The title that will be used when a new display is created.</returns>
  public static string? GetNewWindowTitle()
  {
    var pointer = Interop.Core.AlGetNewWindowTitle();
    return CStringAnsi.ToCSharpString(pointer);
  }

  /// <summary>
  /// Changes the icon associated with the display (window). Same as <see cref="SetDisplayIcons"/> with one icon.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="icon">The display icon bitmap.</param>
  public static void SetDisplayIcon(AllegroDisplay? display, AllegroBitmap? icon)
  {
    Interop.Core.AlSetDisplayIcon(NativePointer.Get(display), NativePointer.Get(icon));
  }

  /// <summary>
  /// <para>
  /// Changes the icons associated with the display (window). Multiple icons can be provided for use in different
  /// contexts, e.g. window frame, taskbar, alt-tab popup. The number of icons must be at least one.
  /// </para>
  /// <para>
  /// Note: If the underlying OS requires an icon of a size not provided then one of the bitmaps will be scaled up or
  /// down to the required size. The choice of bitmap is implementation dependent.
  /// </para>
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="numIcons">The count of icon bitmaps.</param>
  /// <param name="icons">The display icon bitmaps.</param>
  public static void SetDisplayIcons(AllegroDisplay? display, int numIcons, AllegroBitmap?[] icons)
  {
    var nativeIcons = new IntPtr[numIcons];
    for (var index = 0; index < numIcons; numIcons++)
      nativeIcons[index] = NativePointer.Get(icons[index]);
    Interop.Core.AlSetDisplayIcons(NativePointer.Get(display), numIcons, nativeIcons);
  }

  /// <summary>
  /// Call this in response to the <see cref="EventType.DisplayHaltDrawing"/> event.
  /// This is currently necessary for Android and iOS as you are not allowed to draw to your display while it is
  /// not being shown. If you do not call this function to let the operating system know that you have stopped
  /// drawing or if you call it to late the application likely will be considered misbehaving and get terminated.
  /// </summary>
  /// <param name="display">The display instance.</param>
  public static void AcknowledgeDrawingHalt(AllegroDisplay? display)
  {
    Interop.Core.AlAcknowledgeDrawingHalt(NativePointer.Get(display));
  }

  /// <summary>
  /// Call this in response to the <see cref="EventType.DisplayResumeDrawing"/> event.
  /// </summary>
  /// <param name="display">The display instance.</param>
  public static void AcknowledgeDrawingResume(AllegroDisplay? display)
  {
    Interop.Core.AlAcknowledgeDrawingResume(NativePointer.Get(display));
  }

  /// <summary>
  /// This function allows the user to stop the system screensaver from starting up if true is passed,
  /// or resets the system back to the default state (the state at program start) if false is passed. It
  /// returns true if the state was set successfully, otherwise false.
  /// </summary>
  /// <param name="onOff">True stops the system screensaver, false resets system to the default state.</param>
  /// <returns>True if the state was set successfully, otherwise false.</returns>
  public static bool InhibitScreensaver(bool onOff)
  {
    return Interop.Core.AlInhibitScreensaver((byte)(onOff ? 1 : 0)) == 1;
  }

  /// <summary>
  /// <para>
  /// This function returns the text contents of the clipboard if available.
  /// </para>
  /// <para>
  /// Beware that text on the clipboard on Windows may be in Windows format, that is, it may have carriage return
  /// newline combinations for the line endings instead of regular newlines for the line endings on Linux or OSX.
  /// </para>
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>Text contents of the clipboard if available.</returns>
  public static string? GetClipboardText(AllegroDisplay? display)
  {
    var pointer = Interop.Core.AlGetClipboardText(NativePointer.Get(display));
    return CStringAnsi.ToCSharpString(pointer);
  }

  /// <summary>
  /// This function pastes the text given as an argument to the clipboard.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <param name="text">Text to place into the clipboard.</param>
  /// <returns>True if successful, otherwise false.</returns>
  public static bool SetClipboardText(AllegroDisplay? display, string text)
  {
    using var nativeText = new CStringAnsi(text);
    return Interop.Core.AlSetClipboardText(NativePointer.Get(display), nativeText.Pointer) != 0;

  }

  /// <summary>
  /// This function returns true if and only if the clipboard has text available.
  /// </summary>
  /// <param name="display">The display instance.</param>
  /// <returns>true if and only if the clipboard has text available.</returns>
  public static bool ClipboardHasText(AllegroDisplay? display)
  {
    return Interop.Core.AlClipboardHasText(NativePointer.Get(display)) == 1;
  }
}
