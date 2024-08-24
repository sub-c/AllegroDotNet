namespace SubC.AllegroDotNet.Enums;

/// <summary>
/// This enumeration specifies how fonts are loaded from bitmap or FreeType formats.
/// </summary>
[Flags]
public enum LoadFontFlags
{
    None = 0,
    TtfNoKerning = 1,
    TtfMonochrome = 2,
    TtfNoAutohint = 4,
    NoPremultipliedAlpha = 0x0200
}
