namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// Flags to use when creating bitmaps.
/// </summary>
[Flags]
public enum BitmapFlags : int
{
  /// <summary>
  /// Memory bitmap only, not hardware accelerated.
  /// </summary>
  MemoryBitmap = 0x0001,
  
  /// <summary>
  /// Force locking for rendering operations.
  /// </summary>
  ForceLocking = 0x0004,
  
  /// <summary>
  /// Do not preserve the texture in case of ALT+TAB away from your display. This will improve performance when
  /// used for bitmaps that are written/drawn to every frame such as a buffer. Not recommended for source bitmaps
  /// used to draw with.
  /// </summary>
  NoPreserveTexture = 0x0008,
  
  /// <summary>
  /// Minimum linear filtering.
  /// </summary>
  MinLinear = 0x0040,
  
  /// <summary>
  /// Magnitude linear filter.
  /// </summary>
  MagLinear = 0x0080,
  
  /// <summary>
  /// Mipmap filter.
  /// </summary>
  Mipmap = 0x0100,
  
  /// <summary>
  /// Video bitmap only, which presumably will be hardware accelerated as it will be created in VRAM.
  /// </summary>
  VideoBitmap = 0x0400,
  
  /// <summary>
  /// Attempts to create a <see cref="VideoBitmap"/> if possible for performance, but will fall back to
  /// <see cref="MemoryBitmap"/> if unable to. You can convert memory bitmaps to video bitmaps (ie, the bitmap was
  /// created on a thread that doesn't have a display associated with it), by calling
  /// <see cref="Al.ConvertMemoryBitmaps"/> (on the display thread) if the display is capable of supporting
  /// the bitmap(s) as video bitmaps.
  /// </summary>
  ConvertBitmap = 0x1000
}