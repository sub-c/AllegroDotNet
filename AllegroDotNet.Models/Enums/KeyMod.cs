using System;

namespace AllegroDotNet.Models.Enums
{
    /// <summary>
    /// The event field 'keyboard.modifiers' is a bitfield composed of these constants.
    /// These indicate the modifier keys which were pressed at the time a character was typed.
    /// </summary>
    [Flags]
    public enum KeyMod : int
    {
        Shift = 0x00001,
        Ctrl = 0x00002,
        Alt = 0x00004,
        LWin = 0x00008,
        RWin = 0x00010,
        Menu = 0x00020,
        AltGr = 0x00040,
        Command = 0x00080,
        ScrollLock = 0x00100,
        NumLock = 0x00200,
        CapsLock = 0x00400,
        InAltSeq = 0x00800,
        Accent1 = 0x01000,
        Accent2 = 0x02000,
        Accent3 = 0x04000,
        Accent4 = 0x08000
    }
}
