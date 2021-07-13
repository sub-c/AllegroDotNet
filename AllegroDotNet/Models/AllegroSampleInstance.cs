using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An ALLEGRO_SAMPLE_INSTANCE object represents a playable instance of a predefined sound effect. It holds
    /// information about how the effect should be played: These playback parameters consist of the looping mode,
    /// loop start/end points, playing position, speed, gain, pan and the playmode. Whether a sample instance is
    /// currently playing or paused is also one of its properties.
    /// <para>
    /// An instance uses the data from an ALLEGRO_SAMPLE object. Multiple instances may be created from the same
    /// ALLEGRO_SAMPLE. An ALLEGRO_SAMPLE must not be destroyed while there are instances which reference it.
    /// </para>
    /// <para>
    /// To actually produce audio output, an ALLEGRO_SAMPLE_INSTANCE must be attached to an ALLEGRO_MIXER which
    /// eventually reaches an ALLEGRO_VOICE object.
    /// </para>
    /// </summary>
    public sealed class AllegroSampleInstance : NativePointerWrapper
    {
        internal AllegroSampleInstance()
        {
        }
    }
}
