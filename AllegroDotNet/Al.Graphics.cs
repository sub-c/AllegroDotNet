using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AllegroDotNet.Models.Enums;
using AllegroDotNet.Models.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        #region P/Invokes
        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_map_rgb(byte r, byte g, byte b);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_map_rgb_f(float r, float g, float b);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_map_rgba(byte r, byte g, byte b, byte a);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_map_rgba_f(float r, float g, float b, float a);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_premul_rgba_f(float r, float g, float b, float a);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_unmap_rgb(NativeAllegroColor color, ref byte r, ref byte g, ref byte b);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_unmap_rgb_f(NativeAllegroColor color, ref float r, ref float g, ref float b);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_unmap_rgba(NativeAllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_unmap_rgba_f(NativeAllegroColor color, ref float r, ref float g, ref float b, ref float a);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_pixel_size(int format);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_pixel_format_bits(int format);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_pixel_block_size(int format);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_pixel_block_width(int format);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_pixel_block_height(int format);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_lock_bitmap(IntPtr bitmap, int format, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_unlock_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_lock_bitmap_blocked(IntPtr bitmap, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_lock_bitmap_region_blocked(IntPtr bitmap, int x, int y, int width, int height, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_create_bitmap(int w, int h);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_clone_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_convert_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_convert_memory_bitmaps();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_destroy_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_new_bitmap_flags();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_new_bitmap_format();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_new_bitmap_flags(int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_add_new_bitmap_flag(int flag);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_new_bitmap_format(int format);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_bitmap_flags(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_bitmap_format(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_bitmap_height(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_bitmap_width(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_get_pixel(IntPtr bitmap, int x, int y);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_is_bitmap_locked(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_is_compatible_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_is_sub_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_parent_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_bitmap_x(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern int al_get_bitmap_y(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_clear_to_color(NativeAllegroColor color);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_clear_depth_buffer(float z);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_tinted_bitmap(IntPtr bitmap, NativeAllegroColor tint, float dx, float dy, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_tinted_bitmap_region(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_pixel(float x, float y, NativeAllegroColor color);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_tinted_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_draw_tinted_scaled_bitmap(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_target_bitmap();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_put_pixel(int x, int y, NativeAllegroColor color);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_put_blended_pixel(int x, int y, NativeAllegroColor color);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_target_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_target_backbuffer(IntPtr display);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_get_current_display();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_get_blender(ref int op, ref int src, ref int dst);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alphaOp, ref int alphaSrc, ref int alphaDst);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeAllegroColor al_get_blend_color();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_blender(int op, int src, int dst);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_separate_blender(int op, int src, int dst, int alphaOp, int alphaSrc, int alphaDst);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_blend_color(NativeAllegroColor color);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_clipping_rectangle(int x, int y, int width, int height);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_reset_clipping_rectangle();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_convert_mask_to_alpha(IntPtr bitmap, NativeAllegroColor maskColor);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_hold_bitmap_drawing(bool hold);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_is_bitmap_drawing_held();

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_register_bitmap_loader(IntPtr extension, IntPtr loader);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_register_bitmap_saver(IntPtr extension, IntPtr saver);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_register_bitmap_loader_f(IntPtr extension, IntPtr fsLoader);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_register_bitmap_saver_f(IntPtr extension, IntPtr fsSaver);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_load_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_load_bitmap_flags(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_load_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_load_bitmap_flags_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_save_bitmap(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_save_bitmap_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern bool al_register_bitmap_identifier(
            [MarshalAs(UnmanagedType.LPStr)] string extension,
            IntPtr identifier);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_identify_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern IntPtr al_identify_bitmap_f(IntPtr fp);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_set_render_state(IntPtr state, int value);
        #endregion
    }
}
