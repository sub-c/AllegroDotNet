using SubC.AllegroDotNet.Native;
using System;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An ALLEGRO_SAMPLE_ID represents a sample being played via al_play_sample. It can be used to later stop the
    /// sample with al_stop_sample. The underlying ALLEGRO_SAMPLE_INSTANCE can be extracted using al_lock_sample_id.
    /// </summary>
    public sealed class AllegroSampleId : IEquatable<AllegroSampleId>
    {
        internal NativeSampleId Native = new NativeSampleId();

        /// <summary>
        /// Determines if two <see cref="AllegroFileChooser"/> native pointers are equal.
        /// </summary>
        /// <param name="other">The instance to compare equality.</param>
        /// <returns>True if the native pointers are equal, otherwise false.</returns>
        public bool Equals(AllegroSampleId other)
        {
            return Native._id == other?.Native._id
                && Native._index == other?.Native._index;
        }
    }
}
