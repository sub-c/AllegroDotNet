using System;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure used for iterating across entries in a configuration section.
    /// </summary>
    public sealed class AllegroConfigEntry : NativePointerWrapper
    {
        internal AllegroConfigEntry(IntPtr nativeIntPtr)
        {
            NativeIntPtr = nativeIntPtr;
        }
    }
}
