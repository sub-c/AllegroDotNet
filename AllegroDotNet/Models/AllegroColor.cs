using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// A structure that describes a color in a device independent way.
    /// </summary>
    public sealed class AllegroColor : IEquatable<AllegroColor>
    {
        /// <summary>
        /// Red value.
        /// </summary>
        public float R
        {
            get { return Native.r; }
            set { Native.r = value; }
        }

        /// <summary>
        /// Green value.
        /// </summary>
        public float G
        {
            get { return Native.g; }
            set { Native.g = value; }
        }

        /// <summary>
        /// Blue value.
        /// </summary>
        public float B
        {
            get { return Native.b; }
            set { Native.b = value; }
        }

        /// <summary>
        /// Alpha value.
        /// </summary>
        public float A
        {
            get { return Native.a; }
            set{ Native.a = value; }
        }

        internal NativeAllegroColor Native = new NativeAllegroColor();

        /// <summary>
        /// Determines if two <see cref="AllegroColor"/> are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the colors are equal, otherwise false.</returns>
        public bool Equals(AllegroColor other)
        {
            return R == other?.R
                && G == other?.G
                && B == other?.B
                && A == other?.A;
        }
    }
}
