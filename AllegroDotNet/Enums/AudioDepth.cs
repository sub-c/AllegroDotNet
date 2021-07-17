    using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// Sample depth and type as well as signedness. Mixers only use 32-bit signed float (-1..+1), or 16-bit signed
    /// integers. Signedness is determined by an “unsigned” bit-flag applied to the depth value.
    /// </summary>
    [Flags]
    public enum AudioDepth : int
    {
        /// <summary>
        /// 8-bit signed.
        /// </summary>
        Int8 = 0x00,

        /// <summary>
        /// 16-bit signed.
        /// </summary>
        Int16 = 0x01,

        /// <summary>
        /// 24-bit signed.
        /// </summary>
        Int24 = 0x02,

        /// <summary>
        /// 32-bit floating point.
        /// </summary>
        Float32 = 0x03,

        /// <summary>
        /// Bitwise OR this to turn audio depth unsigned.
        /// </summary>
        Unsigned = 0x08,

        /// <summary>
        /// 8-bit unsigned.
        /// </summary>
        UInt8 = Int8 | Unsigned,

        /// <summary>
        /// 16-bit unsigned.
        /// </summary>
        UInt16 = Int16 | Unsigned,

        /// <summary>
        /// 24-bit unsigned.
        /// </summary>
        UInt24 = Int24 | Unsigned
    }
}
