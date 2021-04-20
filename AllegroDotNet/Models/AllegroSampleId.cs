using AllegroDotNet.Native;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// An ALLEGRO_SAMPLE_ID represents a sample being played via al_play_sample. It can be used to later stop the
    /// sample with al_stop_sample. The underlying ALLEGRO_SAMPLE_INSTANCE can be extracted using al_lock_sample_id.
    /// </summary>
    public sealed class AllegroSampleId
    {
        internal NativeSampleId Native = new NativeSampleId();
    }
}
