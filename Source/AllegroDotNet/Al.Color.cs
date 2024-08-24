using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
    public static AllegroColor ColorCmyk(float c, float m, float y, float k)
    {
        return Interop.Color.AlColorCmyk(c, m, y, k);
    }

    public static void ColorCmykToRgb(float cyan, float magenta, float yellow, float key, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorCmykToRgb(cyan, magenta, yellow, key, ref red, ref green, ref blue);
    }

    public static AllegroColor ColorHsl(float h, float s, float l)
    {
        return Interop.Color.AlColorHsl(h, s, l);
    }

    public static void ColorHslToRgb(float hue, float saturation, float lightness, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorHslToRgb(hue, saturation, lightness, ref red, ref green, ref blue);
    }

    public static AllegroColor ColorHsv(float h, float s, float v)
    {
        return Interop.Color.AlColorHsv(h, s, v);
    }

    public static void ColorHsvToRgb(float hue, float saturation, float value, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorHsvToRgb(hue, saturation, value, ref red, ref green, ref blue);
    }

    public static AllegroColor ColorHtml(string? htmlColor)
    {
        using var nativeHtmlColor = new CStringAnsi(htmlColor);
        return Interop.Color.AlColorHtml(nativeHtmlColor.Pointer);
    }

    public static bool ColorHtmlToRgb(string? htmlColor, ref float red, ref float green, ref float blue)
    {
        using var nativeHtmlColor = new CStringAnsi(htmlColor);
        return Interop.Color.AlColorHtmlToRgb(nativeHtmlColor.Pointer, ref red, ref green, ref blue) != 0;
    }

    public static void ColorRgbToHtml(float red, float green, float blue, out string? htmlColor)
    {
        var nativeHtmlColor = Marshal.AllocHGlobal(8);
        try
        {
            Interop.Color.AlColorRgbToHtml(red, green, blue, nativeHtmlColor);
            htmlColor = Marshal.PtrToStringAnsi(nativeHtmlColor);
        }
        finally
        {
            Marshal.FreeHGlobal(nativeHtmlColor);
        }
    }

    public static AllegroColor ColorName(string? colorName)
    {
        using var nativeColorName = new CStringAnsi(colorName);
        return Interop.Color.AlColorName(nativeColorName.Pointer);
    }

    public static bool ColorNameToRgb(string? colorName, ref float red, ref float green, ref float blue)
    {
        using var nativeColorName = new CStringAnsi(colorName);
        return Interop.Color.AlColorNameToRgb(nativeColorName.Pointer, ref red, ref green, ref blue) != 0;
    }

    public static void ColorRgbToCmyk(float red, float green, float blue, ref float cyan, ref float magenta, ref float yellow, ref float key)
    {
        Interop.Color.AlColorRgbToCmyk(red, green, blue, ref cyan, ref magenta, ref yellow, ref key);
    }

    public static void ColorRgbToHsl(float red, float green, float blue, ref float hue, ref float saturation, ref float lightness)
    {
        Interop.Color.AlColorRgbToHsl(red, green, blue, ref hue, ref saturation, ref lightness);
    }

    public static void ColorRgbToHsv(float red, float green, float blue, ref float hue, ref float saturation, ref float value)
    {
        Interop.Color.AlColorRgbToHsv(red, green, blue, ref hue, ref saturation, ref value);
    }

    public static string? ColorRgbToName(float r, float g, float b)
    {
        var pointer = Interop.Color.AlColorRgbToName(r, g, b);
        return Marshal.PtrToStringAnsi(pointer);
    }

    public static void ColorRgbToXyz(float red, float green, float blue, ref float x, ref float y, ref float z)
    {
        Interop.Color.AlColorRgbToXyz(red, green, blue, ref x, ref y, ref z);
    }

    public static AllegroColor ColorXyz(float x, float y, float z)
    {
        return Interop.Color.AlColorXyz(x, y, z);
    }

    public static void ColorXyzToRgb(float x, float y, float z, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorXyzToRgb(x, y, z, ref red, ref green, ref blue);
    }

    public static void ColorRgbToXyy(float red, float green, float blue, ref float x, ref float y, ref float y2)
    {
        Interop.Color.AlColorRgbToXyy(red, green, blue, ref x, ref y, ref y2);
    }

    public static AllegroColor ColorXyy(float x, float y, float y2)
    {
        return Interop.Color.AlColorXyy(x, y, y2);
    }

    public static void ColorXyyToRgb(float x, float y, float y2, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorXyyToRgb(x, y, y2, ref red, ref green, ref blue);
    }

    public static void ColorRgbToLab(float red, float green, float blue, ref float l, ref float a, ref float b)
    {
        Interop.Color.AlColorRgbToLab(red, green, blue, ref l, ref a, ref b);
    }

    public static AllegroColor ColorLab(float l, float a, float b)
    {
        return Interop.Color.AlColorLab(l, a, b);
    }

    public static void ColorLabToRgb(float l, float a, float b, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorLabToRgb(l, a, b, ref red, ref green, ref blue);
    }

    public static void ColorRgbToLch(float red, float green, float blue, ref float l, ref float c, ref float h)
    {
        Interop.Color.AlColorRgbToLch(red, green, blue, ref l, ref c, ref h);
    }

    public static AllegroColor ColorLch(float l, float c, float h)
    {
        return Interop.Color.AlColorLch(l, c, h);
    }

    public static void ColorLchToRgb(float l, float c, float h, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorLchToRgb(l, c, h, ref red, ref green, ref blue);
    }

    public static double ColorDistanceCiede2000(AllegroColor color1, AllegroColor color2)
    {
        return Interop.Color.AlColorDistanceCiede2000(color1, color2);
    }

    public static void ColorRgbToYuv(float red, float green, float blue, ref float y, ref float u, ref float v)
    {
        Interop.Color.AlColorRgbToYuv(red, green, blue, ref y, ref u, ref v);
    }

    public static AllegroColor ColorYuv(float y, float u, float v)
    {
        return Interop.Color.AlColorYuv(y, u, v);
    }

    public static void ColorYuvToRgb(float y, float u, float v, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorYuvToRgb(y, u, v, ref red, ref green, ref blue);
    }

    public static uint GetAllegroColorVersion()
    {
        return Interop.Color.AlGetAllegroColorVersion();
    }

    public static bool IsColorValid(AllegroColor color)
    {
        return Interop.Color.AlIsColorValid(color) != 0;
    }

    public static void ColorRgbToOklab(float red, float green, float blue, ref float ol, ref float oa, ref float ob)
    {
        Interop.Color.AlColorRgbToOklab(red, green, blue, ref ol, ref oa, ref ob);
    }

    public static AllegroColor ColorOklab(float l, float a, float b)
    {
        return Interop.Color.AlColorOklab(l, a, b);
    }

    public static void ColorOklabToRgb(float ol, float oa, float ob, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorOklabToRgb(ol, oa, ob, ref red, ref green, ref blue);
    }

    public static void ColorRgbToLinear(float red, float green, float blue, ref float r, ref float g, ref float b)
    {
        Interop.Color.AlColorRgbToLinear(red, green, blue, ref r, ref g, ref b);
    }

    public static AllegroColor ColorLinear(float r, float g, float b)
    {
        return Interop.Color.AlColorLinear(r, g, b);
    }

    public static void ColorLinearToRgb(float r, float g, float b, ref float red, ref float green, ref float blue)
    {
        Interop.Color.AlColorLinearToRgb(r, g, b, ref red, ref green, ref blue);
    }
}
