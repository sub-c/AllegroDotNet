using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native.Structs;

/// <summary>
/// This structure holds the data for a color.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct AllegroColor
{
  /// <summary>
  /// Gets or sets the red value of the color.
  /// </summary>
  public float R
  {
    get => r;
    set => r = value;
  }
  
  /// <summary>
  /// Gets or sets the green value of the color.
  /// </summary>
  public float G
  {
    get => g;
    set => g = value;
  }
  
  /// <summary>
  /// Gets or sets the blue value of the color.
  /// </summary>
  public float B
  {
    get => b;
    set => b = value;
  }
  
  /// <summary>
  /// Gets or sets the alpha value of the color.
  /// </summary>
  public float A
  {
    get => a;
    set => a = value;
  }
  
  internal float r;
  internal float g;
  internal float b;
  internal float a;
}