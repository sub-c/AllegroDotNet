using System;
using AllegroDotNet.Models.Native;

namespace AllegroDotNet.Models
{
    /// <summary>
    /// This is a structure that is used to hold a “snapshot” of a keyboard’s state at a particular instant.
    /// You cannot read the state of keys directly. Use the function al_key_down.
    /// </summary>
    public sealed class AllegroKeyboardState
    {
        internal NativeKeyboardState Native = new NativeKeyboardState();
    }
}
