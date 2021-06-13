using System;

namespace SubC.AllegroDotNet.Models
{
    public abstract class NativePointerWrapper
    {
        /// <summary>
        /// True if the native Allegro pointer is null, otherwise false.
        /// </summary>
        public bool IsNull => NativeIntPtr == IntPtr.Zero;

        internal IntPtr NativeIntPtr = IntPtr.Zero;
    }
}
