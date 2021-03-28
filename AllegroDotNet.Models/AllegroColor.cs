using AllegroDotNet.Models.Native;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// A structure that describes a color in a device independent way.
    /// </summary>
    public sealed class AllegroColor
    {
        internal NativeAllegroColor Native = new NativeAllegroColor();
    }
}
