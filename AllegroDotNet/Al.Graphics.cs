using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AllegroDotNet.Models;
using AllegroDotNet.Models.Enums;
using AllegroDotNet.Models.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Convert r, g, b (ranging from 0-255) into an <see cref="AllegroColor"/>, using 255 for alpha.
        /// </summary>
        /// <param name="r">Amount of red (0-255).</param>
        /// <param name="g">Amount of green (0-255).</param>
        /// <param name="b">Amount of blue (0-255).</param>
        /// <returns>Instance of the specified color.</returns>
        public static AllegroColor MapRgb(byte r, byte g, byte b)
            => new AllegroColor { Native = al_map_rgb(r, g, b) };

        /// <summary>
        /// Convert r, g, b, (ranging from 0.0f-1.0f) into an ALLEGRO_COLOR, using 1.0f for alpha.
        /// </summary>
        /// <param name="r">Amount of red (0.0-1.0).</param>
        /// <param name="g">Amount of green (0.0-1.0).</param>
        /// <param name="b">Amount of blue (0.0-1.0).</param>
        /// <returns>Instance of the specified color.</returns>
        public static AllegroColor MapRgbF(float r, float g, float b)
            => new AllegroColor { Native = al_map_rgb_f(r, g, b) };

        /// <summary>
        /// Convert r, g, b (ranging from 0-255) into an <see cref="AllegroColor"/>, using 255 for alpha.
        /// </summary>
        /// <param name="r">Amount of red (0-255).</param>
        /// <param name="g">Amount of green (0-255).</param>
        /// <param name="b">Amount of blue (0-255).</param>
        /// <param name="a">Amount of alpha (0-255).</param>
        /// <returns>Instance of the specified color.</returns>
        public static AllegroColor MapRgbA(byte r, byte g, byte b, byte a)
            => new AllegroColor { Native = al_map_rgba(r, g, b, a) };

        /// <summary>
        /// By default Allegro uses pre-multiplied alpha for transparent blending of bitmaps and primitives
        /// (see al_load_bitmap_flags for a discussion of that feature). This means that if you want
        /// to tint a bitmap or primitive to be transparent you need to multiply the color components by the alpha
        /// components when you pass them to this function.
        /// </summary>
        /// <param name="r">Amount of red (0-255).</param>
        /// <param name="g">Amount of green (0-255).</param>
        /// <param name="b">Amount of blue (0-255).</param>
        /// <param name="a">Amount of alpha (0-255).</param>
        /// <returns>Instance of the specified color.</returns>
        public static AllegroColor PremulRgbA(byte r, byte g, byte b, byte a)
            => new AllegroColor { Native = al_map_rgba(
                Convert.ToByte(r * a / 255),
                Convert.ToByte(g * a / 255),
                Convert.ToByte(b * a / 255),
                a) };

        /// <summary>
        /// Convert r, g, b, a (ranging from 0.0f-1.0f) into an <see cref="AllegroColor"/>.
        /// </summary>
        /// <param name="r">Amount of red (0.0-1.0).</param>
        /// <param name="g">Amount of green (0.0-1.0).</param>
        /// <param name="b">Amount of blue (0.0-1.0).</param>
        /// <param name="a">Amount of alpha (0.0-1.0).</param>
        /// <returns>Instance of the specified color.</returns>
        public static AllegroColor MapRgbAF(float r, float g, float b, float a)
            => new AllegroColor { Native = al_map_rgba_f(r, g, b, a) };

        /// <summary>
        /// By default Allegro uses pre-multiplied alpha for transparent blending of bitmaps and primitives
        /// (see al_load_bitmap_flags for a discussion of that feature). This means that if you want
        /// to tint a bitmap or primitive to be transparent you need to multiply the color components by the alpha
        /// components when you pass them to this function.
        /// </summary>
        /// <param name="r">Amount of red (0.0-1.0).</param>
        /// <param name="g">Amount of green (0.0-1.0).</param>
        /// <param name="b">Amount of blue (0.0-1.0).</param>
        /// <param name="a">Amount of alpha (0.0-1.0).</param>
        /// <returns>Instance of the specified color.</returns>
        public static AllegroColor PremulRgbAF(float r, float g, float b, float a)
            => new AllegroColor { Native = al_map_rgba_f(r * a, g * a, b * a, a) };

        /// <summary>
        /// Retrieves components of an ALLEGRO_COLOR, ignoring alpha. Components will range from 0-255.
        /// </summary>
        /// <param name="color">The color to pull the RGB values from.</param>
        /// <param name="r">Amount of red (0-255).</param>
        /// <param name="g">Amount of green (0-255).</param>
        /// <param name="b">Amount of blue (0-255).</param>
        public static void UnmapRgb(AllegroColor color, ref byte r, ref byte g, ref byte b)
            => al_unmap_rgb(color.Native, ref r, ref g, ref b);

        /// <summary>
        /// Retrieves components of an ALLEGRO_COLOR, ignoring alpha. Components will range from 0.0f-1.0f.
        /// </summary>
        /// <param name="color">The color to pull the RGB values from.</param>
        /// <param name="r">Amount of red (0.0-1.0).</param>
        /// <param name="g">Amount of green (0.0-1.0).</param>
        /// <param name="b">Amount of blue (0.0-1.0).</param>
        public static void UnmapRgbF(AllegroColor color, ref float r, ref float g, ref float b)
            => al_unmap_rgb_f(color.Native, ref r, ref g, ref b);

        /// <summary>
        /// Retrieves components of an ALLEGRO_COLOR. Components will range from 0-255.
        /// </summary>
        /// <param name="color">The color to pull the RGB values from.</param>
        /// <param name="r">Amount of red (0-255).</param>
        /// <param name="g">Amount of green (0-255).</param>
        /// <param name="b">Amount of blue (0-255).</param>
        /// <param name="a">Amount of alpha (0-255).</param>
        public static void UnmapRgbA(AllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a)
            => al_unmap_rgba(color.Native, ref r, ref g, ref b, ref a);

        /// <summary>
        /// Retrieves components of an ALLEGRO_COLOR. Components will range from 0.0f-1.0f.
        /// </summary>
        /// <param name="color">The color to pull the RGB values from.</param>
        /// <param name="r">Amount of red (0-255).</param>
        /// <param name="g">Amount of green (0-255).</param>
        /// <param name="b">Amount of blue (0-255).</param>
        /// <param name="a">Amount of alpha (0-255).</param>
        public static void UnmapRgbAF(AllegroColor color, ref float r, ref float g, ref float b, ref float a)
            => al_unmap_rgba_f(color.Native, ref r, ref g, ref b, ref a);

        /// <summary>
        /// Return the number of bytes that a pixel of the given format occupies. For blocked pixel formats (e.g.
        /// compressed formats), this returns 0.
        /// </summary>
        /// <param name="format">The pixel format.</param>
        /// <returns>The amount of bytes for a pixel in the given pixel format.</returns>
        public static int GetPixelSize(PixelFormat format)
            => al_get_pixel_size((int)format);

        /// <summary>
        /// Return the number of bits that a pixel of the given format occupies. For blocked pixel formats (e.g.
        /// compressed formats), this returns 0.
        /// </summary>
        /// <param name="format">The pixel format.</param>
        /// <returns>The amount of bits for a pixel in the given pixel format.</returns>
        public static int GetPixelFormatBits(PixelFormat format)
            => al_get_pixel_format_bits((int)format);

        /// <summary>
        /// Return the number of bytes that a block of pixels with this format occupies.
        /// </summary>
        /// <param name="format">The pixel format.</param>
        /// <returns>The number of bytes that a block of pixels with this format occupies.</returns>
        public static int GetPixelBlockSize(PixelFormat format)
            => al_get_pixel_block_size((int)format);

        /// <summary>
        /// Return the width of the the pixel block for this format.
        /// </summary>
        /// <param name="format">The pixel format.</param>
        /// <returns>The width of the the pixel block for this format.</returns>
        public static int GetPixelBlockWidth(PixelFormat format)
            => al_get_pixel_block_width((int)format);

        /// <summary>
        /// Return the height of the the pixel block for this format.
        /// </summary>
        /// <param name="format">The pixel format.</param>
        /// <returns>The height of the the pixel block for this format.</returns>
        public static int GetPixelBlockHeight(PixelFormat format)
            => al_get_pixel_block_height((int)format);

        /// <summary>
        /// Lock an entire bitmap for reading or writing. If the bitmap is a display bitmap it will be updated from
        /// system memory after the bitmap is unlocked (unless locked read only). Returns NULL if the bitmap cannot be
        /// locked, e.g. the bitmap was locked previously and not unlocked. This function also returns NULL if the
        /// format is a compressed format.
        /// <para>
        /// format indicates the pixel format that the returned buffer will be in. To lock in the same format as the
        /// bitmap stores its data internally, call with al_get_bitmap_format(bitmap) as the format or use
        /// ALLEGRO_PIXEL_FORMAT_ANY. Locking in the native format will usually be faster. If the bitmap format is
        /// compressed, using ALLEGRO_PIXEL_FORMAT_ANY will choose an implementation defined non-compressed format.
        /// </para>
        /// <para>
        /// On some platforms, Allegro automatically backs up the contents of video bitmaps because they may be
        /// occasionally lost (see discussion in al_create_bitmap's documentation). If you're completely recreating
        /// the bitmap contents often (e.g. every frame) then you will get much better performance by creating the
        /// target bitmap with ALLEGRO_NO_PRESERVE_TEXTURE flag.
        /// </para>
        /// <para>
        /// Note: While a bitmap is locked, you can not use any drawing operations on it (with the sole exception of
        /// al_put_pixel and al_put_blended_pixel).
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to lock.</param>
        /// <param name="format">The pixel format to return the locked region as.</param>
        /// <param name="flags">The read/write flag for the returned region.</param>
        /// <returns>A locked bitmap.</returns>
        public static AllegroLockedRegion LockBitmap(AllegroBitmap bitmap, PixelFormat format, LockFlags flags)
            => new AllegroLockedRegion
            {
                Native = al_lock_bitmap(bitmap.NativeIntPtr, (int)format, (int)flags)
            };

        /// <summary>
        /// Like al_lock_bitmap, but only locks a specific area of the bitmap. If the bitmap is a video bitmap, only
        /// that area of the texture will be updated when it is unlocked. Locking only the region you indend to modify
        /// will be faster than locking the whole bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to lock.</param>
        /// <param name="x">The X position to lock.</param>
        /// <param name="y">The Y position to lock.</param>
        /// <param name="width">The width to lock.</param>
        /// <param name="height">The height position to lock.</param>
        /// <param name="format">The pixel format to return the locked region as.</param>
        /// <param name="flags">The read/write flag for the returned region.</param>
        /// <returns>A locked bitmap region.</returns>
        public static AllegroLockedRegion LockBitmapRegion(AllegroBitmap bitmap, int x, int y, int width, int height, PixelFormat format, LockFlags flags)
            => new AllegroLockedRegion
            {
                Native = al_lock_bitmap_region(bitmap.NativeIntPtr, x, y, width, height, (int)format, (int)flags)
            };

        /// <summary>
        /// Unlock a previously locked bitmap or bitmap region. If the bitmap is a video bitmap, the texture will be
        /// updated to match the system memory copy (unless it was locked read only).
        /// </summary>
        /// <param name="bitmap">The bitmap to unlock.</param>
        public static void UnlockBitmap(AllegroBitmap bitmap)
            => al_unlock_bitmap(bitmap.NativeIntPtr);

        /// <summary>
        /// Like al_lock_bitmap, but allows locking bitmaps with a blocked pixel format (i.e. a format for which
        /// al_get_pixel_block_width or al_get_pixel_block_height do not return 1) in that format. To that end,
        /// this function also does not allow format conversion. For bitmap formats with a block size of 1, this
        /// function is identical to calling al_lock_bitmap(bmp, al_get_bitmap_format(bmp), flags).
        /// </summary>
        /// <param name="bitmap">The bitmap to lock.</param>
        /// <param name="flags">The read/write flag.</param>
        /// <returns>The locked blocked bitmap.</returns>
        public static AllegroLockedRegion LockBitmapBlocked(AllegroBitmap bitmap, LockFlags flags)
            => new AllegroLockedRegion
            {
                Native = al_lock_bitmap_blocked(bitmap.NativeIntPtr, (int)flags)
            };

        /// <summary>
        /// Like al_lock_bitmap_blocked, but allows locking a sub-region, for performance. Unlike al_lock_bitmap_region
        /// the region specified in terms of blocks and not pixels.
        /// </summary>
        /// <param name="bitmap">The bitmap to lock.</param>
        /// <param name="xBlock">The X position to lock.</param>
        /// <param name="yBlock">The Y position to lock.</param>
        /// <param name="widthBlock">The width to lock.</param>
        /// <param name="heightBlock">The height to lock.</param>
        /// <param name="flags">The read/write flag.</param>
        /// <returns>The locked blocked bitmap region.</returns>
        public static AllegroLockedRegion LockBitmapRegionBlocked(AllegroBitmap bitmap, int xBlock, int yBlock, int widthBlock, int heightBlock, LockFlags flags)
            => new AllegroLockedRegion
            {
                Native = al_lock_bitmap_region_blocked(bitmap.NativeIntPtr, xBlock, yBlock, widthBlock, heightBlock, (int)flags)
            };

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
        private static extern NativeLockedRegion al_lock_bitmap(IntPtr bitmap, int format, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeLockedRegion al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern void al_unlock_bitmap(IntPtr bitmap);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeLockedRegion al_lock_bitmap_blocked(IntPtr bitmap, int flags);

        [DllImport(Constants.AllegroCoreDllFilename)]
        private static extern NativeLockedRegion al_lock_bitmap_region_blocked(IntPtr bitmap, int x, int y, int width, int height, int flags);

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
