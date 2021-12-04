using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque data type that represents a menu that contains menu items. Each of the menu items may optionally
    /// include a sub-menu.
    /// </summary>
    public sealed class AllegroMenu : NativePointerWrapper, IEquatable<AllegroMenu>
    {
        internal AllegroMenu()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroMenu"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroMenu other)
        {
            throw new NotImplementedException();
        }
    }
}
