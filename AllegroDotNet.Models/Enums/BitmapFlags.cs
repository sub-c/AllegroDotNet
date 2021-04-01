using System;

namespace AllegroDotNet.Models.Enums
{
    /// <summary>
    /// Flags related to bitmap format.
    /// </summary>
    [Flags]
    public enum BitmapFlags
    {
        /// <summary>
        /// Create a bitmap residing in system memory. Operations on, and with, memory bitmaps will not
        /// be hardware accelerated. However, direct pixel access can be relatively quick compared to
        /// video bitmaps, which depend on the display driver in use.
        /// <para>
        /// Note: Allegro's software rendering routines are currently somewhat unoptimised.
        /// </para>
        /// <para>
        /// Note: Combining ALLEGRO_VIDEO_BITMAP and ALLEGRO_MEMORY_BITMAP flags is invalid.
        /// </para>
        /// </summary>
        MemoryBitmap = 0x0001,

        /// <summary>
        /// Normally, every effort is taken to preserve the contents of bitmaps, since some platforms may
        /// forget them. This can take extra processing time. If you know it doesn't matter if a bitmap keeps
        /// its pixel data, for example when it's a temporary buffer, use this flag to tell Allegro not to
        /// attempt to preserve its contents. 
        /// </summary>
        NoPreserveTexture = 0x0008,

        /// <summary>
        /// When drawing a scaled down version of the bitmap, use linear filtering. This usually looks better.
        /// You can also combine it with the MIPMAP flag for even better quality. 
        /// </summary>
        MinLinear = 0x0040,

        /// <summary>
        /// When drawing a magnified version of a bitmap, use linear filtering. This will cause the picture to get
        /// blurry instead of creating a big rectangle for each pixel. It depends on how you want things to look
        /// like whether you want to use this or not.
        /// </summary>
        MagLinear = 0x0080,

        /// <summary>
        /// This can only be used for bitmaps whose width and height is a power of two. In that case, it will generate
        /// mipmaps and use them when drawing scaled down versions. For example if the bitmap is 64x64, then extra
        /// bitmaps of sizes 32x32, 16x16, 8x8, 4x4, 2x2 and 1x1 will be created always containing a scaled down
        /// version of the original.
        /// </summary>
        MipMap = 0x0100,

        /// <summary>
        /// Creates a bitmap that resides in the video card memory. These types of bitmaps receive the greatest
        /// benefit from hardware acceleration.
        /// <para>
        /// Note: Creating a video bitmap will fail if there is no current display or the current display driver
        /// cannot create the bitmap. The latter will happen if for example the format or dimensions are not
        /// supported.
        /// </para>
        /// <para>
        /// Note: Bitmaps created with this flag will be converted to memory bitmaps when the last display is
        /// destroyed. In most cases it is therefore easier to use the ALLEGRO_CONVERT_BITMAP flag instead.
        /// </para>
        /// <para>
        /// Note: Combining ALLEGRO_VIDEO_BITMAP and ALLEGRO_MEMORY_BITMAP flags is invalid.
        /// </para>
        /// </summary>
        VideoBitmap = 0x0400,

        /// <summary>
        /// This is the default. It will try to create a video bitmap and if that fails create a memory bitmap.
        /// Bitmaps created with this flag when there is no active display will be converted to video bitmaps next
        /// time a display is created. They also will remain video bitmaps if the last display is destroyed and
        /// then another is created again.
        /// <para>
        /// Note: You can combine this flag with ALLEGRO_MEMORY_BITMAP or ALLEGRO_VIDEO_BITMAP to force the initial
        /// type (and fail in the latter case if no video bitmap can be created) - but usually neither of those
        /// combinations is very useful.
        /// </para>
        /// <para>
        /// You can use the display option ALLEGRO_AUTO_CONVERT_BITMAPS to control which displays will try to
        /// auto-convert bitmaps.
        /// </para>
        /// </summary>
        ConvertBitmap = 0x1000
    }
}
