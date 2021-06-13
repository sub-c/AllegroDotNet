using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Filesystem modes/types.
    /// </summary>
    [Flags]
    public enum FileMode : int
    {
        /// <summary>
        /// Readable.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Writable.
        /// </summary>
        Write = 1 << 1,

        /// <summary>
        /// Executable.
        /// </summary>
        Execute = 1 << 2,

        /// <summary>
        /// Hidden.
        /// </summary>
        Hidden = 1 << 3,

        /// <summary>
        /// Regular file.
        /// </summary>
        IsFile = 1 << 4,

        /// <summary>
        /// Directory.
        /// </summary>
        IsDir = 1 << 5
    }
}
