using AllegroDotNet.Models.Native;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// A structure that describes a color in a device independent way.
    /// </summary>
    public sealed class AllegroColor
    {
        public float R
        {
            get { return Native.r; }
            set { Native.r = value; }
        }

        public float G
        {
            get { return Native.g; }
            set { Native.g = value; }
        }

        public float B
        {
            get { return Native.b; }
            set { Native.b = value; }
        }

        public float A
        {
            get { return Native.a; }
            set{ Native.a = value; }
        }

        internal NativeAllegroColor Native = new NativeAllegroColor();
    }
}
