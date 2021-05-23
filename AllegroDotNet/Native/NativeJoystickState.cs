using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential, Size = 320), Serializable]
    internal struct NativeJoystickState
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = AlConstants.AllegroMaxJoystickSticks)]
        public NativeStick[] stick;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = AlConstants.AllegroMaxJoystickButtons)]
        public int[] button;

        public NativeJoystickState(bool initialize = true)
        {
            stick = new NativeStick[AlConstants.AllegroMaxJoystickSticks];
            button = new int[AlConstants.AllegroMaxJoystickButtons];
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 12), Serializable]
    internal struct NativeStick
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = AlConstants.AllegroMaxJoystickAxes)]
        public float[] axis;

        public NativeStick(bool initialize = true)
        {
            axis = new float[AlConstants.AllegroMaxJoystickAxes];
        }
    }
}
