using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Opaque filesystem entry object. Represents a file or a directory (check with
    /// <see cref="Al.GetFSEntryMode(AllegroFSEntry)"/>). There are no user accessible member variables.
    /// </summary>
    public sealed class AllegroFSEntry : NativePointerWrapper, IEquatable<AllegroFSEntry>
    {
        internal AllegroFSEntry()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroFSEntry"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroFSEntry other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
