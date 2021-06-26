using System;
using System.Runtime.InteropServices;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet
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

        /// <summary>
        /// Clear the complete target bitmap, but confined by the clipping rectangle.
        /// </summary>
        /// <param name="color">The color to clear to.</param>
        public static void ClearToColor(AllegroColor color)
            => al_clear_to_color(color.Native);

        /// <summary>
        /// Clear the depth buffer (confined by the clipping rectangle) to the given value. A depth buffer is only
        /// available if it was requested with al_set_new_display_option and the requirement could be met by the
        /// al_create_display call creating the current display. Operations involving the depth buffer are also
        /// affected by al_set_render_state.
        /// <para>
        /// For example, if ALLEGRO_DEPTH_FUNCTION is set to ALLEGRO_RENDER_LESS then depth buffer value of 1
        /// represents infinite distance, and thus is a good value to use when clearing the depth buffer.
        /// </para>
        /// </summary>
        /// <param name="z">The z depth.</param>
        public static void ClearDepthBuffer(float z)
            => al_clear_depth_buffer(z);

        /// <summary>
        /// Draws an unscaled, unrotated bitmap at the given position to the current target bitmap (see
        /// al_set_target_bitmap).
        /// <para>
        /// Note: The current target bitmap must be a different bitmap. Drawing a bitmap to itself (or to a sub-bitmap
        /// of itself) or drawing a sub-bitmap to its parent (or another sub-bitmap of its parent) are not currently
        /// supported. To copy part of a bitmap into the same bitmap simply use a temporary bitmap instead.
        /// </para>
        /// <para>
        /// Note: The backbuffer (or a sub-bitmap thereof) can not be transformed, blended or tinted. If you need to
        /// draw the backbuffer draw it to a temporary bitmap first with no active transformation (except translation).
        /// Blending and tinting settings/parameters will be ignored. This does not apply when drawing into a memory
        /// bitmap.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to draw to the target.</param>
        /// <param name="dx">The x position of the destination.</param>
        /// <param name="dy">The y position of the destination.</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawBitmap(AllegroBitmap bitmap, float dx, float dy, FlipFlags flags)
            => al_draw_bitmap(bitmap.NativeIntPtr, dx, dy, (int)flags);

        /// <summary>
        /// Like al_draw_bitmap but multiplies all colors in the bitmap with the given color.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw to the target.</param>
        /// <param name="tint">The color to tint the bitmap.</param>
        /// <param name="dx">The x position of the destination.</param>
        /// <param name="dy">The y position of the destination.</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawTintedBitmap(AllegroBitmap bitmap, AllegroColor tint, float dx, float dy, FlipFlags flags)
            => al_draw_tinted_bitmap(bitmap.NativeIntPtr, tint.Native, dx, dy, (int)flags);

        /// <summary>
        /// Draws a region of the given bitmap to the target bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw to the target.</param>
        /// <param name="sx">Source X position.</param>
        /// <param name="sy">Source Y position.</param>
        /// <param name="sw">Source width.</param>
        /// <param name="sh">Source height.</param>
        /// <param name="dx">Destination X position.</param>
        /// <param name="dy">Destination Y position.</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawBitmapRegion(AllegroBitmap bitmap, float sx, float sy, float sw, float sh, float dx, float dy, FlipFlags flags)
            => al_draw_bitmap_region(bitmap.NativeIntPtr, sx, sy, sw, sh, dx, dy, (int)flags);

        /// <summary>
        /// Like al_draw_bitmap_region but multiplies all colors in the bitmap with the given color.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw to the target.</param>
        /// <param name="tint">The tint color.</param>
        /// <param name="sx">Source X position.</param>
        /// <param name="sy">Source Y position.</param>
        /// <param name="sw">Source width.</param>
        /// <param name="sh">Source height.</param>
        /// <param name="dx">Destination X position.</param>
        /// <param name="dy">Destination Y position.</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawTintedBitmapRegion(AllegroBitmap bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, FlipFlags flags)
            => al_draw_tinted_bitmap_region(bitmap.NativeIntPtr, tint.Native, sx, sy, sw, sh, dx, dy, (int)flags);

        /// <summary>
        /// Draws a single pixel at x, y. This function, unlike al_put_pixel, does blending and, unlike
        /// al_put_blended_pixel, respects the transformations (that is, the pixel’s position is transformed, but
        /// its size is unaffected - it remains a pixel). This function can be slow if called often; if you need
        /// to draw a lot of pixels consider using al_draw_prim with ALLEGRO_PRIM_POINT_LIST from the primitives
        /// addon.
        /// <para>
        /// Note: This function may not draw exactly where you expect it to. See the pixel-precise output section on
        /// the primitives addon documentation for details on how to control exactly where the pixel is drawn.
        /// </para>
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        /// <param name="color">The pixel color to draw.</param>
        public static void DrawPixel(float x, float y, AllegroColor color)
            => al_draw_pixel(x, y, color.Native);

        /// <summary>
        /// Draws a rotated version of the given bitmap to the target bitmap. The bitmap is rotated by ‘angle’ radians
        /// clockwise.
        /// <para>
        /// The point at cx/cy relative to the upper left corner of the bitmap will be drawn at dx/dy and the bitmap is
        /// rotated around this point. If cx,cy is 0,0 the bitmap will rotate around its upper left corner.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to draw.</param>
        /// <param name="cx">The center X position.</param>
        /// <param name="cy">The center Y position.</param>
        /// <param name="dx">The destination X position.</param>
        /// <param name="dy">The destination Y position.</param>
        /// <param name="angle">The angle in radians (clockwise).</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawRotatedBitmap(AllegroBitmap bitmap, float cx, float cy, float dx, float dy, float angle, FlipFlags flags)
            => al_draw_rotated_bitmap(bitmap.NativeIntPtr, cx, cy, dx, dy, angle, (int)flags);

        /// <summary>
        /// Like al_draw_rotated_bitmap but multiplies all colors in the bitmap with the given color.
        /// <para>
        /// See al_draw_bitmap for a note on restrictions on which bitmaps can be drawn where.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to draw.</param>
        /// <param name="tint">The color tint.</param>
        /// <param name="cx">The center X position.</param>
        /// <param name="cy">The center Y position.</param>
        /// <param name="dx">The destination X position.</param>
        /// <param name="dy">The destination Y position.</param>
        /// <param name="angle">The angle in radians (clockwise).</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawTintedRotatedBitmap(AllegroBitmap bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float angle, FlipFlags flags)
            => al_draw_tinted_rotated_bitmap(bitmap.NativeIntPtr, tint.Native, cx, cy, dx, dy, angle, (int)flags);

        /// <summary>
        /// Like al_draw_rotated_bitmap, but can also scale the bitmap.
        /// <para>
        /// The point at cx/cy in the bitmap will be drawn at dx/dy and the bitmap is rotated and scaled around this point.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to draw.</param>
        /// <param name="cx">The center X position.</param>
        /// <param name="cy">The center Y position.</param>
        /// <param name="dx">The destination X position.</param>
        /// <param name="dy">The destination Y position.</param>
        /// <param name="xScale">The X axis scale (ex: 2 for twice the size).</param>
        /// <param name="yScale">the Y axis scale (ex: 2 for twice the size).</param>
        /// <param name="angle">The angle in radians (clockwise).</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawScaledRotatedBitmap(AllegroBitmap bitmap, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
            => al_draw_scaled_rotated_bitmap(bitmap.NativeIntPtr, cx, cy, dx, dy, xScale, yScale, angle, (int)flags);

        /// <summary>
        /// Like al_draw_scaled_rotated_bitmap but multiplies all colors in the bitmap with the given color.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw.</param>
        /// <param name="tint">The tint color.</param>
        /// <param name="cx">The center X position.</param>
        /// <param name="cy">The center Y position.</param>
        /// <param name="dx">The destination X position.</param>
        /// <param name="dy">The destination Y position.</param>
        /// <param name="xScale">The X axis scale (ex: 2 for twice the size).</param>
        /// <param name="yScale">the Y axis scale (ex: 2 for twice the size).</param>
        /// <param name="angle">The angle in radians (clockwise).</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawTintedScaledRotatedBitmap(AllegroBitmap bitmap, AllegroColor tint, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
            => al_draw_tinted_scaled_rotated_bitmap(bitmap.NativeIntPtr, tint.Native, cx, cy, dx, dy, xScale, yScale, angle, (int)flags);

        /// <summary>
        /// Like al_draw_tinted_scaled_rotated_bitmap but you specify an area within the bitmap to be drawn.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw.</param>
        /// <param name="sx">Source X position.</param>
        /// <param name="sy">Source Y position.</param>
        /// <param name="sw">Source width.</param>
        /// <param name="sh">Source height.</param>
        /// <param name="tint">The tint color.</param>
        /// <param name="cx">The center X position.</param>
        /// <param name="cy">The center Y position.</param>
        /// <param name="dx">The destination X position.</param>
        /// <param name="dy">The destination Y position.</param>
        /// <param name="xScale">The X axis scale (ex: 2 for twice the size).</param>
        /// <param name="yScale">the Y axis scale (ex: 2 for twice the size).</param>
        /// <param name="angle">The angle in radians (clockwise).</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawTintedScaledRotatedBitmapRegion(AllegroBitmap bitmap, float sx, float sy, float sw, float sh, AllegroColor tint, float cx, float cy, float dx, float dy, float xScale, float yScale, float angle, FlipFlags flags)
            => al_draw_tinted_scaled_rotated_bitmap_region(bitmap.NativeIntPtr, sx, sy, sw, sh, tint.Native, cx, cy, dx, dy, xScale, yScale, angle, (int)flags);

        /// <summary>
        /// Draws a scaled version of the given bitmap to the target bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw.</param>
        /// <param name="sx">Source X position.</param>
        /// <param name="sy">Source Y position.</param>
        /// <param name="sw">Source width.</param>
        /// <param name="sh">Source height.</param>
        /// <param name="dx">The destination X position.</param>
        /// <param name="dy">The destination Y position.</param>
        /// <param name="dw">The destination width.</param>
        /// <param name="dh">The destination height.</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawScaledBitmap(AllegroBitmap bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, FlipFlags flags)
            => al_draw_scaled_bitmap(bitmap.NativeIntPtr, sx, sy, sw, sh, dx, dy, dw, dh, (int)flags);

        /// <summary>
        /// Like al_draw_scaled_bitmap but multiplies all colors in the bitmap with the given color.
        /// </summary>
        /// <param name="bitmap">The bitmap to draw.</param>
        /// <param name="tint">The tint color</param>
        /// <param name="sx">Source X position.</param>
        /// <param name="sy">Source Y position.</param>
        /// <param name="sw">Source width.</param>
        /// <param name="sh">Source height.</param>
        /// <param name="dx">The destination X position.</param>
        /// <param name="dy">The destination Y position.</param>
        /// <param name="dw">The destination width.</param>
        /// <param name="dh">The destination height.</param>
        /// <param name="flags">The flip flags.</param>
        public static void DrawTintedScaledBitmap(AllegroBitmap bitmap, AllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, FlipFlags flags)
            => al_draw_tinted_scaled_bitmap(bitmap.NativeIntPtr, tint.Native, sx, sy, sw, sh, dx, dy, dw, dh, (int)flags);

        /// <summary>
        /// Return the target bitmap of the calling thread.
        /// </summary>
        /// <returns>The target bitmap of the calling thread.</returns>
        public static AllegroBitmap GetTargetBitmap()
        {
            var nativeBitmap = al_get_target_bitmap();
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Draw a single pixel on the target bitmap. This operation is slow on non-memory bitmaps. Consider locking
        /// the bitmap if you are going to use this function multiple times on the same bitmap. This function is not
        /// affected by the transformations or the color blenders.
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        /// <param name="color">The color to put.</param>
        public static void PutPixel(int x, int y, AllegroColor color)
            => al_put_pixel(x, y, color.Native);

        /// <summary>
        /// Like al_put_pixel, but the pixel color is blended using the current blenders before being drawn.
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        /// <param name="color">The color to put that will be blended.</param>
        public static void PutBlendedPixel(int x, int y, AllegroColor color)
            => al_put_blended_pixel(x, y, color.Native);

        /// <summary>
        /// This function selects the bitmap to which all subsequent drawing operations in the calling thread
        /// will draw to. To return to drawing to a display, set the backbuffer of the display as the target
        /// bitmap, using al_get_backbuffer. As a convenience, you may also use al_set_target_backbuffer.
        /// <para>
        /// Each allegro bitmap maintains two transformation matrices associated with it for drawing onto the
        /// bitmap. There is a view matrix and a projection matrix. When you call al_set_target_bitmap, these
        /// will be made current for the bitmap, affecting global OpenGL and DirectX states depending on the
        /// driver in use.
        /// </para>
        /// <para>
        /// Each video bitmap is tied to a display. When a video bitmap is set to as the target bitmap, the display
        /// that the bitmap belongs to is automatically made “current” for the calling thread (if it is not current
        /// already). Then drawing other bitmaps which are tied to the same display can be hardware accelerated.
        /// </para>
        /// <para>
        /// A single display cannot be current for multiple threads simultaneously. If you need to release a display,
        /// so it is not current for the calling thread, call al_set_target_bitmap(NULL);
        /// </para>
        /// <para>
        /// Setting a memory bitmap as the target bitmap will not change which display is current for the calling
        /// thread.
        /// </para>
        /// <para>
        /// On some platforms, Allegro automatically backs up the contents of video bitmaps because they may be
        /// occasionally lost (see discussion in al_create_bitmap’s documentation). If you’re completely recreating
        /// the bitmap contents often (e.g. every frame) then you will get much better performance by creating the
        /// target bitmap with ALLEGRO_NO_PRESERVE_TEXTURE flag.
        /// </para>
        /// <para>
        /// OpenGL Note: Framebuffer objects (FBOs) allow OpenGL to directly draw to a bitmap, which is very fast. When
        /// using an OpenGL display, if all of the following conditions are met an FBO will be created for use with the
        /// bitmap:
        /// </para>
        /// <para>
        /// The GL_EXT_framebuffer_object OpenGL extension is available, The bitmap is not a memory bitmap, The bitmap
        /// is not a memory bitmap.
        /// </para>
        /// <para>
        /// In Allegro 5.0.0, you had to be careful as an FBO would be kept around until the bitmap is destroyed or you
        /// explicitly called al_remove_opengl_fbo on the bitmap, wasting resources. In newer versions, FBOs will be
        /// freed automatically when the bitmap is no longer the target bitmap, unless you have called
        /// al_get_opengl_fbo to retrieve the FBO id.
        /// </para>
        /// </summary>
        /// <param name="bitmap">The bitmap to set as the drawing target for the calling thread.</param>
        public static void SetTargetBitmap(AllegroBitmap bitmap)
            => al_set_target_bitmap(bitmap.NativeIntPtr);

        /// <summary>
        /// Same as al_set_target_bitmap(al_get_backbuffer(display));
        /// </summary>
        /// <param name="display">The display whose backbuffer will be set as the target for the calling thread.</param>
        public static void SetTargetBackbuffer(AllegroDisplay display)
            => al_set_target_backbuffer(display.NativeIntPtr);

        /// <summary>
        /// Return the display that is “current” for the calling thread, or NULL if there is none.
        /// </summary>
        /// <returns>The display that is “current” for the calling thread, or NULL if there is none.</returns>
        public static AllegroDisplay GetCurrentDisplay()
        {
            var nativeDisplay = al_get_current_display();
            return nativeDisplay == IntPtr.Zero ? null : new AllegroDisplay { NativeIntPtr = nativeDisplay };
        }

        /// <summary>
        /// Returns the active blender for the current thread. You can pass NULL for values you are not interested in.
        /// </summary>
        /// <param name="operation">The blend operation.</param>
        /// <param name="source">The blend mode for source.</param>
        /// <param name="destination">The blend mode for destination.</param>
        public static void GetBlender(ref BlendOperation operation, ref BlendMode source, ref BlendMode destination)
        {
            var nOp = (int)operation;
            var nSrc = (int)source;
            var nDst = (int)destination;
            al_get_blender(ref nOp, ref nSrc, ref nDst);
            operation = (BlendOperation)nOp;
            source = (BlendMode)nSrc;
            destination = (BlendMode)nDst;
        }

        /// <summary>
        /// Returns the active blender for the current thread. You can pass NULL for values you are not interested in.
        /// </summary>
        /// <param name="operation">The blend operation.</param>
        /// <param name="source">The blend mode for source.</param>
        /// <param name="destination">The blend mode for destination.</param>
        /// <param name="alphaOp">The alpha blend operation.</param>
        /// <param name="alphaSource">The blend mode for source alpha.</param>
        /// <param name="alphaDestination">The blend mode for source alpha.</param>
        public static void GetSeparateBlender(ref BlendOperation operation, ref BlendMode source, ref BlendMode destination, ref BlendOperation alphaOp, ref BlendMode alphaSource, ref BlendMode alphaDestination)
        {
            var nOp = (int)operation;
            var nSrc = (int)source;
            var nDst = (int)destination;
            var nAlphaOp = (int)alphaOp;
            var nAlphaSrc = (int)alphaSource;
            var nAlphaDst = (int)alphaDestination;
            al_get_separate_blender(ref nOp, ref nSrc, ref nDst, ref nAlphaOp, ref nAlphaSrc, ref nAlphaDst);
            operation = (BlendOperation)nOp;
            source = (BlendMode)nSrc;
            destination = (BlendMode)nDst;
            alphaOp = (BlendOperation)nAlphaOp;
            alphaSource = (BlendMode)nAlphaSrc;
            alphaDestination = (BlendMode)nAlphaDst;
        }

        /// <summary>
        /// Returns the color currently used for constant color blending (white by default).
        /// </summary>
        /// <returns>The color currently used for constant color blending (white by default).</returns>
        public static AllegroColor GetBlendColor()
            => new AllegroColor { Native = al_get_blend_color() };

        /// <summary>
        /// Sets the function to use for blending for the current thread. Blending means, the source and destination
        /// colors are combined in drawing operations.
        /// </summary>
        /// <param name="operation">The blend operation.</param>
        /// <param name="source">The blend mode for source.</param>
        /// <param name="destination">The blend mode for destination.</param>
        public static void SetBlender(BlendOperation operation, BlendMode source, BlendMode destination)
            => al_set_blender((int)operation, (int)source, (int)destination);

        /// <summary>
        /// Like al_set_blender, but allows specifying a separate blending operation for the alpha channel. This is
        /// useful if your target bitmap also has an alpha channel and the two alpha channels need to be combined
        /// in a different way than the color components.
        /// </summary>
        /// <param name="operation">The blend operation.</param>
        /// <param name="source">The blend mode for source.</param>
        /// <param name="destination">The blend mode for destination.</param>
        /// <param name="alphaOperation">The alpha blend operation.</param>
        /// <param name="alphaSource">The blend mode for source alpha.</param>
        /// <param name="alphaDestination">The blend mode for source alpha.</param>
        public static void SetSeparateBlender(BlendOperation operation, BlendMode source, BlendMode destination, BlendOperation alphaOperation, BlendMode alphaSource, BlendMode alphaDestination)
            => al_set_separate_blender((int)operation, (int)source, (int)destination, (int)alphaOperation, (int)alphaSource, (int)alphaDestination);

        /// <summary>
        /// Sets the color to use for blending when using the ALLEGRO_CONST_COLOR or ALLEGRO_INVERSE_CONST_COLOR
        /// blend functions. See al_set_blender for more information.
        /// </summary>
        /// <param name="color">The color to use for blending.</param>
        public static void SetBlendColor(AllegroColor color)
            => al_set_blend_color(color.Native);

        /// <summary>
        /// Gets the clipping rectangle of the target bitmap.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="w">Width.</param>
        /// <param name="h">Height.</param>
        public static void GetClippingRectangle(ref int x, ref int y, ref int w, ref int h)
            => al_get_clipping_rectangle(ref x, ref y, ref w, ref h);

        /// <summary>
        /// Set the region of the target bitmap or display that pixels get clipped to. The default is to clip pixels to the entire bitmap.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        public static void SetClippingRectangle(int x, int y, int width, int height)
            => al_set_clipping_rectangle(x, y, width, height);

        /// <summary>
        /// Equivalent to calling `al_set_clipping_rectangle(0, 0, w, h)’ where w and h are the width and height
        /// of the target bitmap respectively.
        /// </summary>
        public static void ResetClippingRectangle()
            => al_reset_clipping_rectangle();

        /// <summary>
        /// Convert the given mask color to an alpha channel in the bitmap. Can be used to convert older 4.2-style
        /// bitmaps with magic pink to alpha-ready bitmaps.
        /// </summary>
        /// <param name="bitmap">The bitmap to add an alpha mask to.</param>
        /// <param name="maskColor">The color to make the alpha mask from.</param>
        public static void ConvertMaskToAlpha(AllegroBitmap bitmap, AllegroColor maskColor)
            => al_convert_mask_to_alpha(bitmap.NativeIntPtr, maskColor.Native);

        /// <summary>
        /// Enables or disables deferred bitmap drawing. This allows for efficient drawing of many bitmaps that share
        /// a parent bitmap, such as sub-bitmaps from a tilesheet or simply identical bitmaps. Drawing bitmaps that
        /// do not share a parent is less efficient, so it is advisable to stagger bitmap drawing calls such that the
        /// parent bitmap is the same for large number of those calls. While deferred bitmap drawing is enabled, the
        /// only functions that can be used are the bitmap drawing functions and font drawing functions. Changing the
        /// state such as the blending modes will result in undefined behaviour. One exception to this rule are the
        /// non-projection transformations. It is possible to set a new transformation while the drawing is held.
        /// <para>
        /// No drawing is guaranteed to take place until you disable the hold. Thus, the idiom of this function’s
        /// usage is to enable the deferred bitmap drawing, draw as many bitmaps as possible, taking care to stagger
        /// bitmaps that share parent bitmaps, and then disable deferred drawing. As mentioned above, this function
        /// also works with bitmap and truetype fonts, so if multiple lines of text need to be drawn, this function
        /// can speed things up.
        /// </para>
        /// </summary>
        /// <param name="hold">True to enable holding, false to disable.</param>
        public static void HoldBitmapDrawing(bool hold)
            => al_hold_bitmap_drawing(hold);

        /// <summary>
        /// Returns whether the deferred bitmap drawing mode is turned on or off.
        /// </summary>
        /// <returns>Whether the deferred bitmap drawing mode is turned on or off.</returns>
        public static bool IsBitmapDrawingHeld()
            => al_is_bitmap_drawing_held();

        /// <summary>
        /// Register a handler for al_load_bitmap. The given function will be used to handle the loading of bitmaps
        /// files with the given extension.
        /// <para>
        /// The extension should include the leading dot (‘.’) character. It will be matched case-insensitively.
        /// The loader argument may be NULL to unregister an entry.
        /// Returns true on success, false on error. Returns false if unregistering an entry that doesn’t exist.
        /// </para>
        /// </summary>
        /// <param name="extension">The extension of the bitmap file.</param>
        /// <param name="loader">The method to load the bitmap file type.</param>
        /// <returns>True on success, false on error. Returns false if unregistering an entry that doesn’t exist.</returns>
        public static bool RegisterBitmapLoader(string extension, IntPtr loader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Register a handler for al_save_bitmap. The given function will be used to handle the saving of bitmaps
        /// files with the given extension.
        /// <para>
        /// The extension should include the leading dot (‘.’) character. It will be matched case-insensitively.
        /// The saver argument may be NULL to unregister an entry.
        /// Returns true on success, false on error. Returns false if unregistering an entry that doesn’t exist.
        /// </para>
        /// </summary>
        /// <param name="extension">The extension of the bitmap file.</param>
        /// <param name="saver">The method to save the bitmap file type.</param>
        /// <returns>True on success, false on error. Returns false if unregistering an entry that doesn’t exist.</returns>
        public static bool RegisterBitmapSaver(string extension, IntPtr saver)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Register a handler for al_load_bitmap. The given function will be used to handle the loading of bitmaps
        /// files with the given extension.
        /// <para>
        /// The extension should include the leading dot (‘.’) character. It will be matched case-insensitively.
        /// The loader argument may be NULL to unregister an entry.
        /// Returns true on success, false on error. Returns false if unregistering an entry that doesn’t exist.
        /// </para>
        /// </summary>
        /// <param name="extension">The extension of the bitmap file.</param>
        /// <param name="loader">The method to load the bitmap file type.</param>
        /// <returns>True on success, false on error. Returns false if unregistering an entry that doesn’t exist.</returns>
        public static bool RegisterBitmapLoaderF(string extension, IntPtr loader)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Register a handler for al_save_bitmap. The given function will be used to handle the saving of bitmaps
        /// files with the given extension.
        /// <para>
        /// The extension should include the leading dot (‘.’) character. It will be matched case-insensitively.
        /// The saver argument may be NULL to unregister an entry.
        /// Returns true on success, false on error. Returns false if unregistering an entry that doesn’t exist.
        /// </para>
        /// </summary>
        /// <param name="extension">The extension of the bitmap file.</param>
        /// <param name="saver">The method to save the bitmap file type.</param>
        /// <returns>True on success, false on error. Returns false if unregistering an entry that doesn’t exist.</returns>
        public static bool RegisterBitmapSaverF(string extension, IntPtr saver)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads an image file into a new ALLEGRO_BITMAP. The file type is determined by the extension, except if the
        /// file has no extension in which case al_identify_bitmap is used instead.
        /// <para>
        /// This is the same as calling al_load_bitmap_flags with a flags parameter of 0.
        /// Note: the core Allegro library does not support any image file formats by default. You must use the
        /// allegro_image addon, or register your own format handler.
        /// </para>
        /// </summary>
        /// <param name="filename">The filename to load.</param>
        /// <returns>Null on error, otherwise the loaded bitma instance.</returns>
        public static AllegroBitmap LoadBitmap(string filename)
        {
            var nativeBitmap = al_load_bitmap(filename);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Loads an image file into a new ALLEGRO_BITMAP. The file type is determined by the extension, except if
        /// the file has no extension in which case al_identify_bitmap is used instead.
        /// </summary>
        /// <param name="filename">The filename to load.</param>
        /// <param name="flags">The flag to load the bitmap.</param>
        /// <returns>Null on error, otherwise the loaded bitmap instance..</returns>
        public static AllegroBitmap LoadBitmapFlags(string filename, BitmapLoadFlags flags)
        {
            var nativeBitmap = al_load_bitmap_flags(filename, (int)flags);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Loads an image from an ALLEGRO_FILE stream into a new ALLEGRO_BITMAP. The file type is determined by the
        /// passed ‘ident’ parameter, which is a file name extension including the leading dot. If (and only if)
        /// ‘ident’ is NULL, the file type is determined with al_identify_bitmap_f instead.
        /// <para>
        /// This is the same as calling al_load_bitmap_flags_f with 0 for the flags parameter.
        /// </para>
        /// </summary>
        /// <param name="file">The <see cref="AllegroFile"/> instance to a file.</param>
        /// <param name="identity">The extension of the file type, including the leading dot.</param>
        /// <returns>Null on error, otherwise the loaded bitmap instance.</returns>
        public static AllegroBitmap LoadBitmapF(AllegroFile file, string identity)
        {
            var nativeBitmap = al_load_bitmap_f(file.NativeIntPtr, identity);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Loads an image from an ALLEGRO_FILE stream into a new ALLEGRO_BITMAP. The file type is determined by
        /// the passed ‘ident’ parameter, which is a file name extension including the leading dot. If (and only if)
        /// ‘ident’ is NULL, the file type is determined with al_identify_bitmap_f instead.
        /// <para>
        /// The flags parameter is the same as for al_load_bitmap_flags.
        /// </para>
        /// <para>
        /// Returns NULL on error. The file remains open afterwards.
        /// </para>
        /// </summary>
        /// <param name="file">The <see cref="AllegroFile"/> instance to a file.</param>
        /// <param name="identity">The extension of the file type, including the leading dot.</param>
        /// <param name="flags">The flag to load the bitmap.</param>
        /// <returns>Null on error, otherwise the loaded bitmap instance.</returns>
        public static AllegroBitmap LoadBitmapFlagsF(AllegroFile file, string identity, BitmapLoadFlags flags)
        {
            var nativeBitmap = al_load_bitmap_flags_f(file.NativeIntPtr, identity, (int)flags);
            return nativeBitmap == IntPtr.Zero ? null : new AllegroBitmap { NativeIntPtr = nativeBitmap };
        }

        /// <summary>
        /// Saves an ALLEGRO_BITMAP to an image file. The file type is determined by the extension.
        /// </summary>
        /// <param name="filename">The filename to save the bitmap to.</param>
        /// <param name="bitmap">The bitmap instance to save.</param>
        /// <returns>True on success, false on error.</returns>
        public static bool SaveBitmap(string filename, AllegroBitmap bitmap)
            => al_save_bitmap(filename, bitmap.NativeIntPtr);

        /// <summary>
        /// Saves an ALLEGRO_BITMAP to an ALLEGRO_FILE stream. The file type is determined by the passed ‘ident’
        /// parameter, which is a file name extension including the leading dot.
        /// </summary>
        /// <param name="file">The <see cref="AllegroFile"/> instance to a file.</param>
        /// <param name="identity">The extension of the file type, including the leading dot.</param>
        /// <param name="bitmap">The bitmap instance to save.</param>
        /// <returns>True on success, false on error. The file remains open afterwards.</returns>
        public static bool SaveBitmapF(AllegroFile file, string identity, AllegroBitmap bitmap)
            => al_save_bitmap_f(file.NativeIntPtr, identity, bitmap.NativeIntPtr);

        /// <summary>
        /// Register an identify handler for al_identify_bitmap. The given function will be used to detect files for
        /// the given extension. It will be called with a single argument of type ALLEGRO_FILE which is a file handle
        /// opened for reading and located at the first byte of the file. The handler should try to read as few
        /// bytes as possible to safely determine if the given file contents correspond to the type with the extension
        /// and return true in that case, false otherwise. The file handle must not be closed but there is no need to
        /// reset it to the beginning.
        /// <para>
        /// The extension should include the leading dot (‘.’) character. It will be matched case-insensitively.
        /// </para>
        /// <para>
        /// The identifier argument may be NULL to unregister an entry.
        /// </para>
        /// </summary>
        /// <param name="extension">The extension of the bitmap.</param>
        /// <param name="identifier">The method to identify a bitmap.</param>
        /// <returns>True on success, false on error. Returns false if unregistering an entry that doesn’t exist.</returns>
        public static bool RegisterBitmapIdentifier(string extension, IntPtr identifier)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This works exactly as al_identify_bitmap_f but you specify the filename of the file for which to detect the
        /// type and not a file handle. The extension, if any, of the passed filename is not taken into account - only
        /// the file contents.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The bitmap identity.</returns>
        public static string IdentifyBitmap(string filename)
            => Marshal.PtrToStringAnsi(al_identify_bitmap(filename));

        /// <summary>
        /// Tries to guess the bitmap file type of the open ALLEGRO_FILE by reading the first few bytes. By default
        /// Allegro cannot recognize any file types, but calling al_init_image_addon will add detection of (some of)
        /// the types it can read. You can also use al_register_bitmap_identifier to add identification for custom file
        /// types.
        /// </summary>
        /// <param name="file">The file instance to identify the bitmap from.</param>
        /// <returns>
        /// Returns a pointer to a static string with a file extension for the type, including the leading
        /// dot. For example “.png” or “.jpg”. Returns NULL if the bitmap type cannot be determined.
        /// </returns>
        public static string IdentifyBitmapF(AllegroFile file)
            => Marshal.PtrToStringAnsi(al_identify_bitmap_f(file.NativeIntPtr));

        /// <summary>
        /// Set one of several render attributes; see ALLEGRO_RENDER_STATE for details.
        /// This function does nothing if the target bitmap is a memory bitmap.
        /// </summary>
        /// <param name="state">The render state.</param>
        /// <param name="value">The value of the render state.</param>
        public static void SetRenderState(RenderState state, int value)
            => al_set_render_state((int)state, value);

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_map_rgb(byte r, byte g, byte b);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_map_rgb_f(float r, float g, float b);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_map_rgba(byte r, byte g, byte b, byte a);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_premul_rgba(byte r, byte g, byte b, byte a);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_map_rgba_f(float r, float g, float b, float a);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_premul_rgba_f(float r, float g, float b, float a);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_unmap_rgb(NativeAllegroColor color, ref byte r, ref byte g, ref byte b);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_unmap_rgb_f(NativeAllegroColor color, ref float r, ref float g, ref float b);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_unmap_rgba(NativeAllegroColor color, ref byte r, ref byte g, ref byte b, ref byte a);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_unmap_rgba_f(NativeAllegroColor color, ref float r, ref float g, ref float b, ref float a);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_pixel_size(int format);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_pixel_format_bits(int format);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_pixel_block_size(int format);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_pixel_block_width(int format);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_pixel_block_height(int format);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeLockedRegion al_lock_bitmap(IntPtr bitmap, int format, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeLockedRegion al_lock_bitmap_region(IntPtr bitmap, int x, int y, int width, int height, int format, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_unlock_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeLockedRegion al_lock_bitmap_blocked(IntPtr bitmap, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeLockedRegion al_lock_bitmap_region_blocked(IntPtr bitmap, int x, int y, int width, int height, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_bitmap(int w, int h);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_sub_bitmap(IntPtr parent, int x, int y, int w, int h);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_clone_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_convert_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_convert_memory_bitmaps();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_new_bitmap_flags();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_new_bitmap_format();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_new_bitmap_flags(int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_add_new_bitmap_flag(int flag);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_new_bitmap_format(int format);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_bitmap_flags(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_bitmap_format(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_bitmap_height(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_bitmap_width(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_get_pixel(IntPtr bitmap, int x, int y);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_bitmap_locked(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_compatible_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_sub_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_parent_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_bitmap_x(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_bitmap_y(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_reparent_bitmap(IntPtr bitmap, IntPtr parent, int x, int y, int w, int h);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_clear_to_color(NativeAllegroColor color);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_clear_depth_buffer(float z);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_bitmap(IntPtr bitmap, float dx, float dy, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_tinted_bitmap(IntPtr bitmap, NativeAllegroColor tint, float dx, float dy, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_tinted_bitmap_region(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_pixel(float x, float y, NativeAllegroColor color);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float angle, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_tinted_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float angle, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_scaled_rotated_bitmap(IntPtr bitmap, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_tinted_scaled_rotated_bitmap(IntPtr bitmap, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_tinted_scaled_rotated_bitmap_region(IntPtr bitmap, float sx, float sy, float sw, float sh, NativeAllegroColor tint, float cx, float cy, float dx, float dy, float xscale, float yscale, float angle, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_scaled_bitmap(IntPtr bitmap, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_tinted_scaled_bitmap(IntPtr bitmap, NativeAllegroColor tint, float sx, float sy, float sw, float sh, float dx, float dy, float dw, float dh, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_target_bitmap();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_put_pixel(int x, int y, NativeAllegroColor color);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_put_blended_pixel(int x, int y, NativeAllegroColor color);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_target_bitmap(IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_target_backbuffer(IntPtr display);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_current_display();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_get_blender(ref int op, ref int src, ref int dst);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_get_separate_blender(ref int op, ref int src, ref int dst, ref int alphaOp, ref int alphaSrc, ref int alphaDst);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern NativeAllegroColor al_get_blend_color();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_blender(int op, int src, int dst);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_separate_blender(int op, int src, int dst, int alphaOp, int alphaSrc, int alphaDst);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_blend_color(NativeAllegroColor color);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_get_clipping_rectangle(ref int x, ref int y, ref int w, ref int h);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_clipping_rectangle(int x, int y, int width, int height);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_reset_clipping_rectangle();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_convert_mask_to_alpha(IntPtr bitmap, NativeAllegroColor maskColor);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_hold_bitmap_drawing(bool hold);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_bitmap_drawing_held();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_bitmap_loader(IntPtr extension, IntPtr loader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_bitmap_saver(IntPtr extension, IntPtr saver);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_bitmap_loader_f(IntPtr extension, IntPtr fsLoader);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_bitmap_saver_f(IntPtr extension, IntPtr fsSaver);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_bitmap_flags(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_bitmap_f(IntPtr fp, [MarshalAs(UnmanagedType.LPStr)] string ident);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_bitmap_flags_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_save_bitmap(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_save_bitmap_f(
            IntPtr fp,
            [MarshalAs(UnmanagedType.LPStr)] string ident,
            IntPtr bitmap);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_bitmap_identifier(
            [MarshalAs(UnmanagedType.LPStr)] string extension,
            IntPtr identifier);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_identify_bitmap([MarshalAs(UnmanagedType.LPStr)] string filename);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_identify_bitmap_f(IntPtr fp);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_render_state(int state, int value);
        #endregion
    }
}
