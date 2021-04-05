using System;
using System.Runtime.InteropServices;

namespace AllegroDotNet.Native
{
    [StructLayout(LayoutKind.Sequential, Size = 320), Serializable]
    internal struct NativeJoystickState
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.AllegroMaxJoystickSticks)]
        public NativeStick[] stick;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.AllegroMaxJoystickButtons)]
        public int[] button;

        public NativeJoystickState(bool initialize = true)
        {
            stick = new NativeStick[Constants.AllegroMaxJoystickSticks];
            button = new int[Constants.AllegroMaxJoystickButtons];
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 12), Serializable]
    internal struct NativeStick
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Constants.AllegroMaxJoystickAxes)]
        public float[] axis;

        public NativeStick(bool initialize = true)
        {
            axis = new float[Constants.AllegroMaxJoystickAxes];
        }
    }
}
