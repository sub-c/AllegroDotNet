using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// The available functions you can provide for a filesystem.
    /// </summary>
    public sealed class AllegroFSInterface : NativePointerWrapper, IEquatable<AllegroFSInterface>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllegroFSInterface"/> class.
        /// </summary>
        public AllegroFSInterface()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroFSInterface"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroFSInterface other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
