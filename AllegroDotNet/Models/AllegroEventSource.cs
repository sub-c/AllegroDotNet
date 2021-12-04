using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An event source is any object which can generate events. For example, an <see cref="AllegroDisplay"/> can generate events, and you can get
    /// the <see cref="AllegroEventSource"/> pointer from an <see cref="AllegroDisplay"/> with Al.GetDisplayEventSource().
    /// <para>
    /// You may create your own "user" event sources that emit custom events.
    /// </para>
    /// </summary>
    public sealed class AllegroEventSource : NativePointerWrapper, IEquatable<AllegroEventSource>
    {
        internal AllegroEventSource()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroEventSource"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroEventSource other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
