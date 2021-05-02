using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Models;
using AllegroDotNet.Enums;
using AllegroDotNet.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Install a mouse driver.
        /// </summary>
        /// <returns>
        /// True if successful. If a driver was already installed, nothing happens and true is returned.
        /// </returns>
        public static bool InstallMouse()
            => al_install_mouse();

        /// <summary>
        /// Returns true if al_install_mouse was called successfully.
        /// </summary>
        /// <returns>True if al_install_mouse was called successfully.</returns>
        public static bool IsMouseInstalled()
            => al_is_mouse_installed();

        /// <summary>
        /// Uninstalls the active mouse driver, if any. This will automatically unregister the mouse event source
        /// with any event queues. This function is automatically called when Allegro is shut down.
        /// </summary>
        public static void UninstallMouse()
            => al_uninstall_mouse();

        /// <summary>
        /// Return the number of axes on the mouse. The first axis is 0.
        /// </summary>
        /// <returns>The number of axes on the mouse. The first axis is 0.</returns>
        public static uint GetMouseNumAxes()
            => al_get_mouse_num_axes();

        /// <summary>
        /// Return the number of buttons on the mouse. The first button is 1.
        /// </summary>
        /// <returns>The number of buttons on the mouse. The first button is 1.</returns>
        public static uint GetMouseNumButtons()
            => al_get_mouse_num_buttons();

        /// <summary>
        /// Save the state of the mouse specified at the time the function is called into the given structure.
        /// </summary>
        /// <param name="retState">The mouse state to be populated.</param>
        public static void GetMouseState(AllegroMouseState retState)
            => al_get_mouse_state(ref retState.Native);

        /// <summary>
        /// Extract the mouse axis value from the saved state. The axes are numbered from 0, in this order: x-axis,
        /// y-axis, z-axis, w-axis.
        /// </summary>
        /// <param name="state">The state of the mouse.</param>
        /// <param name="axis">The axis to get the state of.</param>
        /// <returns>The value of the mouse axis.</returns>
        public static int GetMouseStateAxis(AllegroMouseState state, int axis)
            => al_get_mouse_state_axis(ref state.Native, axis);

        /// <summary>
        /// Return true if the mouse button specified was held down in the state specified. Unlike most things, the
        /// first mouse button is numbered 1.
        /// </summary>
        /// <param name="state">The mouse state.</param>
        /// <param name="button">The button, starting from 1.</param>
        /// <returns>True if the mouse button is down, otherwise false.</returns>
        public static bool MouseButtonDown(AllegroMouseState state, int button)
            => al_mouse_button_down(ref state.Native, button);

        /// <summary>
        /// Try to position the mouse at the given coordinates on the given display. The mouse movement resulting from
        /// a successful move will generate an ALLEGRO_EVENT_MOUSE_WARPED event.
        /// </summary>
        /// <param name="display">The display to position the mouse within.</param>
        /// <param name="x">The X postiion.</param>
        /// <param name="y">The Y position.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetMouseXY(AllegroDisplay display, int x, int y)
            => al_set_mouse_xy(display.NativeIntPtr, x, y);

        /// <summary>
        /// Set the mouse wheel position to the given value.
        /// </summary>
        /// <param name="z">The Z position.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetMouseZ(int z)
            => al_set_mouse_z(z);

        /// <summary>
        /// Set the second mouse wheel position to the given value.
        /// </summary>
        /// <param name="w">The W position.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetMouseW(int w)
            => al_set_mouse_w(w);

        /// <summary>
        /// Set the given mouse axis to the given value. The axis number must not be 0 or 1, which are the X and
        /// Y axes. Use al_set_mouse_xy for that.
        /// </summary>
        /// <param name="which">
        /// The mouse axis, which cannot be 0 or 1 (use <see cref="SetMouseXY(AllegroDisplay, int, int)"/> for that).
        /// </param>
        /// <param name="value">The value of the axis.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetMouseAxis(int which, int value)
            => al_set_mouse_axis(which, value);

        /// <summary>
        /// Retrieve the mouse event source. All mouse events are generated by this event source.
        /// </summary>
        /// <returns>Returns null if the mouse subsystem was not installed.</returns>
        public static AllegroEventSource GetMouseEventSource()
        {
            var nativeEventSource = al_get_mouse_event_source();
            return nativeEventSource == IntPtr.Zero ? null : new AllegroEventSource { NativeIntPtr = nativeEventSource };
        }

        /// <summary>
        /// Sets the precision of the mouse wheel (the z and w coordinates). This precision manifests itself as a
        /// multiplier on the dz and dw fields in mouse events. It also affects the z and w fields of events and
        /// ALLEGRO_MOUSE_STATE, but not in a simple way if you alter the precision often, so it is suggested to
        /// reset those axes to 0 when you change precision. Setting this to a high value allows you to detect small
        /// changes in those two axes for some high precision mice. A flexible way of using this precision is to
        /// set it to a high value (120 is likely sufficient for most, if not all, mice) and use a floating point
        /// dz and dw.
        /// <para>
        /// Precision is set to 1 by default. It is impossible to set it to a lower precision than that.
        /// </para>
        /// </summary>
        /// <param name="precision">The precision of the mouse wheel.</param>
        public static void SetMouseWheelPrecision(int precision)
            => al_set_mouse_wheel_precision(precision);

        /// <summary>
        /// Gets the precision of the mouse wheel (the z and w coordinates).
        /// </summary>
        /// <returns>The precision of the mouse wheel (Z and W coordinates).</returns>
        public static int GetMouseWheelPrecision()
            => al_get_mouse_wheel_precision();

        /// <summary>
        /// Create a mouse cursor from the bitmap provided. x_focus and y_focus describe the bit of the cursor
        /// that will represent the actual mouse position.
        /// </summary>
        /// <param name="bitmap">The bitmap to make a mouse cursor from.</param>
        /// <param name="xFocus">The X focus point of the bitmap.</param>
        /// <param name="yFocus">The Y focus point of the bitmap.</param>
        /// <returns>Returns a pointer to the cursor on success, or NULL on failure.</returns>
        public static AllegroMouseCursor CreateMouseCursor(AllegroBitmap bitmap, int xFocus, int yFocus)
        {
            var nativeMouseCursor = al_create_mouse_cursor(bitmap.NativeIntPtr, xFocus, yFocus);
            return nativeMouseCursor == IntPtr.Zero ? null : new AllegroMouseCursor { NativeIntPtr = nativeMouseCursor };
        }

        /// <summary>
        /// Free the memory used by the given cursor. Has no effect if cursor is NULL.
        /// </summary>
        /// <param name="mouseCursor">The mouse cursor to destroy.</param>
        public static void DestroyMouseCursor(AllegroMouseCursor mouseCursor)
            => al_destroy_mouse_cursor(mouseCursor.NativeIntPtr);

        /// <summary>
        /// Set the given mouse cursor to be the current mouse cursor for the given display. If the cursor
        /// is currently ‘shown’ (as opposed to ‘hidden’) the change is immediately visible.
        /// </summary>
        /// <param name="display">The display to set the mouse cursor for.</param>
        /// <param name="cursor">The cursor to set.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetMouseCursor(AllegroDisplay display, AllegroMouseCursor cursor)
            => al_set_mouse_cursor(display.NativeIntPtr, cursor.NativeIntPtr);

        /// <summary>
        /// Set the given system mouse cursor to be the current mouse cursor for the given display. If the cursor is
        /// currently ‘shown’ (as opposed to ‘hidden’) the change is immediately visible. If the cursor doesn’t exist
        /// on the current platform another cursor will be silently be substituted.
        /// </summary>
        /// <param name="display">The display to set the mouse cursor for.</param>
        /// <param name="cursorId">The cursor ID to change.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool SetSystemMouseCursor(AllegroDisplay display, SystemMouseCursor cursorId)
            => al_set_system_mouse_cursor(display.NativeIntPtr, (int)cursorId);

        /// <summary>
        /// On platforms where this information is available, this function returns the global location of the mouse
        /// cursor, relative to the desktop. You should not normally use this function, as the information is not
        /// useful except for special scenarios as moving a window.
        /// </summary>
        /// <param name="retX">The X position to populate.</param>
        /// <param name="retY">The Y position to populate.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public static bool GetMouseCursorPosition(ref int retX, ref int retY)
            => al_get_mouse_cursor_position(ref retX, ref retY);

        /// <summary>
        /// Hide the mouse cursor in the given display. This has no effect on what the current mouse cursor looks
        /// like; it just makes it disappear.
        /// </summary>
        /// <param name="display">The display to hide the mouse cursor from.</param>
        /// <returns>Returns true on success (or if the cursor already was hidden), false otherwise.</returns>
        public static bool HideMouseCursor(AllegroDisplay display)
            => al_hide_mouse_cursor(display.NativeIntPtr);

        /// <summary>
        /// Make a mouse cursor visible in the given display.
        /// </summary>
        /// <param name="display">The display to show the cursor on.</param>
        /// <returns>
        /// Returns true if a mouse cursor is shown as a result of the call (or one already was visible), false
        /// otherwise.
        /// </returns>
        public static bool ShowMouseCursor(AllegroDisplay display)
            => al_show_mouse_cursor(display.NativeIntPtr);

        /// <summary>
        /// Confine the mouse cursor to the given display. The mouse cursor can only be confined to one display at
        /// a time. Returns true if successful, otherwise returns false. Do not assume that the cursor will remain
        /// confined until you call al_ungrab_mouse. It may lose the confined status at any time for other reasons.
        /// </summary>
        /// <param name="display">The display to grab the mouse from.</param>
        /// <returns>True if successful, otherwise returns false</returns>
        public static bool GrabMouse(AllegroDisplay display)
            => al_grab_mouse(display.NativeIntPtr);

        /// <summary>
        /// Stop confining the mouse cursor to any display belonging to the program.
        /// </summary>
        /// <returns>True if successful, otherwise false.</returns>
        public static bool UngrabMouse()
            => al_ungrab_mouse();
        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_install_mouse();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_mouse_installed();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_uninstall_mouse();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_mouse_num_axes();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_mouse_num_buttons();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_get_mouse_state(ref NativeMouseState retState);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_mouse_state_axis(ref NativeMouseState state, int axis);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_mouse_button_down(ref NativeMouseState state, int button);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mouse_xy(IntPtr display, int x, int y);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mouse_z(int z);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mouse_w(int w);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mouse_axis(int which, int value);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_mouse_event_source();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_mouse_wheel_precision(int precision);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_mouse_wheel_precision();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_mouse_cursor(IntPtr bmp, int xFocus, int yFocus);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_mouse_cursor(IntPtr cursor);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_mouse_cursor(IntPtr display, IntPtr cursor);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_set_system_mouse_cursor(IntPtr display, int cursorId);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_mouse_cursor_position(ref int retX, ref int retY);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_hide_mouse_cursor(IntPtr display);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_show_mouse_cursor(IntPtr display);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_grab_mouse(IntPtr display);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_ungrab_mouse();
        #endregion
    }
}
