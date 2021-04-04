using System;
using AllegroDotNet.Models.Native;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// The state of the mouse at a point in time.
    /// </summary>
    public sealed class AllegroMouseState
    {
        public int X => Native.x;
        public int Y => Native.y;
        public int Z => Native.z;
        public int W => Native.w;
        public int Buttons => Native.buttons;
        public float Pressure => Native.pressure;
        public AllegroDisplay Display
            => Native.display == IntPtr.Zero ? null : new AllegroDisplay { NativeIntPtr = Native.display };

        internal NativeMouseState Native = new NativeMouseState();
    }
}
