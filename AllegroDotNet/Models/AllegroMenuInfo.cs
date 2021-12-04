using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// A structure that defines how to create a complete menu system. For standard menu items, the following format
    /// is used: { caption, id, flags, icon }
    /// </summary>
    public sealed class AllegroMenuInfo : NativePointerWrapper, IEquatable<AllegroMenuInfo>
    {
        /// <summary>
        /// Determines if two <see cref="AllegroMenuInfo"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroMenuInfo other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
