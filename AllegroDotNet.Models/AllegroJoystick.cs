﻿using System;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// This is an abstract data type representing a physical joystick or joystick-like device (such as a gamepad).
    /// </summary>
    public sealed class AllegroJoystick : NativePointerWrapper
    {
        internal AllegroJoystick(IntPtr nativeIntPtr)
        {
            NativeIntPtr = nativeIntPtr;
        }
    }
}
