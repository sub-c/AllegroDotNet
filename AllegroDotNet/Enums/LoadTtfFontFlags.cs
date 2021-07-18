using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Flags used when loading TTF fonts.
    /// </summary>
    [Flags]
    public enum LoadTtfFontFlags : int
    {
        /// <summary>
        /// No font flags specified.
        /// </summary>
        None = 0,


        /// <summary>
        /// No kerning.
        /// </summary>
        NoKerning = 1,

        /// <summary>
        /// Monochrome font.
        /// </summary>
        Monochrome = 2,

        /// <summary>
        /// No automatic hint.
        /// </summary>
        NoAutohint = 4
    }
}
