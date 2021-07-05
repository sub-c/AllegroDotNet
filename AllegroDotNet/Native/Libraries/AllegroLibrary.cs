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
        internal delegate bool al_init_acodec_addon();
        internal static al_init_acodec_addon AlInitAcodecAddon =
            NativeLibrary.LoadNativeFunction<al_init_acodec_addon>(_nativeAllegroLibrary, "al_init_acodec_addon");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_is_acodec_addon_initialized();
        internal static al_is_acodec_addon_initialized AlIsAcodecAddonInitialized =
            NativeLibrary.LoadNativeFunction<al_is_acodec_addon_initialized>(_nativeAllegroLibrary, "al_is_acodec_addon_initialized");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate uint al_get_allegro_acodec_version();
        internal static al_get_allegro_acodec_version AlGetAllegroAcodecVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_acodec_version>(_nativeAllegroLibrary, "al_get_allegro_acodec_version");
        #endregion

        #region Graphics routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_map_rgb(byte r, byte g, byte b);
        internal static al_map_rgb AlMapRgb =
            NativeLibrary.LoadNativeFunction<al_map_rgb>(_nativeAllegroLibrary, "al_map_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_map_rgb_f(float r, float g, float b);
        internal static al_map_rgb_f AlMapRgbF =
            NativeLibrary.LoadNativeFunction<al_map_rgb_f>(_nativeAllegroLibrary, "al_map_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_map_rgba(byte r, byte g, byte b, byte a);
        internal static al_map_rgba AlMapRgba =
            NativeLibrary.LoadNativeFunction<al_map_rgba>(_nativeAllegroLibrary, "al_map_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);
        internal static al_premul_rgba AlPremulRgba =
            NativeLibrary.LoadNativeFunction<al_premul_rgba>(_nativeAllegroLibrary, "al_premul_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_map_rgba_f(float r, float g, float b, float a);
        internal static al_map_rgba_f AlMapRgbaF =
            NativeLibrary.LoadNativeFunction<al_map_rgba_f>(_nativeAllegroLibrary, "al_map_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_premul_rgba_f(float r, float g, float b, float a);
        internal static al_premul_rgba_f AlPremulRgbaF =
            NativeLibrary.LoadNativeFunction<al_premul_rgba_f>(_nativeAllegroLibrary, "al_premul_rgba_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_unmap_rgb(NativeAllegroColor color, ref byte r, ref byte g, ref byte b);
        internal static al_unmap_rgb AlUnmapRgb =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb>(_nativeAllegroLibrary, "al_unmap_rgb");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_unmap_rgb_f(NativeAllegroColor color, ref float r, ref float g, ref float b);
        internal static al_unmap_rgb_f AlUnmapRgbF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgb_f>(_nativeAllegroLibrary, "al_unmap_rgb_f");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_unmap_rgba(NativeAllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);
        internal static al_unmap_rgba AlUnmapRgba =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba>(_nativeAllegroLibrary, "al_unmap_rgba");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_unmap_rgba_f(NativeAllegroColor color, ref float r, ref float g, ref float b, ref float a);
        internal static al_unmap_rgba_f AlUnmapRgbaF =
            NativeLibrary.LoadNativeFunction<al_unmap_rgba_f>(_nativeAllegroLibrary, "al_unmap_rgba_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_pixel_size(int format);
        internal static al_get_pixel_size AlGetPixelSize =
            NativeLibrary.LoadNativeFunction<al_get_pixel_size>(_nativeAllegroLibrary, "al_get_pixel_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_pixel_format_bits(int format);
        internal static al_get_pixel_format_bits AlGetPixelFormatBits =
            NativeLibrary.LoadNativeFunction<al_get_pixel_format_bits>(_nativeAllegroLibrary, "al_get_pixel_format_bits");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_pixel_block_size(int format);
        internal static al_get_pixel_block_size AlGetPixelBlockSize =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_size>(_nativeAllegroLibrary, "al_get_pixel_block_size");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_pixel_block_width(int format);
        internal static al_get_pixel_block_width AlGetPixelBlockWidth =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_width>(_nativeAllegroLibrary, "al_get_pixel_block_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_pixel_block_height(int format);
        internal static al_get_pixel_block_height AlGetPixelBlockHeight =
            NativeLibrary.LoadNativeFunction<al_get_pixel_block_height>(_nativeAllegroLibrary, "al_get_pixel_block_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);
        internal static al_lock_bitmap AlLockBitmap =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap>(_nativeAllegroLibrary, "al_lock_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);
        internal static al_lock_bitmap_region AlLockBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_region>(_nativeAllegroLibrary, "al_lock_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_unlock_bitmap(IntPtr bitmap);
        internal static al_unlock_bitmap AlUnlockBitmap =
            NativeLibrary.LoadNativeFunction<al_unlock_bitmap>(_nativeAllegroLibrary, "al_unlock_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);
        internal static al_lock_bitmap_blocked AlLockBitmapBlocked =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_blocked>(_nativeAllegroLibrary, "al_lock_bitmap_blocked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x, int y, int width, int height, int flags);
        internal static al_lock_bitmap_region_blocked AlLockBitmapRegionBlocked =
            NativeLibrary.LoadNativeFunction<al_lock_bitmap_region_blocked>(_nativeAllegroLibrary, "al_lock_bitmap_region_blocked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_create_bitmap(int w, int h);
        internal static al_create_bitmap AlCreateBitmap =
            NativeLibrary.LoadNativeFunction<al_create_bitmap>(_nativeAllegroLibrary, "al_create_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);
        internal static al_create_sub_bitmap AlCreateSubBitmap =
            NativeLibrary.LoadNativeFunction<al_create_sub_bitmap>(_nativeAllegroLibrary, "al_create_sub_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_clone_bitmap(IntPtr bitmap);
        internal static al_clone_bitmap AlCloneBitmap =
            NativeLibrary.LoadNativeFunction<al_clone_bitmap>(_nativeAllegroLibrary, "al_clone_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_convert_bitmap(IntPtr bitmap);
        internal static al_convert_bitmap AlConvertBitmap =
            NativeLibrary.LoadNativeFunction<al_convert_bitmap>(_nativeAllegroLibrary, "al_convert_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_convert_memory_bitmaps();
        internal static al_convert_memory_bitmaps AlConvertMemoryBitmaps =
            NativeLibrary.LoadNativeFunction<al_convert_memory_bitmaps>(_nativeAllegroLibrary, "al_convert_memory_bitmaps");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_destroy_bitmap(IntPtr bitmap);
        internal static al_destroy_bitmap AlDestroyBitmap =
            NativeLibrary.LoadNativeFunction<al_destroy_bitmap>(_nativeAllegroLibrary, "al_destroy_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_new_bitmap_flags();
        internal static al_get_new_bitmap_flags AlGetNewBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_get_new_bitmap_flags>(_nativeAllegroLibrary, "al_get_new_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_new_bitmap_format();
        internal static al_get_new_bitmap_format AlGetNewBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_get_new_bitmap_format>(_nativeAllegroLibrary, "al_get_new_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_new_bitmap_flags(int flags);
        internal static al_set_new_bitmap_flags AlSetNewBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_set_new_bitmap_flags>(_nativeAllegroLibrary, "al_set_new_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_add_new_bitmap_flag(int flag);
        internal static al_add_new_bitmap_flag AlAddNewBitmapFlag =
            NativeLibrary.LoadNativeFunction<al_add_new_bitmap_flag>(_nativeAllegroLibrary, "al_add_new_bitmap_flag");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_new_bitmap_format(int format);
        internal static al_set_new_bitmap_format AlSetNewBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_set_new_bitmap_format>(_nativeAllegroLibrary, "al_set_new_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_bitmap_flags(IntPtr bitmap);
        internal static al_get_bitmap_flags AlGetBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_flags>(_nativeAllegroLibrary, "al_get_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_bitmap_format(IntPtr bitmap);
        internal static al_get_bitmap_format AlGetBitmapFormat =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_format>(_nativeAllegroLibrary, "al_get_bitmap_format");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_bitmap_height(IntPtr bitmap);
        internal static al_get_bitmap_height AlGetBitmapHeight =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_height>(_nativeAllegroLibrary, "al_get_bitmap_height");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_bitmap_width(IntPtr bitmap);
        internal static al_get_bitmap_width AlGetBitmapWidth =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_width>(_nativeAllegroLibrary, "al_get_bitmap_width");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_get_pixel(IntPtr bitmap, int x, int y);
        internal static al_get_pixel AlGetPixel =
            NativeLibrary.LoadNativeFunction<al_get_pixel>(_nativeAllegroLibrary, "al_get_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_is_bitmap_locked(IntPtr bitmap);
        internal static al_is_bitmap_locked AlIsBitmapLocked =
            NativeLibrary.LoadNativeFunction<al_is_bitmap_locked>(_nativeAllegroLibrary, "al_is_bitmap_locked");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_is_compatible_bitmap(IntPtr bitmap);
        internal static al_is_compatible_bitmap AlIsCompatibleBitmap =
            NativeLibrary.LoadNativeFunction<al_is_compatible_bitmap>(_nativeAllegroLibrary, "al_is_compatible_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_is_sub_bitmap(IntPtr bitmap);
        internal static al_is_sub_bitmap AlIsSubBitmap =
            NativeLibrary.LoadNativeFunction<al_is_sub_bitmap>(_nativeAllegroLibrary, "al_is_sub_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_get_parent_bitmap(IntPtr bitmap);
        internal static al_get_parent_bitmap AlGetParentBitmap =
            NativeLibrary.LoadNativeFunction<al_get_parent_bitmap>(_nativeAllegroLibrary, "al_get_parent_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_bitmap_x(IntPtr bitmap);
        internal static al_get_bitmap_x AlGetBitmapX =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_x>(_nativeAllegroLibrary, "al_get_bitmap_x");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_bitmap_y(IntPtr bitmap);
        internal static al_get_bitmap_y AlGetBitmapY =
            NativeLibrary.LoadNativeFunction<al_get_bitmap_y>(_nativeAllegroLibrary, "al_get_bitmap_y");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);
        internal static al_reparent_bitmap AlReparentBitmap =
            NativeLibrary.LoadNativeFunction<al_reparent_bitmap>(_nativeAllegroLibrary, "al_reparent_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_clear_to_color(NativeAllegroColor color);
        internal static al_clear_to_color AlClearToColor =
            NativeLibrary.LoadNativeFunction<al_clear_to_color>(_nativeAllegroLibrary, "al_clear_to_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_clear_depth_buffer(float z);
        internal static al_clear_depth_buffer AlClearDepthBuffer =
            NativeLibrary.LoadNativeFunction<al_clear_depth_buffer>(_nativeAllegroLibrary, "al_clear_depth_buffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);
        internal static al_draw_bitmap AlDrawBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_bitmap>(_nativeAllegroLibrary, "al_draw_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_tinted_bitmap(IntPtr bitmap, NativeAllegroColor tint, float dx, float dy, int flags);
        internal static al_draw_tinted_bitmap AlDrawTintedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
        internal static al_draw_bitmap_region AlDrawBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_bitmap_region>(_nativeAllegroLibrary, "al_draw_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_tinted_bitmap_region(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);
        internal static al_draw_tinted_bitmap_region AlDrawTintedBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_bitmap_region>(_nativeAllegroLibrary, "al_draw_tinted_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_pixel(float x, float y, NativeAllegroColor color);
        internal static al_draw_pixel AlDrawPixel =
            NativeLibrary.LoadNativeFunction<al_draw_pixel>(_nativeAllegroLibrary, "al_draw_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);
        internal static al_draw_rotated_bitmap AlDrawRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_tinted_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);
        internal static al_draw_tinted_rotated_bitmap AlDrawTintedRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        internal static al_draw_scaled_rotated_bitmap AlDrawScaledRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_scaled_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_scaled_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        internal static al_draw_tinted_scaled_rotated_bitmap AlDrawTintedScaledRotatedBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_rotated_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_scaled_rotated_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);
        internal static al_draw_tinted_scaled_rotated_bitmap_region AlDrawTintedScaledRotatedBitmapRegion =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_rotated_bitmap_region>(_nativeAllegroLibrary, "al_draw_tinted_scaled_rotated_bitmap_region");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
        internal static al_draw_scaled_bitmap AlDrawScaledBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_scaled_bitmap>(_nativeAllegroLibrary, "al_draw_scaled_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_draw_tinted_scaled_bitmap(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);
        internal static al_draw_tinted_scaled_bitmap AlDrawTintedScaledBitmap =
            NativeLibrary.LoadNativeFunction<al_draw_tinted_scaled_bitmap>(_nativeAllegroLibrary, "al_draw_tinted_scaled_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_get_target_bitmap();
        internal static al_get_target_bitmap AlGetTargetBitmap =
            NativeLibrary.LoadNativeFunction<al_get_target_bitmap>(_nativeAllegroLibrary, "al_get_target_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_put_pixel(int x, int y, NativeAllegroColor color);
        internal static al_put_pixel AlPutPixel =
            NativeLibrary.LoadNativeFunction<al_put_pixel>(_nativeAllegroLibrary, "al_put_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_put_blended_pixel(int x, int y, NativeAllegroColor color);
        internal static al_put_blended_pixel AlPutBlendedPixel =
            NativeLibrary.LoadNativeFunction<al_put_blended_pixel>(_nativeAllegroLibrary, "al_put_blended_pixel");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_target_bitmap(IntPtr bitmap);
        internal static al_set_target_bitmap AlSetTargetBitmap =
            NativeLibrary.LoadNativeFunction<al_set_target_bitmap>(_nativeAllegroLibrary, "al_set_target_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_target_backbuffer(IntPtr display);
        internal static al_set_target_backbuffer AlSetTargetBackbuffer =
            NativeLibrary.LoadNativeFunction<al_set_target_backbuffer>(_nativeAllegroLibrary, "al_set_target_backbuffer");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_get_current_display();
        internal static al_get_current_display AlGetCurrentDisplay =
            NativeLibrary.LoadNativeFunction<al_get_current_display>(_nativeAllegroLibrary, "al_get_current_display");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_get_blender(ref int op, ref int src, ref int dst);
        internal static al_get_blender AlGetBlender =
            NativeLibrary.LoadNativeFunction<al_get_blender>(_nativeAllegroLibrary, "al_get_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alphaOp, ref int alphaSrc, ref int alphaDst);
        internal static al_get_separate_blender AlGetSeparateBlender =
            NativeLibrary.LoadNativeFunction<al_get_separate_blender>(_nativeAllegroLibrary, "al_get_separate_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate NativeAllegroColor al_get_blend_color();
        internal static al_get_blend_color AlGetBlendColor =
            NativeLibrary.LoadNativeFunction<al_get_blend_color>(_nativeAllegroLibrary, "al_get_blend_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_blender(int op, int src, int dst);
        internal static al_set_blender AlSetBlender =
            NativeLibrary.LoadNativeFunction<al_set_blender>(_nativeAllegroLibrary, "al_set_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_separate_blender(int op, int src, int dst, int alphaOp, int alphaSrc, int alphaDst);
        internal static al_set_separate_blender AlSetSeparateBlender =
            NativeLibrary.LoadNativeFunction<al_set_separate_blender>(_nativeAllegroLibrary, "al_set_separate_blender");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_blend_color(NativeAllegroColor color);
        internal static al_set_blend_color AlSetBlendColor =
            NativeLibrary.LoadNativeFunction<al_set_blend_color>(_nativeAllegroLibrary, "al_set_blend_color");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);
        internal static al_get_clipping_rectangle AlGetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_get_clipping_rectangle>(_nativeAllegroLibrary, "al_get_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_clipping_rectangle(int x, int y, int width, int height);
        internal static al_set_clipping_rectangle AlSetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_set_clipping_rectangle>(_nativeAllegroLibrary, "al_set_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_reset_clipping_rectangle();
        internal static al_reset_clipping_rectangle AlResetClippingRectangle =
            NativeLibrary.LoadNativeFunction<al_reset_clipping_rectangle>(_nativeAllegroLibrary, "al_reset_clipping_rectangle");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_convert_mask_to_alpha(IntPtr bitmap, NativeAllegroColor maskColor);
        internal static al_convert_mask_to_alpha AlConvertMaskToAlpha =
            NativeLibrary.LoadNativeFunction<al_convert_mask_to_alpha>(_nativeAllegroLibrary, "al_convert_mask_to_alpha");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_hold_bitmap_drawing(bool hold);
        internal static al_hold_bitmap_drawing AlHoldBitmapDrawing =
            NativeLibrary.LoadNativeFunction<al_hold_bitmap_drawing>(_nativeAllegroLibrary, "al_hold_bitmap_drawing");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_is_bitmap_drawing_held();
        internal static al_is_bitmap_drawing_held AlIsBitmapDrawingHeld =
            NativeLibrary.LoadNativeFunction<al_is_bitmap_drawing_held>(_nativeAllegroLibrary, "al_is_bitmap_drawing_held");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_register_bitmap_loader(IntPtr extension, IntPtr loader);
        internal static al_register_bitmap_loader AlRegisterBitmapLoader =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_loader>(_nativeAllegroLibrary, "al_register_bitmap_loader");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_register_bitmap_saver(IntPtr extension, IntPtr saver);
        internal static al_register_bitmap_saver AlRegisterBitmapSaver =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_saver>(_nativeAllegroLibrary, "al_register_bitmap_saver");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_register_bitmap_loader_f(IntPtr extension, IntPtr fsLoader);
        internal static al_register_bitmap_loader_f AlRegisterBitmapLoaderF =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_loader_f>(_nativeAllegroLibrary, "al_register_bitmap_loader_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_register_bitmap_saver_f(IntPtr extension, IntPtr fsSaver);
        internal static al_register_bitmap_saver_f AlRegisterBitmapSaverF =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_saver_f>(_nativeAllegroLibrary, "al_register_bitmap_saver_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_load_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);
        internal static al_load_bitmap AlLoadBitmap =
            NativeLibrary.LoadNativeFunction<al_load_bitmap>(_nativeAllegroLibrary, "al_load_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_load_bitmap_flags([MarshalAs(UnmanagedType.LPStr)] string filename, int flags);
        internal static al_load_bitmap_flags AlLoadBitmapFlags =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_flags>(_nativeAllegroLibrary, "al_load_bitmap_flags");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_load_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);
        internal static al_load_bitmap_f AlLoadBitmapF =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_f>(_nativeAllegroLibrary, "al_load_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_load_bitmap_flags_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, int flags);
        internal static al_load_bitmap_flags_f AlLoadBitmapFlagsF =
            NativeLibrary.LoadNativeFunction<al_load_bitmap_flags_f>(_nativeAllegroLibrary, "al_load_bitmap_flags_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_save_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename, IntPtr bitmap);
        internal static al_save_bitmap AlSaveBitmap =
            NativeLibrary.LoadNativeFunction<al_save_bitmap>(_nativeAllegroLibrary, "al_save_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_save_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident, IntPtr bitmap);
        internal static al_save_bitmap_f AlSaveBitmapF =
            NativeLibrary.LoadNativeFunction<al_save_bitmap_f>(_nativeAllegroLibrary, "al_save_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_register_bitmap_identifier([MarshalAs(UnmanagedType.LPStr)] string extension, IntPtr identifier);
        internal static al_register_bitmap_identifier AlRegisterBitmapIdentifier =
            NativeLibrary.LoadNativeFunction<al_register_bitmap_identifier>(_nativeAllegroLibrary, "al_register_bitmap_identifier");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_identify_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);
        internal static al_identify_bitmap AlIdentifyBitmap =
            NativeLibrary.LoadNativeFunction<al_identify_bitmap>(_nativeAllegroLibrary, "al_identify_bitmap");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_identify_bitmap_f(IntPtr fp);
        internal static al_identify_bitmap_f AlIdentifyBitmapF =
            NativeLibrary.LoadNativeFunction<al_identify_bitmap_f>(_nativeAllegroLibrary, "al_identify_bitmap_f");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_render_state(int state, int value);
        internal static al_set_render_state AlSetRenderState =
            NativeLibrary.LoadNativeFunction<al_set_render_state>(_nativeAllegroLibrary, "al_set_render_state");
        #endregion

        #region System routines
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_allegro_version();
        internal static al_get_allegro_version AlGetAllegroVersion =
            NativeLibrary.LoadNativeFunction<al_get_allegro_version>(_nativeAllegroLibrary, "al_get_allegro_version");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_get_app_name();
        internal static al_get_app_name AlGetAppName =
            NativeLibrary.LoadNativeFunction<al_get_app_name>(_nativeAllegroLibrary, "al_get_app_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_cpu_count();
        internal static al_get_cpu_count AlGetCpuCount =
            NativeLibrary.LoadNativeFunction<al_get_cpu_count>(_nativeAllegroLibrary, "al_get_cpu_count");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_get_org_name();
        internal static al_get_org_name AlGetOrgName =
            NativeLibrary.LoadNativeFunction<al_get_org_name>(_nativeAllegroLibrary, "al_get_org_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_ram_size();
        internal static al_get_ram_size AlGetRamSize =
            NativeLibrary.LoadNativeFunction<al_get_ram_size>(_nativeAllegroLibrary, "al_get_ram_size");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_get_standard_path(int id);
        internal static al_get_standard_path AlGetStandardPath =
            NativeLibrary.LoadNativeFunction<al_get_standard_path>(_nativeAllegroLibrary, "al_get_standard_path");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate IntPtr al_get_system_config();
        internal static al_get_system_config AlGetSystemConfig =
            NativeLibrary.LoadNativeFunction<al_get_system_config>(_nativeAllegroLibrary, "al_get_system_config");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int al_get_system_id();
        internal static al_get_system_id AlGetSystemID =
            NativeLibrary.LoadNativeFunction<al_get_system_id>(_nativeAllegroLibrary, "al_get_system_id");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_install_system(int version, IntPtr atExitPtr);
        internal static al_install_system AlInstallSystem =
            NativeLibrary.LoadNativeFunction<al_install_system>(_nativeAllegroLibrary, "al_install_system");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool al_is_system_installed();
        internal static al_is_system_installed AlIsSystemInstalled =
            NativeLibrary.LoadNativeFunction<al_is_system_installed>(_nativeAllegroLibrary, "al_is_system_installed");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_register_assert_handler(Delegates.AssertHandler assertHandler);
        internal static al_register_assert_handler AlRegisterAssertHandler =
            NativeLibrary.LoadNativeFunction<al_register_assert_handler>(_nativeAllegroLibrary, "al_register_assert_handler");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_register_trace_handler(Delegates.TraceHandler traceHandler);
        internal static al_register_trace_handler AlRegisterTraceHandler =
            NativeLibrary.LoadNativeFunction<al_register_trace_handler>(_nativeAllegroLibrary, "al_register_trace_handler");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_app_name([MarshalAs(UnmanagedType.LPStr)] string name);
        internal static al_set_app_name AlSetAppName =
            NativeLibrary.LoadNativeFunction<al_set_app_name>(_nativeAllegroLibrary, "al_set_app_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_exe_name([MarshalAs(UnmanagedType.LPStr)] string name);
        internal static al_set_exe_name AlSetExeName =
            NativeLibrary.LoadNativeFunction<al_set_exe_name>(_nativeAllegroLibrary, "al_set_exe_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_set_org_name([MarshalAs(UnmanagedType.LPStr)] string name);
        internal static al_set_org_name AlSetOrgName =
            NativeLibrary.LoadNativeFunction<al_set_org_name>(_nativeAllegroLibrary, "al_set_org_name");
            
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void al_uninstall_system();
        internal static al_uninstall_system AlUninstallSystem =
            NativeLibrary.LoadNativeFunction<al_uninstall_system>(_nativeAllegroLibrary, "al_uninstall_system");
        #endregion

        //[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        //internal delegate ();
        //internal static Al =
        //    NativeLibrary.LoadNativeFunction<>(_nativeAllegroLibrary, "");
    }
}
