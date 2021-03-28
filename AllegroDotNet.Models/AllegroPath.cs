using System;

namespace AllegroDotNet.Models
{
    public sealed class AllegroPath : NativePointerWrapper
    {
        internal AllegroPath(IntPtr nativeIntPtr)
        {
            NativeIntPtr = nativeIntPtr;
        }
    }
}
