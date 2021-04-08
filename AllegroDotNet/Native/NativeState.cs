using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential, Size = 1024)]
    internal struct NativeState
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[] _tls;

        public NativeState(bool initialize = true)
        {
            _tls = new byte[1024];
        }
    }
}
