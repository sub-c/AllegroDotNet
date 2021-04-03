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

        /// <summary>
        /// Creates a new bitmap using the bitmap format and flags for the current thread. Blitting between bitmaps of
        /// differing formats, or blitting between memory bitmaps and display bitmaps may be slow.
        /// <para>
        /// Unless you set the ALLEGRO_MEMORY_BITMAP flag, the bitmap is created for the current display.Blitting to
        /// another display may be slow.
        /// </para>
        /// <para>
        /// If a display bitmap is created, there may be limitations on the allowed dimensions.For example a DirectX or
        /// OpenGL backend usually has a maximum allowed texture size - so if bitmap creation fails for very large
        /// dimensions, you may want to re-try with a smaller bitmap. Some platforms also dictate a minimum texture
        /// size, which is relevant if you plan to use this bitmap with the primitives addon.If you try to create a
        /// bitmap smaller than this, this call will not fail but the returned bitmap will be a section of a larger
        /// bitmap with the minimum size. The minimum size that will work on all platforms is 32 by 32. There is an
        /// experimental switch to turns this padding off by editing the system configuration (see min_bitmap_size
        /// key in al_get_system_config).
        /// </para>
        /// <para>
        /// Some platforms do not directly support display bitmaps whose dimensions are not powers of two. Allegro
        /// handles this by creating a larger bitmap that has dimensions that are powers of two and then returning
        /// a section of that bitmap with the dimensions you requested. This can be relevant if you plan to use this
        /// bitmap with the primitives addon but shouldn’t be an issue otherwise.
        /// </para>
        /// <para>
        /// If you create a bitmap without ALLEGRO_MEMORY_BITMAP set but there is no current display, a temporary
        /// memory bitmap will be created instead. You can later convert all such bitmap to video bitmap and assign
        /// to a display by calling al_convert_memory_bitmaps.
        /// </para>
        /// <para>
        /// On some platforms the contents of video bitmaps may be lost when your application loses focus. Allegro
        /// has an internal mechanism to restore the contents of these video bitmaps, but it is not foolproof
        /// (sometimes bitmap contents can get lost permanently) and has performance implications.If you are using
        /// a bitmap as an intermediate buffer this mechanism may be wasteful. In this case, if you do not want
        /// Allegro to manage the bitmap contents for you, you can disable this mechanism by creating the bitmap
        /// with the ALLEGRO_NO_PRESERVE_TEXTURE flag.The bitmap contents are lost when you get the
        /// ALLEGRO_EVENT_DISPLAY_LOST and ALLEGRO_EVENT_DISPLAY_HALT_DRAWING and a should be restored when you
        /// get the ALLEGRO_EVENT_DISPLAY_FOUND and when you call al_acknowledge_drawing_resume (after
        /// ALLEGRO_EVENT_DISPLAY_RESUME_DRAWING event). You can use those events to implement your own bitmap
        /// content restoration mechanism if Allegro’s does not work well enough for you (for example, you can
        /// reload them all from disk).
        /// </para>
        /// <para>
        /// Note: The contents of a newly created bitmap are undefined - you need to clear the bitmap or make sure
        /// all pixels get overwritten before drawing it.
        /// </para>
        /// <para>
        /// When you are done with using the bitmap you must call al_destroy_bitmap on it to free any resources
        /// allocated for it.
        /// </para>
        /// </summary>
        /// <param name="w">Width of bitmap.</param>
        /// <param name="h">Height of bitmap.</param>
        /// <returns>The created bitmap instance, otherwise null.</returns>
        public static AllegroBitmap CreateBitmap(int w, int h)
        {
            var nativeBitmap = al_create_bitmap(w, h);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Creates a sub-bitmap of the parent, at the specified coordinates and of the specified size. A sub-bitmap
        /// is a bitmap that shares drawing memory with a pre-existing (parent) bitmap, but possibly with a different
        /// size and clipping settings.
        /// <para>
        /// The sub-bitmap may originate off or extend past the parent bitmap.
        /// </para>
        /// <para>
        /// See the discussion in al_get_backbuffer about using sub-bitmaps of the backbuffer.
        /// </para>
        /// <para>
        /// The parent bitmap’s clipping rectangles are ignored.
        /// </para>
        /// <para>
        /// If a sub-bitmap was not or cannot be created then NULL is returned.
        /// </para>
        /// <para>
        /// When you are done with using the sub-bitmap you must call al_destroy_bitmap on it to free any resources
        /// allocated for it.
        /// </para>
        /// <para>
        /// Note that destroying parents of sub-bitmaps will not destroy the sub-bitmaps; instead the sub-bitmaps
        /// become invalid and should no longer be used for drawing - they still must be destroyed with
        /// al_destroy_bitmap however.It does not matter whether you destroy a sub-bitmap before or after its parent
        /// otherwise.
        /// </para>
        /// </summary>
        /// <param name="parent">The parent bitmap.</param>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        /// <param name="w">The width.</param>
        /// <param name="h">The height.</param>
        /// <returns>A new instance of a sub-bitmap from the parent, otherwise null.</returns>
        public static AllegroBitmap CreateSubBitmap(AllegroBitmap parent, int x, int y, int w, int h)
        {
            var nativeBitmap = al_create_sub_bitmap(parent.NativeIntPtr, x, y, w, h);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Create a new bitmap with al_create_bitmap, and copy the pixel data from the old bitmap across. The newly
        /// created bitmap will be created with the current new bitmap flags, and not the ones that were used to create
        /// the original bitmap. If the new bitmap is a memory bitmap, its projection bitmap is reset to be
        /// orthographic.
        /// </summary>
        /// <param name="bitmap">The bitmap to clone.</param>
        /// <returns>The cloned bitmap, otherwise null.</returns>
        public static AllegroBitmap CloneBitmap(AllegroBitmap bitmap)
        {
            var nativeBitmap = al_clone_bitmap(bitmap.NativeIntPtr);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Converts the bitmap to the current bitmap flags and format. The bitmap will be as if it was created anew
        /// with al_create_bitmap but retain its contents. All of this bitmap’s sub-bitmaps are also converted. If
        /// the new bitmap type is memory, then the bitmap’s projection bitmap is reset to be orthographic.
        /// <para>
        /// If this bitmap is a sub-bitmap, then it, its parent and all the sibling sub-bitmaps are also converted.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to convert.</param>
        public static void ConvertBitmap(AllegroBitmap bitmap)
            => al_convert_bitmap(bitmap.NativeIntPtr);

        /// <summary>
        /// If you create a bitmap when there is no current display (for example because you have not called
        /// al_create_display in the current thread) and are using the ALLEGRO_CONVERT_BITMAP bitmap flag (which
        /// is set by default) then the bitmap will be created successfully, but as a memory bitmap. This function
        /// converts all such bitmaps to proper video bitmaps belonging to the current display.
        /// <para>
        /// Note that video bitmaps get automatically converted back to memory bitmaps when the last display is destroyed.
        /// </para>
        /// <para>
        /// This operation will preserve all bitmap flags except ALLEGRO_VIDEO_BITMAP and ALLEGRO_MEMORY_BITMAP.
        /// </para>
        /// </summary>
        public static void ConvertMemoryBitmaps()
            => al_convert_memory_bitmaps();

        /// <summary>
        /// Destroys the given bitmap, freeing all resources used by it. This function does nothing if the bitmap
        /// argument is NULL.
        /// <para>
        /// As a convenience, if the calling thread is currently targeting the bitmap then the bitmap will be
        /// untargeted first. The new target bitmap is unspecified.
        /// </para>
        /// <para>
        /// Otherwise, it is an error to destroy a bitmap while it (or a sub-bitmap) is the target bitmap of any
        /// thread.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to destroy.</param>
        public static void DestroyBitmap(AllegroBitmap bitmap)
            => al_destroy_bitmap(bitmap.NativeIntPtr);

        /// <summary>
        /// Returns the flags used for newly created bitmaps.
        /// </summary>
        /// <returns>The flags used for newly created bitmaps.</returns>
        public static BitmapFlags GetNewBitmapFlags()
            => (BitmapFlags)al_get_new_bitmap_flags();

        /// <summary>
        /// Returns the format used for newly created bitmaps.
        /// </summary>
        /// <returns>The format used for newly created bitmaps.</returns>
        public static PixelFormat GetNewBitmapFormat()
            => (PixelFormat)al_get_new_bitmap_format();

        /// <summary>
        /// Sets the flags to use for newly created bitmaps.
        /// </summary>
        /// <param name="flags">Flags for newly created bitmaps.</param>
        public static void SetNewBitmapFlags(BitmapFlags flags)
            => al_set_new_bitmap_flags((int)flags);

        /// <summary>
        /// A convenience function which does the same as:
        /// <para>
        /// <c>al_set_new_bitmap_flags(al_get_new_bitmap_flags() | flag);</c>
        /// </para>
        /// </summary>
        /// <param name="flag">The flag to set.</param>
        public static void AddNewBitmapFlag(BitmapFlags flag)
            => al_add_new_bitmap_flag((int)flag);

        /// <summary>
        /// Sets the pixel format (<see cref="PixelFormat"/>) for newly created bitmaps. The default format is 0
        /// and means the display driver will choose the best format.
        /// </summary>
        /// <param name="format">The pixel format.</param>
        public static void SetNewBitmapFormat(PixelFormat format)
            => al_set_new_bitmap_format((int)format);

        /// <summary>
        /// Return the flags used to create the bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to get the flags of.</param>
        /// <returns>The flags used to create the bitmap.</returns>
        public static BitmapFlags GetBitmapFlags(AllegroBitmap bitmap)
            => (BitmapFlags)al_get_bitmap_flags(bitmap.NativeIntPtr);

        /// <summary>
        /// Returns the pixel format of a bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to get the pixel format of.</param>
        /// <returns>The pixel format of a bitmap.</returns>
        public static PixelFormat GetBitmapFormat(AllegroBitmap bitmap)
            => (PixelFormat)al_get_bitmap_format(bitmap.NativeIntPtr);

        /// <summary>
        /// Returns the height of a bitmap in pixels.
        /// </summary>
        /// <param name="bitmap">The bitmap to get the height of.</param>
        /// <returns>The height of a bitmap in pixels.</returns>
        public static int GetBitmapHeight(AllegroBitmap bitmap)
            => al_get_bitmap_height(bitmap.NativeIntPtr);

        /// <summary>
        /// Returns the width of a bitmap in pixels.
        /// </summary>
        /// <param name="bitmap">The bitmap to get the width of.</param>
        /// <returns>The width of a bitmap in pixels.</returns>
        public static int GetBitmapWidth(AllegroBitmap bitmap)
            => al_get_bitmap_width(bitmap.NativeIntPtr);

        /// <summary>
        /// Get a pixel’s color value from the specified bitmap. This operation is slow on non-memory bitmaps.
        /// Consider locking the bitmap if you are going to use this function multiple times on the same bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to get the color from.</param>
        /// <param name="x">The x coordinate of the color.</param>
        /// <param name="y">the y coordinate of the color.</param>
        /// <returns>The color of the location of the bitmap.</returns>
        public static AllegroColor GetPixel(AllegroBitmap bitmap, int x, int y)
            => new AllegroColor
            {
                Native = al_get_pixel(bitmap.NativeIntPtr, x, y)
            };

        /// <summary>
        /// Returns whether or not a bitmap is already locked.
        /// </summary>
        /// <param name="bitmap">The bitmap to see if it is locked.</param>
        /// <returns>Whether or not a bitmap is already locked.</returns>
        public static bool IsBitmapLocked(AllegroBitmap bitmap)
            => al_is_bitmap_locked(bitmap.NativeIntPtr);

        /// <summary>
        /// D3D and OpenGL allow sharing a texture in a way so it can be used for multiple windows. Each
        /// ALLEGRO_BITMAP created with al_create_bitmap however is usually tied to a single ALLEGRO_DISPLAY.
        /// This function can be used to know if the bitmap is compatible with the given display, even if it is a
        /// different display to the one it was created with. It returns true if the bitmap is compatible (things
        /// like a cached texture version can be used) and false otherwise (blitting in the current display will
        /// be slow).
        /// <para>
        /// The only time this function is useful is if you are using multiple windows and need accelerated blitting
        /// of the same bitmaps to both.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to see if it is compatible.</param>
        /// <returns>
        /// Returns true if the bitmap is compatible with the current display, false otherwise.
        /// If there is no current display, false is returned.
        /// </returns>
        public static bool IsCompatibleBitmap(AllegroBitmap bitmap)
            => al_is_compatible_bitmap(bitmap.NativeIntPtr);

        /// <summary>
        /// Returns true if the specified bitmap is a sub-bitmap, false otherwise.
        /// </summary>
        /// <param name="bitmap">The bitmap to check if it is a sub-bitmap.</param>
        /// <returns>True if the specified bitmap is a sub-bitmap, false otherwise.</returns>
        public static bool IsSubBitmap(AllegroBitmap bitmap)
            => al_is_sub_bitmap(bitmap.NativeIntPtr);

        /// <summary>
        /// Returns the bitmap this bitmap is a sub-bitmap of. Returns NULL if this bitmap is not a sub-bitmap.
        /// This function always returns the real bitmap, and never a sub-bitmap. This might NOT match what was
        /// passed to al_create_sub_bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to get the parent of.</param>
        /// <returns>Bitmap that the given bitmap is a sub-bitmap of, otherwise null.</returns>
        public static AllegroBitmap GetParentBitmap(AllegroBitmap bitmap)
        {
            var nativeBitmap = al_get_parent_bitmap(bitmap.NativeIntPtr);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// For a sub-bitmap, return it’s x position within the parent.
        /// </summary>
        /// <param name="bitmap">Bitmap with a parent.</param>
        /// <returns>X position within the parent.</returns>
        public static int GetBitmapX(AllegroBitmap bitmap)
            => al_get_bitmap_x(bitmap.NativeIntPtr);

        /// <summary>
        /// For a sub-bitmap, return it’s y position within the parent.
        /// </summary>
        /// <param name="bitmap">Bitmap with a parent.</param>
        /// <returns>Y position within the parent.</returns>
        public static int GetBitmapY(AllegroBitmap bitmap)
            => al_get_bitmap_y(bitmap.NativeIntPtr);

        /// <summary>
        /// For a sub-bitmap, changes the parent, position and size. This is the same as destroying the bitmap and
        /// re-creating it with al_create_sub_bitmap - except the bitmap pointer stays the same. This has many uses,
        /// for example an animation player could return a single bitmap which can just be re-parented to different
        /// animation frames without having to re-draw the contents. Or a sprite atlas could re-arrange its sprites
        /// without having to invalidate all existing bitmaps.
        /// </summary>
        /// <param name="bitmap">Bitmap to change the parent of.</param>
        /// <param name="parent">Bitmap to become the parent.</param>
        /// <param name="x">X position in the parent.</param>
        /// <param name="y">Y position in the parent.</param>
        /// <param name="w">Width in the parent.</param>
        /// <param name="h">Height in the parent.</param>
        public static void ReparentBitmap(AllegroBitmap bitmap, AllegroBitmap parent, int x, int y, int w, int h)
            => al_reparent_bitmap(bitmap.NativeIntPtr, parent.NativeIntPtr, x, y, w, h);

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
