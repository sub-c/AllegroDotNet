using System;

namespace SubC.AllegroDotNet.Enums
{
    /// <summary>
    /// The event field 'keyboard.modifiers' is a bitfield composed of these constants.
    /// These indicate the modifier keys which were pressed at the time a character was typed.
    /// </summary>
    [Flags]
    public enum KeyMod : int
    {
        /// <summary>
        /// Shift key.
        /// </summary>
        Shift = 0x00001,

        /// <summary>
        /// Control key.
        /// </summary>
        Ctrl = 0x00002,

        /// <summary>
        /// Alt key.
        /// </summary>
        Alt = 0x00004,

        /// <summary>
        /// Left windows key.
        /// </summary>
        LWin = 0x00008,

        /// <summary>
        /// Right windows key.
        /// </summary>
        RWin = 0x00010,

        /// <summary>
        /// Menu key.
        /// </summary>
        Menu = 0x00020,

        /// <summary>
        /// German alt key.
        /// </summary>
        AltGr = 0x00040,

        /// <summary>
        /// Command key (Mac).
        /// </summary>
        Command = 0x00080,

        /// <summary>
        /// Scroll lock key.
        /// </summary>
        ScrollLock = 0x00100,

        /// <summary>
        /// Num lock key.
        /// </summary>
        NumLock = 0x00200,

        /// <summary>
        /// Caps lock key.
        /// </summary>
        CapsLock = 0x00400,

        /// <summary>
        /// ?
        /// </summary>
        InAltSeq = 0x00800,

        /// <summary>
        /// ?
        /// </summary>
        Accent1 = 0x01000,

        /// <summary>
        /// ?
        /// </summary>
        Accent2 = 0x02000,

        /// <summary>
        /// ?
        /// </summary>
        Accent3 = 0x04000,

        /// <summary>
        /// ?
        /// </summary>
        Accent4 = 0x08000
    }
}
