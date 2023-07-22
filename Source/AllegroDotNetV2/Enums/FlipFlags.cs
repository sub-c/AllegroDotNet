namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// This enumeration sets how to flip bitmaps when drawing.
/// </summary>
[Flags]
public enum FlipFlags : int
{
  /// <summary>
  /// Do not flip the bitmap.
  /// </summary>
  None = 0,
  
  /// <summary>
  /// Flip the bitmap horizontally.
  /// </summary>
  Horizontal = 0x00001,
  
  /// <summary>
  /// Flip the bitmap vertically.
  /// </summary>
  Vertical = 0x00002
}