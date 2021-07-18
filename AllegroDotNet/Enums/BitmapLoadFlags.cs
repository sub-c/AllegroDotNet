using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Changes how bitmaps are loaded.
    /// </summary>
    public enum BitmapLoadFlags : int
    {
        /// <summary>
        /// Load the bitmap with defaults.
        /// </summary>
        None = 0,

        /// <summary>
        /// Force the resulting <see cref="AllegroBitmap"/> to use the same format as the file.
        /// </summary>
        KeepBitmapFormat = 0x0002,

        /// <summary>
        /// This flag being set will ensure that images are not loaded with alpha pre-multiplied, but are loaded with
        /// color values direct from the image.
        /// <para>
        /// To draw such an image using regular alpha blending, you would use al_set_blender(ALLEGRO_ADD,
        /// ALLEGRO_ALPHA, ALLEGRO_INVERSE_ALPHA) to set the correct blender. This has some caveats. First,
        /// as mentioned above, drawing such an image can result in less accurate color blending (when drawing
        /// an image with linear filtering on, the edges will be darker than they should be). Second, the behaviour
        /// is somewhat confusing, which is explained in the example below.
        /// </para>
        /// </summary>
        NoPremultipliedAlpha = 0x0200,

        /// <summary>
        /// Load the palette indices of 8-bit .bmp and .pcx files instead of the rgb colors.
        /// </summary>
        KeepIndex = 0x0800
    }
}
