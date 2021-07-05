using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Native.Libraries
{
    internal static class AllegroLibrary
    {
        private static readonly IntPtr _nativeAllegroLibrary = NativeLibrary.LoadAllegroLibrary();

        #region Audio codecs addon
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_init_acodec_addon();
        public static al_init_acodec_addon AlInitAcodecAddon =
            NativeLibrary.LoadNativeFunction<al_init_acodec_addon>(_nativeAllegroLibrary, "al_init_acodec_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_acodec_addon_initialized();
        public static al_is_acodec_addon_initialized AlIsAcodecAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_acodec_addon_initialized>(_nativeAllegroLibrary, "al_is_acodec_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_acodec_version();
        public static al_get_allegro_acodec_version AlGetAllegroAcodecVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_acodec_version>(_nativeAllegroLibrary, "al_get_allegro_acodec_version");
        #endregion

        #region Displays
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_display(int w, int h);
        public static al_create_display AlCreateDisplay =
            NativeLibrary.LoadNativeFunction<al_create_display>(_nativeAllegroLibrary, "al_create_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_display(IntPtr display);
        public static al_destroy_display AlDestroyDisplay =
            NativeLibrary.LoadNativeFunction<al_destroy_display>(_nativeAllegroLibrary, "al_destroy_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_display_flags();
        public static al_get_new_display_flags AlGetNewDisplayFlags =
            NativeLibrary.LoadNativeFunction<al_get_new_display_flags>(_nativeAllegroLibrary, "al_get_new_display_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_display_flags(int flags);
        public static al_set_new_display_flags AlSetNewDisplayFlags =
            NativeLibrary.LoadNativeFunction<al_set_new_display_flags>(_nativeAllegroLibrary, "al_set_new_display_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_display_option(int option, ref int importance);
        public static al_get_new_display_option AlGetNewDisplayOption =
            NativeLibrary.LoadNativeFunction<al_get_new_display_option>(_nativeAllegroLibrary, "al_get_new_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_display_option(int option, int value, int importance);
        public static al_set_new_display_option AlSetNewDisplayOption =
            NativeLibrary.LoadNativeFunction<al_set_new_display_option>(_nativeAllegroLibrary, "al_set_new_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_reset_new_display_options();
        public static al_reset_new_display_options AlResetNewDisplayOptions =
            NativeLibrary.LoadNativeFunction<al_reset_new_display_options>(_nativeAllegroLibrary, "al_reset_new_display_options");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_new_window_position(ref int x, ref int y);
        public static al_get_new_window_position AlGetNewWindowPosition =
            NativeLibrary.LoadNativeFunction<al_get_new_window_position>(_nativeAllegroLibrary, "al_get_new_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_window_position(int x, int y);
        public static al_set_new_window_position AlSetNewWindowPosition =
            NativeLibrary.LoadNativeFunction<al_set_new_window_position>(_nativeAllegroLibrary, "al_set_new_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_display_refresh_rate();
        public static al_get_new_display_refresh_rate AlGetNewDisplayRefreshRate =
            NativeLibrary.LoadNativeFunction<al_get_new_display_refresh_rate>(_nativeAllegroLibrary, "al_get_new_display_refresh_rate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_display_refresh_rate(int refresh_rate);
        public static al_set_new_display_refresh_rate AlSetNewDisplayRefreshRate =
            NativeLibrary.LoadNativeFunction<al_set_new_display_refresh_rate>(_nativeAllegroLibrary, "al_set_new_display_refresh_rate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_display_event_source(IntPtr display);
        public static al_get_display_event_source AlGetDisplayEventSource =
            NativeLibrary.LoadNativeFunction<al_get_display_event_source>(_nativeAllegroLibrary, "al_get_display_event_source");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_backbuffer(IntPtr display);
        public static al_get_backbuffer AlGetBackbuffer =
            NativeLibrary.LoadNativeFunction<al_get_backbuffer>(_nativeAllegroLibrary, "al_get_backbuffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_flip_display();
        public static al_flip_display AlFlipDisplay =
            NativeLibrary.LoadNativeFunction<al_flip_display>(_nativeAllegroLibrary, "al_flip_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_update_display_region(int x, int y, int width, int height);
        public static al_update_display_region AlUpdateDisplayRegion =
            NativeLibrary.LoadNativeFunction<al_update_display_region>(_nativeAllegroLibrary, "al_update_display_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_wait_for_vsync();
        public static al_wait_for_vsync AlWaitForVsync =
            NativeLibrary.LoadNativeFunction<al_wait_for_vsync>(_nativeAllegroLibrary, "al_wait_for_vsync");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_width(IntPtr display);
        public static al_get_display_width AlGetDisplayWidth =
            NativeLibrary.LoadNativeFunction<al_get_display_width>(_nativeAllegroLibrary, "al_get_display_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_height(IntPtr display);
        public static al_get_display_height AlGetDisplayHeight =
            NativeLibrary.LoadNativeFunction<al_get_display_height>(_nativeAllegroLibrary, "al_get_display_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_resize_display(IntPtr display, int width, int height);
        public static al_resize_display AlResizeDisplay =
            NativeLibrary.LoadNativeFunction<al_resize_display>(_nativeAllegroLibrary, "al_resize_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_acknowledge_resize(IntPtr display);
        public static al_acknowledge_resize AlAcknowledgeResize =
            NativeLibrary.LoadNativeFunction<al_acknowledge_resize>(_nativeAllegroLibrary, "al_acknowledge_resize");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_window_position(IntPtr display, ref int x, ref int y);
        public static al_get_window_position AlGetWindowPosition =
            NativeLibrary.LoadNativeFunction<al_get_window_position>(_nativeAllegroLibrary, "al_get_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_window_position(IntPtr display, int x, int y);
        public static al_set_window_position AlSetWindowPosition =
            NativeLibrary.LoadNativeFunction<al_set_window_position>(_nativeAllegroLibrary, "al_set_window_position");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_get_window_constraints(IntPtr display, ref int min_w, ref int min_h, ref int max_w, ref int max_h);
        public static al_get_window_constraints AlGetWindowConstraints =
            NativeLibrary.LoadNativeFunction<al_get_window_constraints>(_nativeAllegroLibrary, "al_get_window_constraints");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_window_constraints(IntPtr display, int min_w, int min_h, int max_w, int max_h);
        public static al_set_window_constraints AlSetWindowConstraints =
            NativeLibrary.LoadNativeFunction<al_set_window_constraints>(_nativeAllegroLibrary, "al_set_window_constraints");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_apply_window_constraints(IntPtr display, bool onOff);
        public static al_apply_window_constraints AlApplyWindowConstraints =
            NativeLibrary.LoadNativeFunction<al_apply_window_constraints>(_nativeAllegroLibrary, "al_apply_window_constraints");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_flags(IntPtr display);
        public static al_get_display_flags AlGetDisplayFlags =
            NativeLibrary.LoadNativeFunction<al_get_display_flags>(_nativeAllegroLibrary, "al_get_display_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_display_flag(IntPtr display, int flag, bool onOff);
        public static al_set_display_flag AlSetDisplayFlag =
            NativeLibrary.LoadNativeFunction<al_set_display_flag>(_nativeAllegroLibrary, "al_set_display_flag");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_option(IntPtr display, int options);
        public static al_get_display_option AlGetDisplayOption =
            NativeLibrary.LoadNativeFunction<al_get_display_option>(_nativeAllegroLibrary, "al_get_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_display_option(IntPtr display, int option, int value);
        public static al_set_display_option AlSetDisplayOption =
            NativeLibrary.LoadNativeFunction<al_set_display_option>(_nativeAllegroLibrary, "al_set_display_option");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_format(IntPtr display);
        public static al_get_display_format AlGetDisplayFormat =
            NativeLibrary.LoadNativeFunction<al_get_display_format>(_nativeAllegroLibrary, "al_get_display_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_orientation(IntPtr display);
        public static al_get_display_orientation AlGetDisplayOrientation =
            NativeLibrary.LoadNativeFunction<al_get_display_orientation>(_nativeAllegroLibrary, "al_get_display_orientation");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_display_refresh_rate(IntPtr display);
        public static al_get_display_refresh_rate AlGetDisplayRefreshRate =
            NativeLibrary.LoadNativeFunction<al_get_display_refresh_rate>(_nativeAllegroLibrary, "al_get_display_refresh_rate");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_window_title(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string title);
        public static al_set_window_title AlSetWindowTitle =
            NativeLibrary.LoadNativeFunction<al_set_window_title>(_nativeAllegroLibrary, "al_set_window_title");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_window_title([MarshalAs(UnmanagedType.LPStr)] string title);
        public static al_set_new_window_title AlSetNewWindowTitle =
            NativeLibrary.LoadNativeFunction<al_set_new_window_title>(_nativeAllegroLibrary, "al_set_new_window_title");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_new_window_title();
        public static al_get_new_window_title AlGetNewWindowTitle =
            NativeLibrary.LoadNativeFunction<al_get_new_window_title>(_nativeAllegroLibrary, "al_get_new_window_title");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_display_icon(IntPtr display, IntPtr icon);
        public static al_set_display_icon AlSetDisplayIcon =
            NativeLibrary.LoadNativeFunction<al_set_display_icon>(_nativeAllegroLibrary, "al_set_display_icon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_display_icons(IntPtr display, int num_icons, IntPtr bitmaps);
        public static al_set_display_icons AlSetDisplayIcons =
            NativeLibrary.LoadNativeFunction<al_set_display_icons>(_nativeAllegroLibrary, "al_set_display_icons");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_acknowledge_drawing_halt(IntPtr display);
        public static al_acknowledge_drawing_halt AlAcknowledgeDrawingHalt =
            NativeLibrary.LoadNativeFunction<al_acknowledge_drawing_halt>(_nativeAllegroLibrary, "al_acknowledge_drawing_halt");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_acknowledge_drawing_resume(IntPtr display);
        public static al_acknowledge_drawing_resume AlAcknowledgeDrawingResume =
            NativeLibrary.LoadNativeFunction<al_acknowledge_drawing_resume>(_nativeAllegroLibrary, "al_acknowledge_drawing_resume");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_inhibit_screensaver(bool inhibit);
        public static al_inhibit_screensaver AlInhibitScreensaver =
            NativeLibrary.LoadNativeFunction<al_inhibit_screensaver>(_nativeAllegroLibrary, "al_inhibit_screensaver");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_clipboard_text(IntPtr display);
        public static al_get_clipboard_text AlGetClipboardText =
            NativeLibrary.LoadNativeFunction<al_get_clipboard_text>(_nativeAllegroLibrary, "al_get_clipboard_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_clipboard_text(IntPtr display, [MarshalAs(UnmanagedType.LPStr)] string text);
        public static al_set_clipboard_text AlSetClipboardText =
            NativeLibrary.LoadNativeFunction<al_set_clipboard_text>(_nativeAllegroLibrary, "al_set_clipboard_text");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_clipboard_has_text(IntPtr display);
        public static al_clipboard_has_text AlClipboardHasText =
            NativeLibrary.LoadNativeFunction<al_clipboard_has_text>(_nativeAllegroLibrary, "al_clipboard_has_text");
        #endregion

        #region Graphics routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgb(byte r, byte g, byte b);
        public static al_map_rgb AlMapRgb =
            NativeLibrary.LoadNativeFunction<al_map_rgb>(_nativeAllegroLibrary, "al_map_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgb_f(float r, float g, float b);
        public static al_map_rgb_f AlMapRgbF =
            NativeLibrary.LoadNativeFunction<al_map_rgb_f>(_nativeAllegroLibrary, "al_map_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgba(byte r, byte g, byte b, byte a);
        public static al_map_rgba AlMapRgba =
            NativeLibrary.LoadNativeFunction<al_map_rgba>(_nativeAllegroLibrary, "al_map_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);
        public static al_premul_rgba AlPremulRgba =
            NativeLibrary.LoadNativeFunction<al_premul_rgba>(_nativeAllegroLibrary, "al_premul_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_map_rgba_f(float r, float g, float b, float a);
        public static al_map_rgba_f AlMapRgbaF =
            NativeLibrary.LoadNativeFunction<al_map_rgba_f>(_nativeAllegroLibrary, "al_map_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_premul_rgba_f(float r, float g, float b, float a);
        public static al_premul_rgba_f AlPremulRgbaF =
            NativeLibrary.LoadNativeFunction<al_premul_rgba_f>(_nativeAllegroLibrary, "al_premul_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgb(NativeAllegroColor color, ref byte r, ref byte g, ref byte b);
        public static al_unmap_rgb AlUnmapRgb =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb>(_nativeAllegroLibrary, "al_unmap_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgb_f(NativeAllegroColor color, ref float r, ref float g, ref float b);
        public static al_unmap_rgb_f AlUnmapRgbF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb_f>(_nativeAllegroLibrary, "al_unmap_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgba(NativeAllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);
        public static al_unmap_rgba AlUnmapRgba =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba>(_nativeAllegroLibrary, "al_unmap_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unmap_rgba_f(NativeAllegroColor color, ref float r, ref float g, ref float b, ref float a);
        public static al_unmap_rgba_f AlUnmapRgbaF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba_f>(_nativeAllegroLibrary, "al_unmap_rgba_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_size(int format);
        public static al_get_pixel_size AlGetPixelSize =
            NativeLibrary.LoadNativeFunction<al_get_pixel_size>(_nativeAllegroLibrary, "al_get_pixel_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_format_bits(int format);
        public static al_get_pixel_format_bits AlGetPixelFormatBits =
            NativeLibrary.LoadNativeFunction<al_get_pixel_format_bits>(_nativeAllegroLibrary, "al_get_pixel_format_bits");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_block_size(int format);
        public static al_get_pixel_block_size AlGetPixelBlockSize =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_size>(_nativeAllegroLibrary, "al_get_pixel_block_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_block_width(int format);
        public static al_get_pixel_block_width AlGetPixelBlockWidth =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_width>(_nativeAllegroLibrary, "al_get_pixel_block_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_pixel_block_height(int format);
        public static al_get_pixel_block_height AlGetPixelBlockHeight =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_height>(_nativeAllegroLibrary, "al_get_pixel_block_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);
        public static al_lock_bitmap AlLockBitmap =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap>(_nativeAllegroLibrary, "al_lock_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);
        public static al_lock_bitmap_region AlLockBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_region>(_nativeAllegroLibrary, "al_lock_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_unlock_bitmap(IntPtr bitmap);
        public static al_unlock_bitmap AlUnlockBitmap =
            NativeLibrary.LoadNativeFunction<al_unlock_bitmap>(_nativeAllegroLibrary, "al_unlock_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);
        public static al_lock_bitmap_blocked AlLockBitmapBlocked =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_blocked>(_nativeAllegroLibrary, "al_lock_bitmap_blocked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x, int y, int width, int height, int flags);
        public static al_lock_bitmap_region_blocked AlLockBitmapRegionBlocked =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_region_blocked>(_nativeAllegroLibrary, "al_lock_bitmap_region_blocked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_bitmap(int w, int h);
        public static al_create_bitmap AlCreateBitmap =
            NativeLibrary.LoadNativeFunction<al_create_bitmap>(_nativeAllegroLibrary, "al_create_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);
        public static al_create_sub_bitmap AlCreateSubBitmap =
            NativeLibrary.LoadNativeFunction<al_create_sub_bitmap>(_nativeAllegroLibrary, "al_create_sub_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_clone_bitmap(IntPtr bitmap);
        public static al_clone_bitmap AlCloneBitmap =
            NativeLibrary.LoadNativeFunction<al_clone_bitmap>(_nativeAllegroLibrary, "al_clone_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_convert_bitmap(IntPtr bitmap);
        public static al_convert_bitmap AlConvertBitmap =
            NativeLibrary.LoadNativeFunction<al_convert_bitmap>(_nativeAllegroLibrary, "al_convert_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_convert_memory_bitmaps();
        public static al_convert_memory_bitmaps AlConvertMemoryBitmaps =
            NativeLibrary.LoadNativeFunction<al_convert_memory_bitmaps>(_nativeAllegroLibrary, "al_convert_memory_bitmaps");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_bitmap(IntPtr bitmap);
        public static al_destroy_bitmap AlDestroyBitmap =
            NativeLibrary.LoadNativeFunction<al_destroy_bitmap>(_nativeAllegroLibrary, "al_destroy_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_bitmap_flags();
        public static al_get_new_bitmap_flags AlGetNewBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_get_new_bitmap_flags>(_nativeAllegroLibrary, "al_get_new_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_new_bitmap_format();
        public static al_get_new_bitmap_format AlGetNewBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_get_new_bitmap_format>(_nativeAllegroLibrary, "al_get_new_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_bitmap_flags(int flags);
        public static al_set_new_bitmap_flags AlSetNewBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_set_new_bitmap_flags>(_nativeAllegroLibrary, "al_set_new_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_add_new_bitmap_flag(int flag);
        public static al_add_new_bitmap_flag AlAddNewBitmapFlag =
            NativeLibrary.LoadNativeFunction<al_add_new_bitmap_flag>(_nativeAllegroLibrary, "al_add_new_bitmap_flag");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_new_bitmap_format(int format);
        public static al_set_new_bitmap_format AlSetNewBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_set_new_bitmap_format>(_nativeAllegroLibrary, "al_set_new_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_flags(IntPtr bitmap);
        public static al_get_bitmap_flags AlGetBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_flags>(_nativeAllegroLibrary, "al_get_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_format(IntPtr bitmap);
        public static al_get_bitmap_format AlGetBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_format>(_nativeAllegroLibrary, "al_get_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_height(IntPtr bitmap);
        public static al_get_bitmap_height AlGetBitmapHeight =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_height>(_nativeAllegroLibrary, "al_get_bitmap_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_width(IntPtr bitmap);
        public static al_get_bitmap_width AlGetBitmapWidth =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_width>(_nativeAllegroLibrary, "al_get_bitmap_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_get_pixel(IntPtr bitmap, int x, int y);
        public static al_get_pixel AlGetPixel =
            NativeLibrary.LoadNativeFunction<al_get_pixel>(_nativeAllegroLibrary, "al_get_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_bitmap_locked(IntPtr bitmap);
        public static al_is_bitmap_locked AlIsBitmapLocked =
            NativeLibrary.LoadNativeFunction<al_is_bitmap_locked>(_nativeAllegroLibrary, "al_is_bitmap_locked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_compatible_bitmap(IntPtr bitmap);
        public static al_is_compatible_bitmap AlIsCompatibleBitmap =
            NativeLibrary.LoadNativeFunction<al_is_compatible_bitmap>(_nativeAllegroLibrary, "al_is_compatible_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_sub_bitmap(IntPtr bitmap);
        public static al_is_sub_bitmap AlIsSubBitmap =
            NativeLibrary.LoadNativeFunction<al_is_sub_bitmap>(_nativeAllegroLibrary, "al_is_sub_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_parent_bitmap(IntPtr bitmap);
        public static al_get_parent_bitmap AlGetParentBitmap =
            NativeLibrary.LoadNativeFunction<al_get_parent_bitmap>(_nativeAllegroLibrary, "al_get_parent_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_x(IntPtr bitmap);
        public static al_get_bitmap_x AlGetBitmapX =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_x>(_nativeAllegroLibrary, "al_get_bitmap_x");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_bitmap_y(IntPtr bitmap);
        public static al_get_bitmap_y AlGetBitmapY =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_y>(_nativeAllegroLibrary, "al_get_bitmap_y");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);
        public static al_reparent_bitmap AlReparentBitmap =
            NativeLibrary.LoadNativeFunction<al_reparent_bitmap>(_nativeAllegroLibrary, "al_reparent_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_clear_to_color(NativeAllegroColor color);
        public static al_clear_to_color AlClearToColor =
            NativeLibrary.LoadNativeFunction<al_clear_to_color>(_nativeAllegroLibrary, "al_clear_to_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_clear_depth_buffer(float z);
        public static al_clear_depth_buffer AlClearDepthBuffer =
            NativeLibrary.LoadNativeFunction<al_clear_depth_buffer>(_nativeAllegroLibrary, "al_clear_depth_buffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);
        public static al_draw_bitmap AlDrawBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_bitmap>(_nativeAllegroLibrary, "al_draw_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_bitmap(IntPtr bitmap, NativeAllegroColor tint, float dx, float dy, int flags);
        public static al_draw_tinted_bitmap AlDrawTintedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
        public static al_draw_bitmap_region AlDrawBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_bitmap_region>(_nativeAllegroLibrary, "al_draw_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_bitmap_region(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
        public static al_draw_tinted_bitmap_region AlDrawTintedBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_bitmap_region>(_nativeAllegroLibrary, "al_draw_tinted_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_pixel(float x, float y, NativeAllegroColor color);
        public static al_draw_pixel AlDrawPixel =
            NativeLibrary.LoadNativeFunction<al_draw_pixel>(_nativeAllegroLibrary, "al_draw_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);
        public static al_draw_rotated_bitmap AlDrawRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);
        public static al_draw_tinted_rotated_bitmap AlDrawTintedRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        public static al_draw_scaled_rotated_bitmap AlDrawScaledRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_scaled_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_scaled_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        public static al_draw_tinted_scaled_rotated_bitmap AlDrawTintedScaledRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_scaled_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        public static al_draw_tinted_scaled_rotated_bitmap_region AlDrawTintedScaledRotatedBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_rotated_bitmap_region>(_nativeAllegroLibrary, "al_draw_tinted_scaled_rotated_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
        public static al_draw_scaled_bitmap AlDrawScaledBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_scaled_bitmap>(_nativeAllegroLibrary, "al_draw_scaled_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_draw_tinted_scaled_bitmap(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
        public static al_draw_tinted_scaled_bitmap AlDrawTintedScaledBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_scaled_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_target_bitmap();
        public static al_get_target_bitmap AlGetTargetBitmap =
            NativeLibrary.LoadNativeFunction<al_get_target_bitmap>(_nativeAllegroLibrary, "al_get_target_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_put_pixel(int x, int y, NativeAllegroColor color);
        public static al_put_pixel AlPutPixel =
            NativeLibrary.LoadNativeFunction<al_put_pixel>(_nativeAllegroLibrary, "al_put_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_put_blended_pixel(int x, int y, NativeAllegroColor color);
        public static al_put_blended_pixel AlPutBlendedPixel =
            NativeLibrary.LoadNativeFunction<al_put_blended_pixel>(_nativeAllegroLibrary, "al_put_blended_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_target_bitmap(IntPtr bitmap);
        public static al_set_target_bitmap AlSetTargetBitmap =
            NativeLibrary.LoadNativeFunction<al_set_target_bitmap>(_nativeAllegroLibrary, "al_set_target_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_target_backbuffer(IntPtr display);
        public static al_set_target_backbuffer AlSetTargetBackbuffer =
            NativeLibrary.LoadNativeFunction<al_set_target_backbuffer>(_nativeAllegroLibrary, "al_set_target_backbuffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_current_display();
        public static al_get_current_display AlGetCurrentDisplay =
            NativeLibrary.LoadNativeFunction<al_get_current_display>(_nativeAllegroLibrary, "al_get_current_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_blender(ref int op, ref int src, ref int dst);
        public static al_get_blender AlGetBlender =
            NativeLibrary.LoadNativeFunction<al_get_blender>(_nativeAllegroLibrary, "al_get_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alphaOp, ref int alphaSrc, ref int alphaDst);
        public static al_get_separate_blender AlGetSeparateBlender =
            NativeLibrary.LoadNativeFunction<al_get_separate_blender>(_nativeAllegroLibrary, "al_get_separate_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate NativeAllegroColor al_get_blend_color();
        public static al_get_blend_color AlGetBlendColor =
            NativeLibrary.LoadNativeFunction<al_get_blend_color>(_nativeAllegroLibrary, "al_get_blend_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_blender(int op, int src, int dst);
        public static al_set_blender AlSetBlender =
            NativeLibrary.LoadNativeFunction<al_set_blender>(_nativeAllegroLibrary, "al_set_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_separate_blender(int op, int src, int dst, int alphaOp, int alphaSrc, int alphaDst);
        public static al_set_separate_blender AlSetSeparateBlender =
            NativeLibrary.LoadNativeFunction<al_set_separate_blender>(_nativeAllegroLibrary, "al_set_separate_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_blend_color(NativeAllegroColor color);
        public static al_set_blend_color AlSetBlendColor =
            NativeLibrary.LoadNativeFunction<al_set_blend_color>(_nativeAllegroLibrary, "al_set_blend_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);
        public static al_get_clipping_rectangle AlGetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_get_clipping_rectangle>(_nativeAllegroLibrary, "al_get_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_clipping_rectangle(int x, int y, int width, int height);
        public static al_set_clipping_rectangle AlSetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_set_clipping_rectangle>(_nativeAllegroLibrary, "al_set_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_reset_clipping_rectangle();
        public static al_reset_clipping_rectangle AlResetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_reset_clipping_rectangle>(_nativeAllegroLibrary, "al_reset_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_convert_mask_to_alpha(IntPtr bitmap, NativeAllegroColor maskColor);
        public static al_convert_mask_to_alpha AlConvertMaskToAlpha =
            NativeLibrary.LoadNativeFunction<al_convert_mask_to_alpha>(_nativeAllegroLibrary, "al_convert_mask_to_alpha");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_hold_bitmap_drawing(bool hold);
        public static al_hold_bitmap_drawing AlHoldBitmapDrawing =
            NativeLibrary.LoadNativeFunction<al_hold_bitmap_drawing>(_nativeAllegroLibrary, "al_hold_bitmap_drawing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_bitmap_drawing_held();
        public static al_is_bitmap_drawing_held AlIsBitmapDrawingHeld =
            NativeLibrary.LoadNativeFunction<al_is_bitmap_drawing_held>(_nativeAllegroLibrary, "al_is_bitmap_drawing_held");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_loader(IntPtr extension, IntPtr loader);
        public static al_register_bitmap_loader AlRegisterBitmapLoader =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_loader>(_nativeAllegroLibrary, "al_register_bitmap_loader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_saver(IntPtr extension, IntPtr saver);
        public static al_register_bitmap_saver AlRegisterBitmapSaver =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_saver>(_nativeAllegroLibrary, "al_register_bitmap_saver");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_loader_f(IntPtr extension, IntPtr fsLoader);
        public static al_register_bitmap_loader_f AlRegisterBitmapLoaderF =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_loader_f>(_nativeAllegroLibrary, "al_register_bitmap_loader_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_saver_f(IntPtr extension, IntPtr fsSaver);
        public static al_register_bitmap_saver_f AlRegisterBitmapSaverF =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_saver_f>(_nativeAllegroLibrary, "al_register_bitmap_saver_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_load_bitmap AlLoadBitmap =
            NativeLibrary.LoadNativeFunction<al_load_bitmap>(_nativeAllegroLibrary, "al_load_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_flags([MarshalAs(UnmanagedType.LPStr)] string filename, int flags);
        public static al_load_bitmap_flags AlLoadBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_flags>(_nativeAllegroLibrary, "al_load_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);
        public static al_load_bitmap_f AlLoadBitmapF =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_f>(_nativeAllegroLibrary, "al_load_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, int flags);
        public static al_load_bitmap_flags_f AlLoadBitmapFlagsF =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_flags_f>(_nativeAllegroLibrary, "al_load_bitmap_flags_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr bitmap);
        public static al_save_bitmap AlSaveBitmap =
            NativeLibrary.LoadNativeFunction<al_save_bitmap>(_nativeAllegroLibrary, "al_save_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_save_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, IntPtr bitmap);
        public static al_save_bitmap_f AlSaveBitmapF =
            NativeLibrary.LoadNativeFunction<al_save_bitmap_f>(_nativeAllegroLibrary, "al_save_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_register_bitmap_identifier([MarshalAs(UnmanagedType.LPStr)] string extension, IntPtr identifier);
        public static al_register_bitmap_identifier AlRegisterBitmapIdentifier =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_identifier>(_nativeAllegroLibrary, "al_register_bitmap_identifier");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_identify_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_identify_bitmap AlIdentifyBitmap =
            NativeLibrary.LoadNativeFunction<al_identify_bitmap>(_nativeAllegroLibrary, "al_identify_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_identify_bitmap_f(IntPtr fp);
        public static al_identify_bitmap_f AlIdentifyBitmapF =
            NativeLibrary.LoadNativeFunction<al_identify_bitmap_f>(_nativeAllegroLibrary, "al_identify_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_render_state(int state, int value);
        public static al_set_render_state AlSetRenderState =
            NativeLibrary.LoadNativeFunction<al_set_render_state>(_nativeAllegroLibrary, "al_set_render_state");
        #endregion

        #region Path structures
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_path([MarshalAs(UnmanagedType.LPStr)] string str);
        public static al_create_path AlCreatePath =
            NativeLibrary.LoadNativeFunction<al_create_path>(_nativeAllegroLibrary, "al_create_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_create_path_for_directory([MarshalAs(UnmanagedType.LPStr)] string str);
        public static al_create_path_for_directory AlCreatePathForDirectory =
            NativeLibrary.LoadNativeFunction<al_create_path_for_directory>(_nativeAllegroLibrary, "al_create_path_for_directory");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_destroy_path(IntPtr path);
        public static al_destroy_path AlDestroyPath =
            NativeLibrary.LoadNativeFunction<al_destroy_path>(_nativeAllegroLibrary, "al_destroy_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_clone_path(IntPtr path);
        public static al_clone_path AlClonePath =
            NativeLibrary.LoadNativeFunction<al_clone_path>(_nativeAllegroLibrary, "al_clone_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_join_paths(IntPtr path, IntPtr tail);
        public static al_join_paths AlJoinPaths =
            NativeLibrary.LoadNativeFunction<al_join_paths>(_nativeAllegroLibrary, "al_join_paths");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_rebase_path(IntPtr head, IntPtr tail);
        public static al_rebase_path AlRebasePath =
            NativeLibrary.LoadNativeFunction<al_rebase_path>(_nativeAllegroLibrary, "al_rebase_path");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_drive(IntPtr path);
        public static al_get_path_drive AlGetPathDrive =
            NativeLibrary.LoadNativeFunction<al_get_path_drive>(_nativeAllegroLibrary, "al_get_path_drive");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_path_num_components(IntPtr path);
        public static al_get_path_num_components AlGetPathNumComponents =
            NativeLibrary.LoadNativeFunction<al_get_path_num_components>(_nativeAllegroLibrary, "al_get_path_num_components");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_component(IntPtr path, int i);
        public static al_get_path_component AlGetPathComponent =
            NativeLibrary.LoadNativeFunction<al_get_path_component>(_nativeAllegroLibrary, "al_get_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_tail(IntPtr path);
        public static al_get_path_tail AlGetPathTail =
            NativeLibrary.LoadNativeFunction<al_get_path_tail>(_nativeAllegroLibrary, "al_get_path_tail");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_filename(IntPtr path);
        public static al_get_path_filename AlGetPathFilename =
            NativeLibrary.LoadNativeFunction<al_get_path_filename>(_nativeAllegroLibrary, "al_get_path_filename");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_basename(IntPtr path);
        public static al_get_path_basename AlGetPathBasename =
            NativeLibrary.LoadNativeFunction<al_get_path_basename>(_nativeAllegroLibrary, "al_get_path_basename");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_path_extension(IntPtr path);
        public static al_get_path_extension AlGetPathExtension =
            NativeLibrary.LoadNativeFunction<al_get_path_extension>(_nativeAllegroLibrary, "al_get_path_extension");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_path_drive(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string drive);
        public static al_set_path_drive AlSetPathDrive =
            NativeLibrary.LoadNativeFunction<al_set_path_drive>(_nativeAllegroLibrary, "al_set_path_drive");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_append_path_component(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string s);
        public static al_append_path_component AlAppendPathComponent =
            NativeLibrary.LoadNativeFunction<al_append_path_component>(_nativeAllegroLibrary, "al_append_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_insert_path_component(IntPtr path, int i, [MarshalAs(UnmanagedType.LPStr)] string s);
        public static al_insert_path_component AlInsertPathComponent =
            NativeLibrary.LoadNativeFunction<al_insert_path_component>(_nativeAllegroLibrary, "al_insert_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_replace_path_component(IntPtr path, int i, [MarshalAs(UnmanagedType.LPStr)] string s);
        public static al_replace_path_component AlReplacePathComponent =
            NativeLibrary.LoadNativeFunction<al_replace_path_component>(_nativeAllegroLibrary, "al_replace_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_remove_path_component(IntPtr path, int i);
        public static al_remove_path_component AlRemovePathComponent =
            NativeLibrary.LoadNativeFunction<al_remove_path_component>(_nativeAllegroLibrary, "al_remove_path_component");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_drop_path_tail(IntPtr path);
        public static al_drop_path_tail AlDropPathTail =
            NativeLibrary.LoadNativeFunction<al_drop_path_tail>(_nativeAllegroLibrary, "al_drop_path_tail");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_path_filename(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string filename);
        public static al_set_path_filename AlSetPathFilename =
            NativeLibrary.LoadNativeFunction<al_set_path_filename>(_nativeAllegroLibrary, "al_set_path_filename");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_set_path_extension(IntPtr path, [MarshalAs(UnmanagedType.LPStr)] string extension);
        public static al_set_path_extension AlSetPathExtension =
            NativeLibrary.LoadNativeFunction<al_set_path_extension>(_nativeAllegroLibrary, "al_set_path_extension");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_path_cstr(IntPtr path, char delim);
        public static al_path_cstr AlPathCstr =
            NativeLibrary.LoadNativeFunction<al_path_cstr>(_nativeAllegroLibrary, "al_path_cstr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_path_ustr(IntPtr path, char delim);
        public static al_path_ustr AlPathUstr =
            NativeLibrary.LoadNativeFunction<al_path_ustr>(_nativeAllegroLibrary, "al_path_ustr");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_make_path_canonical(IntPtr path);
        public static al_make_path_canonical AlMakePathCanonical =
            NativeLibrary.LoadNativeFunction<al_make_path_canonical>(_nativeAllegroLibrary, "al_make_path_canonical");
        #endregion

        #region PhysicsFS integration
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_physfs_file_interface();
        public static al_set_physfs_file_interface AlSetPhysfsFileInterface =
            NativeLibrary.LoadNativeFunction<al_set_physfs_file_interface>(_nativeAllegroLibrary, "al_set_physfs_file_interface");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint al_get_allegro_physfs_version();
        public static al_get_allegro_physfs_version AlGetAllegroPhysfsVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_physfs_version>(_nativeAllegroLibrary, "al_get_allegro_physfs_version");
        #endregion

        #region System routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_allegro_version();
        public static al_get_allegro_version AlGetAllegroVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_version>(_nativeAllegroLibrary, "al_get_allegro_version");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_app_name();
        public static al_get_app_name AlGetAppName =
            NativeLibrary.LoadNativeFunction<al_get_app_name>(_nativeAllegroLibrary, "al_get_app_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_cpu_count();
        public static al_get_cpu_count AlGetCpuCount =
            NativeLibrary.LoadNativeFunction<al_get_cpu_count>(_nativeAllegroLibrary, "al_get_cpu_count");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_org_name();
        public static al_get_org_name AlGetOrgName =
            NativeLibrary.LoadNativeFunction<al_get_org_name>(_nativeAllegroLibrary, "al_get_org_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_ram_size();
        public static al_get_ram_size AlGetRamSize =
            NativeLibrary.LoadNativeFunction<al_get_ram_size>(_nativeAllegroLibrary, "al_get_ram_size");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_standard_path(int id);
        public static al_get_standard_path AlGetStandardPath =
            NativeLibrary.LoadNativeFunction<al_get_standard_path>(_nativeAllegroLibrary, "al_get_standard_path");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr al_get_system_config();
        public static al_get_system_config AlGetSystemConfig =
            NativeLibrary.LoadNativeFunction<al_get_system_config>(_nativeAllegroLibrary, "al_get_system_config");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int al_get_system_id();
        public static al_get_system_id AlGetSystemID =
            NativeLibrary.LoadNativeFunction<al_get_system_id>(_nativeAllegroLibrary, "al_get_system_id");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_install_system(int version, IntPtr atExitPtr);
        public static al_install_system AlInstallSystem =
            NativeLibrary.LoadNativeFunction<al_install_system>(_nativeAllegroLibrary, "al_install_system");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool al_is_system_installed();
        public static al_is_system_installed AlIsSystemInstalled =
            NativeLibrary.LoadNativeFunction<al_is_system_installed>(_nativeAllegroLibrary, "al_is_system_installed");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_register_assert_handler(Delegates.AssertHandler assertHandler);
        public static al_register_assert_handler AlRegisterAssertHandler =
            NativeLibrary.LoadNativeFunction<al_register_assert_handler>(_nativeAllegroLibrary, "al_register_assert_handler");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_register_trace_handler(Delegates.TraceHandler traceHandler);
        public static al_register_trace_handler AlRegisterTraceHandler =
            NativeLibrary.LoadNativeFunction<al_register_trace_handler>(_nativeAllegroLibrary, "al_register_trace_handler");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_app_name([MarshalAs(UnmanagedType.LPStr)] string name);
        public static al_set_app_name AlSetAppName =
            NativeLibrary.LoadNativeFunction<al_set_app_name>(_nativeAllegroLibrary, "al_set_app_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_exe_name([MarshalAs(UnmanagedType.LPStr)] string name);
        public static al_set_exe_name AlSetExeName =
            NativeLibrary.LoadNativeFunction<al_set_exe_name>(_nativeAllegroLibrary, "al_set_exe_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_set_org_name([MarshalAs(UnmanagedType.LPStr)] string name);
        public static al_set_org_name AlSetOrgName =
            NativeLibrary.LoadNativeFunction<al_set_org_name>(_nativeAllegroLibrary, "al_set_org_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void al_uninstall_system();
        public static al_uninstall_system AlUninstallSystem =
            NativeLibrary.LoadNativeFunction<al_uninstall_system>(_nativeAllegroLibrary, "al_uninstall_system");
        #endregion

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //public delegate ();
        //public static Al =
        //    NativeLibrary.LoadNativeFunction<>(_nativeAllegroLibrary, "");
    }
}
