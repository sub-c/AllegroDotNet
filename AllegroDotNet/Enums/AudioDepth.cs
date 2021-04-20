using System;

namespace AllegroDotNet.Enums
{
    /// <summary>
    /// Sample depth and type as well as signedness. Mixers only use 32-bit signed float (-1..+1), or 16-bit signed
    /// integers. Signedness is determined by an “unsigned” bit-flag applied to the depth value.
    /// </summary>
    [Flags]
    public enum AudioDepth : int
    {
        Int8 = 0x00,
        Int16 = 0x01,
        Int24 = 0x02,
        Float32 = 0x03,
        Unsigned = 0x08,

        UInt8 = Int8 | Unsigned,
        UInt16 = Int16 | Unsigned,
        UInt24 = Int24 | Unsigned
    }
}
