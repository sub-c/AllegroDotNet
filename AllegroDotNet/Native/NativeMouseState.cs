using System;

namespace SubC.AllegroDotNet.Native
{
    internal struct NativeMouseState
    {
        public int x;
        public int y;
        public int z;
        public int w;
        public int internalAxis1, internalAxis2, internalAxis3, internalAxis4;
        public int buttons;
        public float pressure;
        public IntPtr display;
    }
}
