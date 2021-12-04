using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// A structure containing function pointers to handle a type of “file”, real or virtual.
    /// </summary>
    public sealed class AllegroFileInterface : NativePointerWrapper, IEquatable<AllegroFileInterface>
    {
        internal AllegroFileInterface()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroFileInterface"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroFileInterface other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
