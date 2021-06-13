using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// Used for fullscreen mode queries. Contains information about a supported fullscreen modes. The refresh_rate
    /// may be zero if unknown. For an explanation of what format means, see ALLEGRO_PIXEL_FORMAT.
    /// </summary>
    public sealed class AllegroDisplayMode
    {
        internal NativeDisplayMode Native = new NativeDisplayMode();
    }
}
