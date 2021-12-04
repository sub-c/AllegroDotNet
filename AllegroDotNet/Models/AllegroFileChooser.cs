using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Opaque handle to a native file dialog.
    /// </summary>
    public sealed class AllegroFileChooser : NativePointerWrapper, IEquatable<AllegroFileChooser>
    {
        internal AllegroFileChooser()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroFileChooser"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroFileChooser other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
