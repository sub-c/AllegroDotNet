using System;

namespace SubC.AllegroDotNet.Enums
{
    [Flags]
    public enum LoadTtfFontFlags
    {
        None = 0,
        NoKerning = 1,
        Monochrome = 2,
        NoAutohint = 4
    }
}
