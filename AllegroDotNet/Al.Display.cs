using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Create a display, or window, with the specified dimensions. The parameters of the display are determined by the last calls to
        /// <see cref="SetNewDisplayFlags(DisplayFlags)"/>, <see cref="SetNewDisplayOption(DisplayOption, int, Importance)"/>,
        /// <see cref="SetNewDisplayRefreshRate(int)"/>, <see cref="SetNewDisplayAdapter(int)"/>, and
        /// <see cref="SetNewWindowTitle(string)"/>. Default parameters are used if none are set explicitly.
        /// Creating a new display will automatically make it the active one, with the backbuffer selected for drawing.
        /// <para>
        /// Returns null on error.
        /// </para>
        /// <para>
        /// Each display that uses OpenGL as a backend has a distinct OpenGL rendering context associated with it. See
        /// <see cref="SetTargetBitmap(AllegroBitmap)"/> for the discussion about rendering contexts.
        /// </para>
        /// </summary>
        /// <param name="width">Width of the display in pixels.</param>
        /// <param name="height">Height of the display in pixels.</param>
        /// <returns>Created display, or null if it fails.</returns>
        public static AllegroDisplay CreateDisplay(int width, int height)
        {
            var display = new AllegroDisplay { NativeIntPtr = AllegroLibrary.AlCreateDisplay(width, height) };
            return display.NativeIntPtr == null ? null : display;
        }

        /// <summary>
        /// Destroy a display.
        /// <para>
        /// If the target bitmap of the calling thread is tied to the display, then it implies a call to
        /// <see cref="SetTargetBitmap(AllegroBitmap)"/> with null before the display is destroyed.
        /// </para>
        /// <para>
        /// That special case notwithstanding, you should make sure no threads are currently targeting a bitmap which
        /// is tied to the display before you destroy it.
        /// </para>
        /// </summary>
        /// <param name="display">The display to destroy.</param>
        public static void DestroyDisplay(AllegroDisplay display) =>
            AllegroLibrary.AlDestroyDisplay(display.NativeIntPtr);

        /// <summary>
        /// Get the display flags to be used when creating new displays on the calling thread.
        /// </summary>
        /// <returns>The display flags to be used when creating new displays on the calling thread.</returns>
        public static DisplayFlags GetNewDisplayFlags() =>
            (DisplayFlags)AllegroLibrary.AlGetNewDisplayFlags();

        /// <summary>
        /// Sets various flags to be used when creating new displays on the calling thread.
        /// </summary>
        /// <param name="flags">The various flags to be used when creating new displays on the calling thread.</param>
        public static void SetNewDisplayFlags(DisplayFlags flags) =>
            AllegroLibrary.AlSetNewDisplayFlags((int)flags);

        /// <summary>
        /// Retrieve an extra display setting which was previously set with
        /// <see cref="SetNewDisplayOption(DisplayOption, int, Importance)"/>.
        /// </summary>
        /// <param name="option">Display option to get.</param>
        /// <param name="importance">The importance of that display option.</param>
        /// <returns>The value of the display option.</returns>
        public static int GetNewDisplayOption(DisplayOption option, out Importance importance)
        {
            int nativeImportance = 0;
            int returnValue = AllegroLibrary.AlGetNewDisplayOption((int)option, ref nativeImportance);
            importance = (Importance)nativeImportance;
            return returnValue;
        }

        /// <summary>
        /// Set an extra display option, to be used when creating new displays on the calling thread. Display options differ from display flags,
        /// and specify some details of the context to be created within the window itself. These mainly have no effect on Allegro itself, but
        /// you may want to specify them, for example if you want to use multisampling.
        /// </summary>
        /// <param name="option">The display option to set.</param>
        /// <param name="value">The value to set the display option.</param>
        /// <param name="importance">The importance of the display option.</param>
        public static void SetNewDisplayOption(DisplayOption option, int value, Importance importance) =>
            AllegroLibrary.AlSetNewDisplayOption((int)option, value, (int)importance);

        /// <summary>
        /// This undoes any previous call to <see cref="SetNewDisplayOption(DisplayOption, int, Importance)"/> on the calling thread.
        /// </summary>
        public static void ResetNewDisplayOptions() =>
            AllegroLibrary.AlResetNewDisplayOptions();

        /// <summary>
        /// Get the position where new non-fullscreen displays created by the calling thread will be placed.
        /// </summary>
        /// <param name="x">The window X position.</param>
        /// <param name="y">The window Y position.</param>
        public static void GetNewWindowPosition(ref int x, ref int y) =>
            AllegroLibrary.AlGetNewWindowPosition(ref x, ref y);

        /// <summary>
        /// Sets where the top left pixel of the client area of newly created windows (non-fullscreen) will be on screen, for displays created
        /// by the calling thread. Negative values are allowed on some multi-head systems.
        /// <para>
        /// To reset to the default behaviour, pass(<see cref="int.MaxValue"/>, <see cref="int.MaxValue"/>).
        /// </para>
        /// </summary>
        /// <param name="x">The window X position.</param>
        /// <param name="y">The window Y position.</param>
        public static void SetNewWindowPosition(int x, int y) =>
            AllegroLibrary.AlSetNewWindowPosition(x, y);

        /// <summary>
        /// Gets the requested refresh rate to be used when creating new displays on the calling thread.
        /// </summary>
        /// <returns>The requested refresh rate to be used when creating new displays on the calling thread.</returns>
        public static int GetNewDisplayRefreshRate() =>
            AllegroLibrary.AlGetNewDisplayRefreshRate();

        /// <summary>
        /// Sets the refresh rate to use when creating new displays on the calling thread. If the refresh rate is not available,
        /// <see cref="CreateDisplay(int, int)"/> will fail. A list of modes with refresh rates can be found with
        /// <see cref="GetNumDisplayModes()"/> and <see cref="GetDisplayMode(int, AllegroDisplayMode)"/>.
        /// <para>
        /// The default setting is zero (don't care).
        /// </para>
        /// </summary>
        /// <param name="refreshRate">The monitor refresh rate.</param>
        public static void SetNewDisplayRefreshRate(int refreshRate) =>
            AllegroLibrary.AlSetNewDisplayRefreshRate(refreshRate);

        /// <summary>
        /// Retrieve the associated event source. See the documentation on events for a list of the events displays will generate.
        /// </summary>
        /// <param name="display">The display to retrieve the event source from.</param>
        /// <returns>The event source of the given display.</returns>
        public static AllegroEventSource GetDisplayEventSource(AllegroDisplay display)
        {
            var nativeEventSource = AllegroLibrary.AlGetDisplayEventSource(display.NativeIntPtr);
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        /// <summary>
        /// Return a special bitmap representing the back-buffer of the display.
        /// <para>
        /// Care should be taken when using the backbuffer bitmap (and its sub-bitmaps) as the source bitmap (e.g as the bitmap argument to
        /// <see cref="DrawBitmap"/>). Only untransformed operations are hardware accelerated. These consist of
        /// <see cref="DrawBitmap"/> and <see cref="DrawBitmapRegion"/> when the current transformation is the identity. If the transformation is not
        /// the identity, or some other drawing operation is used, the call will be routed through the memory bitmap routines, which are slow.
        /// If you need those operations to be accelerated, then first copy a region of the backbuffer into a temporary bitmap (via the 
        /// <see cref="DrawBitmap"/> and <see cref="DrawBitmapRegion"/>), and then use that temporary bitmap as the source bitmap.
        /// </para>
        /// </summary>
        /// <param name="display">The display to get the backbuffer from.</param>
        /// <returns>The bitmap of the display's backbuffer.</returns>
        public static AllegroBitmap GetBackbuffer(AllegroDisplay display)
        {
            var nativeBackbuffer = AllegroLibrary.AlGetBackbuffer(display.NativeIntPtr);
            return nativeBackbuffer == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBackbuffer };
        }

        /// <summary>
        /// Copies or updates the front and back buffers so that what has been drawn previously on the currently selected display becomes visible on
        /// screen. Pointers to the special back buffer bitmap remain valid and retain their semantics as the back buffer, although the contents may
        /// have changed.
        /// <para>
        /// <b>Note: If not using the ALLEGRO_SINGLE_BUFFER option, you typically want to redraw every pixel of the backbuffer bitmap to avoid
        /// uninitialized memory artifacts.</b>
        /// </para>
        /// <para>
        /// Several display options change how this function behaves:
        /// </para>
        /// <para>
        /// With <see cref="DisplayOption.SingleBuffer"/>, no flipping is done. You still have to call this function to display graphics, depending
        /// on how the used graphics system works.
        /// </para>
        /// <para>
        /// The <see cref="DisplayOption.SwapMethod"/> option may have additional information about what kind of operation is used internally to
        /// flip the front and back buffers.
        /// </para>
        /// <para>
        /// If <see cref="DisplayOption.Vsync"/> is 1, this function will force waiting for vsync. If <see cref="DisplayOption.Vsync"/> is 2, this
        /// function will not wait for vsync. With many drivers the vsync behavior is controlled by the user and not the application, and
        /// <see cref="DisplayOption.Vsync"/> will not be set; in this case <see cref="FlipDisplay"/> will wait for vsync depending on the settings
        /// set in the system's graphics preferences.
        /// </para>
        /// </summary>
        public static void FlipDisplay() =>
            AllegroLibrary.AlFlipDisplay();

        /// <summary>
        /// Does the same as al_flip_display, but tries to update only the specified region. With many drivers this is not possible, but for some
        /// it can improve performance. If this is not supported, this function falls back to the behavior of <see cref="FlipDisplay"/>. You can
        /// query the support for this function using <see cref="GetDisplayOption(AllegroDisplay, DisplayOption)"/>).
        /// </summary>
        /// <param name="x">The upper-left X position of the region.</param>
        /// <param name="y">The upper-left Y position of the region.</param>
        /// <param name="width">The width of the region, from X.</param>
        /// <param name="height">The height of the region, from Y.</param>
        public static void UpdateDisplayRegion(int x, int y, int width, int height) =>
            AllegroLibrary.AlUpdateDisplayRegion(x, y, width, height);

        /// <summary>
        /// Wait for the beginning of a vertical retrace. Some driver/card/monitor combinations may not be capable of this.
        /// <para>
        /// Note how <see cref="FlipDisplay"/> usually already waits for the vertical retrace, so unless you are doing something special, there is no
        /// reason to call this function.
        /// </para>
        /// </summary>
        /// <returns>Returns false if not possible, true if successful.</returns>
        public static bool WaitForVSync() =>
            AllegroLibrary.AlWaitForVsync();

        /// <summary>
        /// Gets the width of the display. This is like SCREEN_W in Allegro 4.x.
        /// </summary>
        /// <param name="display">The display to get the width of.</param>
        /// <returns>The width of the display.</returns>
        public static int GetDisplayWidth(AllegroDisplay display) =>
            AllegroLibrary.AlGetDisplayWidth(display.NativeIntPtr);

        /// <summary>
        /// Gets the height of the display. This is like SCREEN_H in Allegro 4.x.
        /// </summary>
        /// <param name="display">The display to get the height of.</param>
        /// <returns>The height of the display.</returns>
        public static int GetDisplayHeight(AllegroDisplay display) =>
            AllegroLibrary.AlGetDisplayHeight(display.NativeIntPtr);

        /// <summary>
        /// Resize the display. Returns true on success, or false on error. This works on both fullscreen and windowed displays, regardless of the
        /// <see cref="DisplayFlags.Resizable"/> flag.
        /// <para>
        /// Adjusts the clipping rectangle to the full size of the backbuffer.
        /// </para>
        /// </summary>
        /// <param name="display">The display to resize.</param>
        /// <param name="width">The new width for the display.</param>
        /// <param name="height">The new height for the display.</param>
        /// <returns>True on success, false otherwise.</returns>
        public static bool ResizeDisplay(AllegroDisplay display, int width, int height) =>
            AllegroLibrary.AlResizeDisplay(display.NativeIntPtr, width, height);

        /// <summary>
        /// When the user receives a resize event from a resizable display, if they wish the display to be resized they must call this function to
        /// let the graphics driver know that it can now resize the display. Returns true on success.
        /// <para>
        /// Adjusts the clipping rectangle to the full size of the backbuffer. This also resets the backbuffers projection transform to default
        /// orthographic transform (see <see cref="UseProjectionTransform"/>).
        /// </para>
        /// <para>
        /// Note that a resize event may be outdated by the time you acknowledge it; there could be further resize events generated in the meantime.
        /// </para>
        /// </summary>
        /// <param name="display">The display to acknowledge a resize event.</param>
        /// <returns>True on success, false otherwise.</returns>
        public static bool AcknowledgeResize(AllegroDisplay display) =>
            AllegroLibrary.AlAcknowledgeResize(display.NativeIntPtr);

        /// <summary>
        /// Gets the position of a non-fullscreen display.
        /// </summary>
        /// <param name="display">The display to get the position of.</param>
        /// <param name="x">The display X position.</param>
        /// <param name="y">The display Y position.</param>
        public static void GetWindowPosition(AllegroDisplay display, ref int x, ref int y) =>
            AllegroLibrary.AlGetWindowPosition(display.NativeIntPtr, ref x, ref y);

        /// <summary>
        /// Sets the position on screen of a non-fullscreen display.
        /// </summary>
        /// <param name="display">The display to set the position of.</param>
        /// <param name="x">The display X position.</param>
        /// <param name="y">The display Y position.</param>
        public static void SetWindowPosition(AllegroDisplay display, int x, int y) =>
            AllegroLibrary.AlSetWindowPosition(display.NativeIntPtr, x, y);

        /// <summary>
        /// Gets the constraints for a non-fullscreen resizable display.
        /// </summary>
        /// <param name="display">The display to get the constrains of.</param>
        /// <param name="minW">The minimum width constraint.</param>
        /// <param name="minH">The minimum height constraint.</param>
        /// <param name="maxW">The maximum width constraint.</param>
        /// <param name="maxH">The maximum height constraint.</param>
        /// <returns>True on success, false otherwise.</returns>
        public static bool GetWindowConstraints(AllegroDisplay display, ref int minW, ref int minH, ref int maxW, ref int maxH) =>
            AllegroLibrary.AlGetWindowConstraints(display.NativeIntPtr, ref minW, ref minH, ref maxW, ref maxH);

        /// <summary>
        /// Constrains a non-fullscreen resizable display. The constraints are a hint only, and are not necessarily respected by
        /// the window environment. A value of 0 for any of the parameters indicates no constraint for that parameter.
        /// <para>
        /// The constraints will be applied to a display only after the <see cref="ApplyWindowConstraints"/> function call.
        /// </para>
        /// </summary>
        /// <param name="display">The display to set the constraints of.</param>
        /// <param name="minW">The minimum width constraint.</param>
        /// <param name="minH">The minimum height constraint.</param>
        /// <param name="maxW">The maximum width constraint.</param>
        /// <param name="maxH">The maximum height constraint.</param>
        /// <returns></returns>
        public static bool SetWindowConstraints(AllegroDisplay display, int minW, int minH, int maxW, int maxH) =>
            AllegroLibrary.AlSetWindowConstraints(display.NativeIntPtr, minW, minH, maxW, maxH);

        /// <summary>
        /// Enable or disable previously set constraints by al_set_window_constraints function.
        /// <para>
        /// If enabled, the specified display will be automatically resized to new sizes to conform constraints in next cases:
        /// </para>
        /// <list type="bullet">
        /// <item>The specified display is resizable, not maximized and is not in fullscreen mode.</item>
        /// <item>If the appropriate current display size (width or height) is less than the value of constraint. Applied to minimum constraints.</item>
        /// <item>If the appropriate current display size (width or height) is greater than the value of constraint.Applied to maximum constraints.</item>
        /// </list>
        /// <para>
        /// Constrains are not applied when a display is toggle from windowed to maximized or fullscreen modes. When a display is toggle from maximized/fullscreen to windowed mode, then the display may be resized as described above. The later case is also possible when a user drags the maximized display via mouse.
        /// </para>
        /// <para>
        /// If disabled, the specified display will stop using constraints.
        /// </para>
        /// </summary>
        /// <param name="display">The display to apply window constraints to.</param>
        /// <param name="onOff">True enables constraints, false disables constraints.</param>
        public static void ApplyWindowConstraints(AllegroDisplay display, bool onOff) =>
            AllegroLibrary.AlApplyWindowConstraints(display.NativeIntPtr, onOff);

        /// <summary>
        /// Gets the flags of the display.
        /// <para>
        /// In addition to the flags set for the display at creation time with <see cref="SetNewDisplayFlags(DisplayFlags)"/>
        /// it can also have the <see cref="DisplayFlags.Minimized"/> flag set, indicating that the window is currently minimized.
        /// This flag is very platform-dependent as even a minimized application may still render a preview version so normally
        /// you should not care whether it is minimized or not.
        /// </para>
        /// </summary>
        /// <param name="display">The display to get flags from.</param>
        /// <returns>The flags of the display.</returns>
        public static DisplayFlags GetDisplayFlags(AllegroDisplay display) =>
            (DisplayFlags)AllegroLibrary.AlGetDisplayFlags(display.NativeIntPtr);

        /// <summary>
        /// Enable or disable one of the display flags. The flags are the same as for 
        /// <see cref="SetNewDisplayFlags(DisplayFlags)"/>. The only flags that can be changed after creation are:
        /// <list type="bullet">
        /// <item><see cref="DisplayFlags.FullScreenWindow"/></item>
        /// <item><see cref="DisplayFlags.Frameless"/></item>
        /// <item><see cref="DisplayFlags.Maximized"/></item>
        /// </list>
        /// <para>
        /// Returns true if the driver supports toggling the specified flag else false. You can use
        /// <see cref="GetDisplayFlags(AllegroDisplay)"/> to query whether the given display property actually changed.
        /// </para>
        /// </summary>
        /// <param name="display">The display to set the flag.</param>
        /// <param name="flag">The flag to set.</param>
        /// <param name="onOff">True to enable the flag, false to disable the flag.</param>
        /// <returns>True if the driver supports toggling the specified flag, false otherwise.</returns>
        public static bool SetDisplayFlag(AllegroDisplay display, DisplayFlags flag, bool onOff) =>
            AllegroLibrary.AlSetDisplayFlag(display.NativeIntPtr, (int)flag, onOff);

        /// <summary>
        /// Return an extra display setting of the display.
        /// </summary>
        /// <param name="display">The display to get the display option from.</param>
        /// <param name="option">The option to get the setting of.</param>
        /// <returns>An extra display setting of the display.</returns>
        public static int GetDisplayOption(AllegroDisplay display, DisplayOption option) =>
            AllegroLibrary.AlGetDisplayOption(display.NativeIntPtr, (int)option);

        /// <summary>
        /// Change an option that was previously set for a display. After displays are created, they take on the
        /// options set with <see cref="SetNewDisplayOption(DisplayOption, int, Importance)"/> . Calling
        /// <see cref="SetNewDisplayOption(DisplayOption, int, Importance)"/> subsequently only changes options for
        /// newly created displays, and doesn't touch the options of already created displays.
        /// <see cref="SetDisplayOption(AllegroDisplay, DisplayOption, int)"/> allows changing some of these values.
        /// Not all display options can be changed or changing them will have no effect. Changing options other than
        /// those listed below is undefined.
        /// <para>
        /// <see cref="DisplayOption.SupportedOrientations"/> - This can be changed to allow new or restrict previously
        /// enabled orientations of the screen/device. See
        /// <see cref="SetNewDisplayOption(DisplayOption, int, Importance)"/> for more information on this option.
        /// </para>
        /// </summary>
        /// <param name="display">The display to set the option on.</param>
        /// <param name="option">The option to set.</param>
        /// <param name="value">The value of the option.</param>
        public static void SetDisplayOption(AllegroDisplay display, DisplayOption option, int value) =>
            AllegroLibrary.AlSetDisplayOption(display.NativeIntPtr, (int)option, value);

        /// <summary>
        /// Gets the pixel format of the display.
        /// </summary>
        /// <param name="display">The display to get the pixel format from.</param>
        /// <returns>The pixel format of the display.</returns>
        public static PixelFormat GetDisplayFormat(AllegroDisplay display) =>
            (PixelFormat)AllegroLibrary.AlGetDisplayFormat(display.NativeIntPtr);

        /// <summary>
        /// Get the display orientation.
        /// </summary>
        /// <param name="display">The display to get the orientation from.</param>
        /// <returns>The display orientation.</returns>
        public static DisplayOrientation GetDisplayOrientation(AllegroDisplay display) =>
            (DisplayOrientation)AllegroLibrary.AlGetDisplayOrientation(display.NativeIntPtr);

        /// <summary>
        /// Gets the refresh rate of the display.
        /// </summary>
        /// <param name="display">The display to get the refresh rate from.</param>
        /// <returns>The refresh rate of the display.</returns>
        public static int GetDisplayRefreshRate(AllegroDisplay display) =>
            AllegroLibrary.AlGetDisplayRefreshRate(display.NativeIntPtr);

        /// <summary>
        /// Set the title on a display.
        /// </summary>
        /// <param name="display">The display to set the title of.</param>
        /// <param name="title">The title to set the display of.</param>
        public static void SetWindowTitle(AllegroDisplay display, string title) =>
            AllegroLibrary.AlSetWindowTitle(display.NativeIntPtr, title);

        /// <summary>
        /// Set the title that will be used when a new display is created. Allegro uses a static buffer of
        /// <see cref="AlConstants.AllegroNewWindowTitleMaxSize"/> to store this, so the length of the title you
        /// set must be less than this.
        /// </summary>
        /// <param name="title">The title for future display(s).</param>
        public static void SetNewWindowTitle(string title) =>
            AllegroLibrary.AlSetNewWindowTitle(title);

        /// <summary>
        /// Returns the title that will be used when a new display is created. This returns the value that
        /// <see cref="SetWindowTitle(AllegroDisplay, string)"/> was called with. If that function wasn't called yet,
        /// the value of <see cref="GetAppName"/> is returned as a default. The current implementation returns a
        /// pointer to a static buffer of which you should make a copy if you want to modify it.
        /// </summary>
        /// <returns>The title that will be used when a new display is created.</returns>
        public static string GetNewWindowTitle()
        {
            var nativeString = AllegroLibrary.AlGetNewWindowTitle();
            return nativeString == IntPtr.Zero ? null : Marshal.PtrToStringAnsi(nativeString);
        }

        /// <summary>
        /// Changes the icon associated with the display (window). Same as <see cref="SetDisplayIcons"/> with one
        /// icon.
        /// </summary>
        /// <param name="display">The display to change the icon of.</param>
        /// <param name="icon">The icon as a <see cref="AllegroBitmap"/>.</param>
        public static void SetDisplayIcon(AllegroDisplay display, AllegroBitmap icon) =>
            AllegroLibrary.AlSetDisplayIcon(display.NativeIntPtr, icon.NativeIntPtr);

        /// <summary>
        /// Changes the icons associated with the display (window). Multiple icons can be provided for use in
        /// different contexts, e.g. window frame, taskbar, alt-tab popup. The number of icons must be at least one.
        /// </summary>
        /// <param name="display">The display to change the icons of.</param>
        /// <param name="numIcons">The number of items in the icons collection.</param>
        /// <param name="icons">Collection of icons as bitmaps.</param>
        public static void SetDisplayIcons(AllegroDisplay display, int numIcons, IEnumerable<AllegroBitmap> icons)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Call this in response to the <see cref="EventType.DisplayHaltDrawing"/> event. This is currently necessary
        /// for Android and iOS as you are not allowed to draw to your display while it is not being shown.
        /// If you do not call this function to let the operating system know that you have stopped drawing or if
        /// you call it to late the application likely will be considered misbehaving and get terminated.
        /// </summary>
        /// <param name="display">The display to acknowledge the drawing halt event from.</param>
        public static void AcknowledgeDrawingHalt(AllegroDisplay display) =>
            AllegroLibrary.AlAcknowledgeDrawingHalt(display.NativeIntPtr);

        /// <summary>
        /// Call this in response to the <see cref="EventType.DisplayResumeDrawing"/> event.
        /// </summary>
        /// <param name="display">The display to acknowledge the drawing resume event.</param>
        public static void AcknowledgeDrawingResume(AllegroDisplay display) =>
            AllegroLibrary.AlAcknowledgeDrawingResume(display.NativeIntPtr);

        /// <summary>
        /// This function allows the user to stop the system screensaver from starting up if true is passed, or
        /// resets the system back to the default state (the state at program start) if false is passed. It returns
        /// true if the state was set successfully, otherwise false.
        /// </summary>
        /// <param name="inhibit">True to inhibit the screensaver from starting, otherwise false.</param>
        /// <returns>True if the state was set successfully, otherwise false.</returns>
        public static bool InhibitScreensaver(bool inhibit) =>
            AllegroLibrary.AlInhibitScreensaver(inhibit);

        /// <summary>
        /// This function returns a pointer to a string, allocated with al_malloc with the text contents of the
        /// clipboard if available. If no text is available on the clipboard then this function returns NULL.
        /// <para>
        /// Beware that text on the clipboard on Windows may be in Windows format, that is, it may have carriage
        /// return newline combinations for the line endings instead of regular newlines for the line endings on
        /// Linux or OSX.
        /// </para>
        /// </summary>
        /// <param name="display">Display to get the clipboard text from.</param>
        /// <returns>The clipboard text of the given display.</returns>
        public static string GetClipboardText(AllegroDisplay display)
        {
            var clipboardPtr = AllegroLibrary.AlGetClipboardText(display.NativeIntPtr);
            var returnString = Marshal.PtrToStringAnsi(clipboardPtr);
            AllegroLibrary.AlFreeWithContext(clipboardPtr, 0, string.Empty, string.Empty);
            return returnString;
        }

        /// <summary>
        /// This function pastes the text given as an argument to the clipboard.
        /// </summary>
        /// <param name="display">The display to set the clipboard text of.</param>
        /// <param name="text">The text to paste into the clipboard.</param>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool SetClipboardText(AllegroDisplay display, string text) =>
            AllegroLibrary.AlSetClipboardText(display.NativeIntPtr, text);

        /// <summary>
        /// This function returns true if and only if the clipboard has text available.
        /// </summary>
        /// <param name="display">The display to access the clipborad of.</param>
        /// <returns>True if the clipboard has text available.</returns>
        public static bool ClipboardHasText(AllegroDisplay display) =>
            AllegroLibrary.AlClipboardHasText(display.NativeIntPtr);
    }
}
