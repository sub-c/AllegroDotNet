using System;
using System.Runtime.InteropServices;

namespace AllegroDotNet.Models.Native
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeKeyboardState
    {
        public IntPtr Display;
        public int internalKeyBuffer1, internalKeyBuffer2, internalKeyBuffer3, internalKeyBuffer4, internalKeyBuffer5, internalKeyBuffer6, internalKeyBuffer7, internalKeyBuffer8;
    }
}
