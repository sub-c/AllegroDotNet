using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// A voice represents an audio device on the system, which may be a real device, or an abstract device provided by
    /// the operating system. To play back audio, you would attach a mixer, sample instance or audio stream to a voice.
    /// </summary>
    public sealed class AllegroVoice : NativePointerWrapper, IEquatable<AllegroVoice>
    {
        internal AllegroVoice()
        {
        }

        /// <summary>
        /// Determines if two <see cref="AllegroVoice"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroVoice other)
        {
            return NativeIntPtr == other?.NativeIntPtr;
        }
    }
}
