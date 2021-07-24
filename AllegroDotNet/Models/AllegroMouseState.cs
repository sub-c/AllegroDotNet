using System;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// The state of the mouse at a point in time.
    /// </summary>
    public sealed class AllegroMouseState
    {
        /// <summary>
        /// The X position.
        /// </summary>
        public int X => Native.x;

        /// <summary>
        /// The Y position.
        /// </summary>
        public int Y => Native.y;

        /// <summary>
        /// The Z position.
        /// </summary>
        public int Z => Native.z;

        /// <summary>
        /// The mouse wheel position.
        /// </summary>
        public int W => Native.w;

        /// <summary>
        /// The mouse buttons.
        /// </summary>
        public int Buttons => Native.buttons;

        /// <summary>
        /// The pressure value.
        /// </summary>
        public float Pressure => Native.pressure;

        /// <summary>
        /// The display the event originated.
        /// </summary>
        public AllegroDisplay Display
            => Native.display == IntPtr.Zero ? null : new AllegroDisplay { NativeIntPtr = Native.display };

        internal NativeMouseState Native = new NativeMouseState();
    }
}
