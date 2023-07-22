using SubC.AllegroDotNet.Enums;

namespace SubC.AllegroDotNet.Models;

/// <summary>
/// This class holds the data of a locked bitmap [region].
/// </summary>
public sealed class AllegroLockedRegion : NativeStruct<Native.Structs.AllegroLockedRegion>
{
  /// <summary>
  /// Gets or sets the left-most pixel of the first row (row 0) of the locked region. For blocked formats,
  /// this points to the left-most block of the first row of blocks.
  /// </summary>
  public IntPtr Data
  {
    get => Struct.data;
    set => Struct.data = value;
  }

  /// <summary>
  /// Gets or sets the pixel format of the data.
  /// </summary>
  public PixelFormat PixelFormat
  {
    get => (PixelFormat)Struct.format;
    set => Struct.format = (int)value;
  }

  /// <summary>
  /// Gets or sets the the size in bytes of a single row (also known as the stride). The pitch may be greater than
  /// width * <see cref="PixelSize"/> due to padding; this is not uncommon. It is also not uncommon for the pitch to
  /// be negative (the bitmap may be upside down). For blocked formats, ‘row’ refers to the row of blocks,
  /// not of pixels.
  /// </summary>
  public int Pitch
  {
    get => Struct.pitch;
    set => Struct.pitch = value;
  }

  /// <summary>
  /// Gets or sets the the number of bytes used to represent a single block of pixels for the pixel format of this
  /// locked region. For most formats (and historically, this used to be true for all formats), this is just the size
  /// of a single pixel, but for blocked pixel formats this value is different.
  /// </summary>
  public int PixelSize
  {
    get => Struct.pixel_size;
    set => Struct.pixel_size = value;
  }
}