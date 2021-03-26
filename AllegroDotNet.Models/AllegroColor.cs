using System.Runtime.InteropServices;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// A structure that describes a color in a device independent way.
    /// </summary>
    public sealed class AllegroColor
    {
        internal NativeAllegroColor native = new NativeAllegroColor();

        [StructLayout(LayoutKind.Sequential)]
        internal struct NativeAllegroColor
        {
            float r, g, b, a;
        }
    }
}
