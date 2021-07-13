using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque type representing a string. ALLEGRO_USTRs normally contain UTF-8 encoded strings, but they may be
    /// used to hold any byte sequences, including NULs.
    /// </summary>
    public sealed class AllegroUStr : NativePointerWrapper
    {
        internal AllegroUStr()
        {
        }
    }
}
