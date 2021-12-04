using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// This is an abstract data type representing a physical joystick or joystick-like device (such as a gamepad).
    /// </summary>
    public sealed class AllegroJoystick : NativePointerWrapper, IEquatable<AllegroJoystick>
    {
        internal AllegroJoystick()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroJoystick"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroJoystick other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
