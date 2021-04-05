using System;

namespace AllegroDotNet.Enums
{
    /// <summary>
    /// Each enabled bit means the corresponding value is written, a disabled bit means it is not.
    /// </summary>
    [Flags]
    public enum WriteMaskFlags : int
    {
        Red = 1 << 0,
        Green = 1 << 1,
        Blue = 1 << 2,
        Alpha = 1 << 3,
        Depth = 1 << 4,
        Rgb = (Red | Green | Blue),
        Rgba = (Rgb | Alpha)
    }
}
