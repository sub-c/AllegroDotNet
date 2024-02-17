namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// <para>
/// Pixel formats. Each pixel format specifies the exact size and bit layout of a pixel in memory.
/// Components are specified from high bits to low bits, so for example a fully opaque red pixel in ARGB_8888 format
/// is 0xFFF0000.
/// </para>
/// <para>
/// Also note that Allegro’s naming is different from OpenGL naming here, where a format of GL_RGBA8 merely defines
/// the component order and the exact layout including endianness treatment is specified separately. Usually GL_RGBA8
/// will correspond to ALLEGRO_PIXEL_ABGR_8888 though on little endian systems, so care must be taken (note the
/// reversal of RGBA - ABGR).
/// </para>
/// <para>
/// The only exception to this ALLEGRO_PIXEL_FORMAT_ABGR_8888_LE which will always have the components as 4 bytes
/// corresponding to red, green, blue and alpha, in this order, independent of the endianness.
/// </para>
/// <para>
/// Some of the pixel formats represent compressed bitmap formats. Compressed bitmaps take up less space in the GPU
/// memory than bitmaps with regular (uncompressed) pixel formats. This smaller footprint means that you can load more
/// resources into GPU memory, and they will be drawn somewhat faster. The compression is lossy, however, so it is not
/// appropriate for all graphical styles: it tends to work best for images with smooth color gradations. It is possible
/// to compress bitmaps at runtime by passing the appropriate bitmap format in al_set_new_bitmap_format and then
/// creating, loading, cloning or converting a non-compressed bitmap. This, however, is not recommended as the
/// compression quality differs between different GPU drivers. It is recommended to compress these bitmaps ahead
/// of time using external tools and then load them compressed.
/// </para>
/// <para>
/// Unlike regular pixel formats, compressed pixel formats are not laid out in memory one pixel row at a time.
/// Instead, the bitmap is subdivided into rectangular blocks of pixels that are then laid out in block rows. This
/// means that regular locking functions cannot use compressed pixel formats as the destination format. Instead,
/// you can use the blocked versions of the bitmap locking functions which do support these formats.
/// </para>
/// <para>
/// It is not recommended to use compressed bitmaps as target bitmaps, as that operation cannot be hardware
/// accelerated. Due to proprietary algorithms used, it is typically impossible to create compressed memory bitmaps.
/// </para>
/// </summary>
public enum PixelFormat : int
{
  /// <summary>
  /// The default; allowing any pixel format.
  /// </summary>
  Any = 0,

  /// <summary>
  /// Any pixel format that does not have alpha.
  /// </summary>
  AnyNoAlpha = 1,

  /// <summary>
  /// Any pixel format with alpha.
  /// </summary>
  AnyWithAlpha = 2,

  /// <summary>
  /// Any 15-bit format without an alpha.
  /// </summary>
  Any15NoAlpha = 3,

  /// <summary>
  /// Any 16-bit format without an alpha.
  /// </summary>
  Any16NoAlpha = 4,

  /// <summary>
  /// Any 16-bit format with an alpha.
  /// </summary>
  Any16WithAlpha = 5,

  /// <summary>
  /// Any 24-bit format without an alpha.
  /// </summary>
  Any24NoAlpha = 6,

  /// <summary>
  /// Any 32-bit format without an alpha.
  /// </summary>
  Any32NoAlpha = 7,

  /// <summary>
  /// Any 32-bit format with an alpha.
  /// </summary>
  Any32WithAlpha = 8,

  /// <summary>
  /// 32-bit format.
  /// </summary>
  Argb8888 = 9,

  /// <summary>
  /// 32-bit format.
  /// </summary>
  Rgba8888 = 10,

  /// <summary>
  /// 16-bit format.
  /// </summary>
  Argb4444 = 11,

  /// <summary>
  /// 24-bit format.
  /// </summary>
  Rgb888 = 12,

  /// <summary>
  /// 16-bit format.
  /// </summary>
  Rgb565 = 13,

  /// <summary>
  /// 15-bit format.
  /// </summary>
  Rgb555 = 14,

  /// <summary>
  /// 16-bit format.
  /// </summary>
  RgbaA5551 = 15,

  /// <summary>
  /// 16-bit format.
  /// </summary>
  Argb1555 = 16,

  /// <summary>
  /// 32-format.
  /// </summary>
  Abgr8888 = 17,

  /// <summary>
  /// 32-bit format.
  /// </summary>
  Xbgr8888 = 18,

  /// <summary>
  /// 24-bit format.
  /// </summary>
  Bgr888 = 19,

  /// <summary>
  /// 16-bit format.
  /// </summary>
  Bgr565 = 20,

  /// <summary>
  /// 15-bit format.
  /// </summary>
  Bgr555 = 21,

  /// <summary>
  /// 32-bit format.
  /// </summary>
  Rgbx8888 = 22,

  /// <summary>
  /// 32-bit format.
  /// </summary>
  Xrgb8888 = 23,

  /// <summary>
  /// 128-bit format.
  /// </summary>
  AbgrF32 = 24,

  /// <summary>
  /// Little-endian 32-bit format.
  /// </summary>
  Abgr8888LE = 25,

  /// <summary>
  /// 16-bit format.
  /// </summary>
  Rgba4444 = 26,

  /// <summary>
  /// A single 8-bit channel. A pixel value maps onto the red channel when displayed, but it is undefined how it maps
  /// onto green, blue and alpha channels. When drawing to bitmaps of this format, only the red channel is taken into
  /// account. Allegro may have to use fallback methods to render to bitmaps of this format. This pixel format is
  /// mainly intended for storing the color indices of an indexed (paletted) image, usually in conjunction with a
  /// pixel shader that maps indices to RGBA values.
  /// </summary>
  SingleChannel8 = 27,

  /// <summary>
  /// Compressed using the DXT1 compression algorithm. Each 4x4 pixel block is encoded in 64 bytes, resulting in
  /// 6-8x compression ratio. Only a single bit of alpha per pixel is supported.
  /// </summary>
  CompressedRgbaDxt1 = 28,

  /// <summary>
  /// Compressed using the DXT3 compression algorithm. Each 4x4 pixel block is encoded in 128 bytes, resulting in
  /// 4x compression ratio. This format supports sharp alpha transitions.
  /// </summary>
  CompressedRgbaDxt3 = 29,

  /// <summary>
  /// Compressed using the DXT5 compression algorithm. Each 4x4 pixel block is encoded in 128 bytes, resulting in
  /// 4x compression ratio. This format supports smooth alpha transitions.
  /// </summary>
  CompressedRgbaDxt5 = 30
}
