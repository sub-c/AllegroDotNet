using System;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// An abstract configuration structure.
    /// </summary>
    public sealed class AllegroConfig : NativePointerWrapper
    {
        internal AllegroConfig(IntPtr nativeIntPtr)
        {
            NativeIntPtr = nativeIntPtr;
        }
    }
}
