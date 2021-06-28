using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure representing a mutex.
    /// </summary>
    public sealed class AllegroMutex : NativePointerWrapper
    {
        internal AllegroMutex()
        {
        }
    }
}
