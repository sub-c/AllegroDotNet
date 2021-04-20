using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeSampleId
    {
        public int _index;
        public int _id;
    }
}
