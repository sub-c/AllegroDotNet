using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Represent an opaque timeout value.
    /// </summary>
    public sealed class AllegroTimeout
    {
        internal NativeAllegroTimeout NativeTimeout = new NativeAllegroTimeout();
    }
}
