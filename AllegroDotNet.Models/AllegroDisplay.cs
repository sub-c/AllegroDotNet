using System;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// An opaque type representing an open display or window.
    /// </summary>
    public sealed class AllegroDisplay
    {
        internal IntPtr NativeDisplay = IntPtr.Zero;
    }
}
