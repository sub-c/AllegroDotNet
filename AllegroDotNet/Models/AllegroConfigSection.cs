﻿using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// An opaque structure used for iterating across sections in a configuration structure.
    /// </summary>
    public sealed class AllegroConfigSection : NativePointerWrapper
    {
        internal AllegroConfigSection()
        {
        }
    }
}
