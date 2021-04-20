namespace AllegroDotNet.Models
{
    /// <summary>
    /// An ALLEGRO_AUDIO_STREAM object is used to stream generated audio to the sound device, in real-time. This is
    /// done by reading from a buffer, which is split into a number of fragments. Whenever a fragment has finished
    /// playing, the user can refill it with new data.
    /// <para>
    /// As with ALLEGRO_SAMPLE_INSTANCE objects, streams store information necessary for playback, so you may not
    /// play the same stream multiple times simultaneously. Streams also need to be attached to an ALLEGRO_MIXER,
    /// which, eventually, reaches an ALLEGRO_VOICE object.
    /// </para>
    /// <para>
    /// While playing, you must periodically fill fragments with new audio data. To know when a new fragment is ready
    /// to be filled, you can either directly check with al_get_available_audio_stream_fragments, or listen to events
    /// from the stream.
    /// </para>
    /// <para>
    /// You can register an audio stream event source to an event queue; see al_get_audio_stream_event_source. An
    /// ALLEGRO_EVENT_AUDIO_STREAM_FRAGMENT event is generated whenever a new fragment is ready. When you receive
    /// an event, use al_get_audio_stream_fragment to obtain a pointer to the fragment to be filled. The size and
    /// format are determined by the parameters passed to al_create_audio_stream.
    /// </para>
    /// <para>
    /// If you’re late with supplying new data, the stream will be silent until new data is provided. You must call
    /// al_drain_audio_stream when you’re finished with supplying data to the stream.
    /// </para>
    /// </summary>
    public sealed class AllegroAudioStream : NativePointerWrapper
    {
        internal AllegroAudioStream()
        {
        }
    }
}
