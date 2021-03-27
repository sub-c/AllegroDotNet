using System;
using System.Runtime.InteropServices;
using AllegroDotNet.Models;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library Core methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Create a display, or window, with the specified dimensions. The parameters of the display are determined by the last calls to
        /// <see cref="SetNewDisplayFlags()"/>, <see cref="SetNewDisplayOption()"/>, <see cref="SetNewDisplayRefreshRate()"/>,
        /// <see cref="SetNewDisplayAdapter()"/>, and <see cref="SetNewWindowTitle()"/>. Default parameters are used if none are set explicitly.
        /// Creating a new display will automatically make it the active one, with the backbuffer selected for drawing.
        /// <para>
        /// Returns null on error.
        /// </para>
        /// <para>
        /// Each display that uses OpenGL as a backend has a distinct OpenGL rendering context associated with it. See
        /// <see cref="SetTargetBitmap()"/> for the discussion about rendering contexts.
        /// </para>
        /// </summary>
        /// <param name="width">Width of the display in pixels.</param>
        /// <param name="height">Height of the display in pixels.</param>
        /// <returns>Created display, or null if it fails.</returns>
        public static AllegroDisplay CreateDisplay(int width, int height)
        {
            var display = new AllegroDisplay { NativeIntPtr = al_create_display(width, height) };
            return display.NativeIntPtr == null ? null : display;
        }

        /// <summary>
        /// Destroy a display.
        /// <para>
        /// If the target bitmap of the calling thread is tied to the display, then it implies a call to <see cref="SetTargetBitmap()"/> with null
        /// before the display is destroyed.
        /// </para>
        /// <para>
        /// That special case notwithstanding, you should make sure no threads are currently targeting a bitmap which is tied to the display
        /// before you destroy it.
        /// </para>
        /// </summary>
        /// <param name="display">The display to destroy.</param>
        public static void DestroyDisplay(AllegroDisplay display)
            => al_destroy_display(display.NativeIntPtr);

        #region P/Invokes
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_create_display(int w, int h);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_destroy_display(IntPtr display);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_new_display_flags();
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_new_display_flags(int flags);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_new_display_option(int option, ref int importance);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_new_display_option(int option, int value, int importance);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_reset_new_display_options();
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_get_new_window_position(ref int x, ref int y);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_new_window_position(int x, int y);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_new_display_refresh_rate();
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_new_display_refresh_rate(int refresh_rate);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_display_event_source(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_backbuffer(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_flip_display();
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_update_display_region(int x, int y, int width, int height);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_wait_for_vsync();
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_display_width(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_display_height(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_resize_display(IntPtr display, int width, int height);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_acknowledge_resize(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_get_window_position(IntPtr display, ref int x, ref int y);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_window_position(IntPtr display, int x, int y);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_get_window_constraints(IntPtr display, ref int min_w, ref int min_h, ref int max_w, ref int max_h);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_set_window_constraints(IntPtr display, int min_w, int min_h, int max_w, int max_h);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_apply_window_constraints(IntPtr display, bool onOff);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_display_flags(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_set_display_flag(IntPtr display, int flag, bool OnOff);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_display_option(IntPtr display, int options);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_display_option(IntPtr display, int option, int value);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_display_format(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_display_orientation(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_display_refresh_rate(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename, CharSet = CharSet.Ansi)]
        private static extern void al_set_window_title(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string title);
        
        [DllImport(Constants.AllegroCoreDllFilename, CharSet = CharSet.Ansi)]
        private static extern void al_set_new_window_title([MarshalAs(UnmanagedType.LPStr)] string title);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_new_window_title();
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_display_icon(IntPtr display, IntPtr icon);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_display_icons(IntPtr display, int num_icons, IntPtr bitmaps);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_acknowledge_drawing_halt(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_acknowledge_drawing_resume(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_inhibit_screensaver(bool inhibit);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_clipboard_text(IntPtr display);
        
        [DllImport(Constants.AllegroCoreDllFilename, CharSet = CharSet.Ansi)]
        private static extern bool al_set_clipboard_text(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string text);
        
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_clipboard_has_text(IntPtr display);
        #endregion
    }
}
