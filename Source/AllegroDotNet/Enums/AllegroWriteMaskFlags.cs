namespace SubC.AllegroDotNet.Enums;

[Flags]
public enum AllegroWriteMaskFlags
{
    Red = 1 << 0,
    Green = 1 << 1,
    Blue = 1 << 2,
    Alpha = 1 << 3,
    Depth = 1 << 4,
    Rgb = (Red | Green | Blue),
    Rgba = (Rgb | Alpha)
}
