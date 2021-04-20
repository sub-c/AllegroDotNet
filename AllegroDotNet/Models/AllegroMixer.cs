namespace AllegroDotNet.Models
{
    /// <summary>
    /// A mixer mixes together attached streams into a single buffer. In the process, it converts channel
    /// configurations, sample frequencies and audio depths of the attached sample instances and audio streams
    /// accordingly. You can control the quality of this conversion using ALLEGRO_MIXER_QUALITY.
    /// <para>
    /// When going from mono to stereo (and above), the mixer reduces the volume of both channels by sqrt(2).
    /// When going from stereo (and above) to mono, the mixer reduces the volume of the left and right channels
    /// by sqrt(2) before adding them to the center channel (if present).
    /// </para>
    /// </summary>
    public class AllegroMixer : NativePointerWrapper
    {
        internal AllegroMixer()
        {
        }
    }
}
