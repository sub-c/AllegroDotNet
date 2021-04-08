using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential, Size = sizeof(float) * 4 * 4)]
    internal struct NativeTransform
    {
        public float[,] m;

        public NativeTransform(bool initialize = true)
        {
            m = new float[4,4];
        }
    }
}
