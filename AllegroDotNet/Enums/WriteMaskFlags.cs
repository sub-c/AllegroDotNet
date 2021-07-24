using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Each enabled bit means the corresponding value is written, a disabled bit means it is not.
    /// </summary>
    [Flags]
    public enum WriteMaskFlags : int
    {
        /// <summary>
        /// Red.
        /// </summary>
        Red = 1 << 0,

        /// <summary>
        /// Green.
        /// </summary>
        Green = 1 << 1,

        /// <summary>
        /// Blue.
        /// </summary>
        Blue = 1 << 2,

        /// <summary>
        /// Alpha.
        /// </summary>
        Alpha = 1 << 3,

        /// <summary>
        /// Depth.
        /// </summary>
        Depth = 1 << 4,

        /// <summary>
        /// RGB.
        /// </summary>
        Rgb = (Red | Green | Blue),

        /// <summary>
        /// RGB with alpha.
        /// </summary>
        Rgba = (Rgb | Alpha)
    }
}
