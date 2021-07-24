namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Flags to use when drawing a font.
    /// </summary>
    public enum DrawFontFlags : int
    {
        /// <summary>
        /// Disable kerning.
        /// </summary>
        NoKerning = -1,

        /// <summary>
        /// Align left.
        /// </summary>
        AlignLeft = 0,

        /// <summary>
        /// Align center, but in the kings english.
        /// </summary>
        AlignCentre = 1,

        /// <summary>
        /// Align center.
        /// </summary>
        AlignCenter = 1,

        /// <summary>
        /// Align right.
        /// </summary>
        AlignRight = 2,

        /// <summary>
        /// Align to closest whole integer.
        /// </summary>
        AlignInteger = 4,
    }
}
