using System;

namespace SubC.AllegroDotNet.Native
{
    /// <summary>
    /// An abstract class that wraps a native pointer.
    /// </summary>
    public abstract class NativePointerWrapper
    {
        /// <summary>
        /// True if the native Allegro pointer is null, otherwise false.
        /// </summary>
        public bool IsNull => NativeIntPtr == IntPtr.Zero;

        internal IntPtr NativeIntPtr = IntPtr.Zero;
    }
}
