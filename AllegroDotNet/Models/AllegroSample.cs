namespace AllegroDotNet.Models
{
    /// <summary>
    /// An ALLEGRO_SAMPLE object stores the data necessary for playing pre-defined digital audio. It holds a
    /// user-specified PCM data buffer and information about its format (data length, depth, frequency, channel
    /// configuration). You can have the same ALLEGRO_SAMPLE playing multiple times simultaneously.
    /// </summary>
    public sealed class AllegroSample : NativePointerWrapper
    {
        internal AllegroSample()
        {
        }
    }
}
