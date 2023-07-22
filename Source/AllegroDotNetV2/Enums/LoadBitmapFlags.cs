using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// Flags to use when loading images.
/// </summary>
[Flags]
public enum LoadBitmapFlags : int
{
  /// <summary>
  /// Default behavior, pre-multiplies the alpha channel of an image with the images color data.
  /// </summary>
  None = 0,
  
  /// <summary>
  /// Force the resulting <see cref="AllegroBitmap"/> to use the same format as the file. This is not yet honored.
  /// </summary>
  KeepBitmapFormat = 0x0002,
  
  /// <summary>
  /// Loads the image with the images color data directly.
  /// </summary>
  NoPremultipliedAlpha = 0x0200,
  
  /// <summary>
  /// Load the palette indices of 8-bit .bmp and .pcx files instead of the rgb colors. Since 5.1.0.
  /// </summary>
  KeepIndex = 0x0800
}