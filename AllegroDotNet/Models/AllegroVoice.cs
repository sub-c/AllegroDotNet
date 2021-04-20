namespace AllegroDotNet.Models
{
    /// <summary>
    /// A voice represents an audio device on the system, which may be a real device, or an abstract device provided by
    /// the operating system. To play back audio, you would attach a mixer, sample instance or audio stream to a voice.
    /// </summary>
    public sealed class AllegroVoice : NativePointerWrapper
    {
        internal AllegroVoice()
        {
        }
    }
}
