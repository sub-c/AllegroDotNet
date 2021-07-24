using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Text log flags.
    /// </summary>
    [Flags]
    public enum TextLogFlags : int
    {
        /// <summary>
        /// Disable closing the text log window.
        /// </summary>
        NoClose = 1 << 0,

        /// <summary>
        /// Use a mono-spaced font for the text log.
        /// </summary>
        Monospace = 1 << 1
    }
}
