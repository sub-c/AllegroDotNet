using System;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// Abstract type representing a bitmap (2D image).
    /// </summary>
    public sealed class AllegroBitmap
    {
        internal IntPtr NativeBitmap { get; set; } = IntPtr.Zero;
    }
}
