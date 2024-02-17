using SubC.AllegroDotNet.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static ColorContext Color => _colorContext ??= new();

  private static ColorContext? _colorContext;

  public sealed class ColorContext
  {
    #region Color Routines

    public al_color_cmyk AlColorCmyk { get; }
    public al_color_cmyk_to_rgb AlColorCmykToRgb { get; }
    public al_color_hsl AlColorHsl { get; }
    public al_color_hsl_to_rgb AlColorHslToRgb { get; }
    public al_color_hsv AlColorHsv { get; }
    public al_color_hsv_to_rgb AlColorHsvToRgb { get; }
    public al_color_html AlColorHtml { get; }
    public al_color_html_to_rgb AlColorHtmlToRgb { get; }
    public al_color_rgb_to_html AlColorRgbToHtml { get; }
    public al_color_name AlColorName { get; }
    public al_color_name_to_rgb AlColorNameToRgb { get; }
    public al_color_rgb_to_cmyk AlColorRgbToCmyk { get; }
    public al_color_rgb_to_hsl AlColorRgbToHsl { get; }
    public al_color_rgb_to_hsv AlColorRgbToHsv { get; }
    public al_color_rgb_to_name AlColorRgbToName { get; }
    public al_color_rgb_to_xyz AlColorRgbToXyz { get; }
    public al_color_xyz AlColorXyz { get; }
    public al_color_xyz_to_rgb AlColorXyzToRgb { get; }
    public al_color_rgb_to_xyy AlColorRgbToXyy { get; }
    public al_color_xyy AlColorXyy { get; }
    public al_color_xyy_to_rgb AlColorXyyToRgb { get; }
    public al_color_rgb_to_lab AlColorRgbToLab { get; }
    public al_color_lab AlColorLab { get; }
    public al_color_lab_to_rgb AlColorLabToRgb { get; }
    public al_color_rgb_to_lch AlColorRgbToLch { get; }
    public al_color_lch AlColorLch { get; }
    public al_color_lch_to_rgb AlColorLchToRgb { get; }
    public al_color_distance_ciede2000 AlColorDistanceCiede2000 { get; }
    public al_color_rgb_to_yuv AlColorRgbToYuv { get; }
    public al_color_yuv AlColorYuv { get; }
    public al_color_yuv_to_rgb AlColorYuvToRgb { get; }
    public al_get_allegro_color_version AlGetAllegroColorVersion { get; }
    public al_is_color_valid AlIsColorValid { get; }
    public al_color_rgb_to_oklab AlColorRgbToOklab { get; }
    public al_color_oklab AlColorOklab { get; }
    public al_color_oklab_to_rgb AlColorOklabToRgb { get; }
    public al_color_rgb_to_linear AlColorRgbToLinear { get; }
    public al_color_linear AlColorLinear { get; }
    public al_color_linear_to_rgb AlColorLinearToRgb { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_cmyk(float c, float m, float y, float k);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_cmyk_to_rgb(float cyan, float magenta, float yellow, float key, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_hsl(float h, float s, float l);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_hsl_to_rgb(float hue, float saturation, float lightness, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_hsv(float h, float s, float v);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_hsv_to_rgb(float hue, float saturation, float value, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_html(IntPtr @string);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_color_html_to_rgb(IntPtr @string, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_html(float red, float green, float blue, IntPtr @string);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_name(IntPtr name);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_color_name_to_rgb(IntPtr name, ref float r, ref float g, ref float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_cmyk(float red, float green, float blue, ref float cyan, ref float magenta, ref float yellow, ref float key);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_hsl(float red, float green, float blue, ref float hue, ref float saturation, ref float lightness);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_hsv(float red, float green, float blue, ref float hue, ref float saturation, ref float value);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_color_rgb_to_name(float r, float g, float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_xyz(float red, float green, float blue, ref float x, ref float y, ref float z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_xyz(float x, float y, float z);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_xyz_to_rgb(float x, float y, float z, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_xyy(float red, float green, float blue, ref float x, ref float y, ref float y2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_xyy(float x, float y, float y2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_xyy_to_rgb(float x, float y, float y2, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_lab(float red, float green, float blue, ref float l, ref float a, ref float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_lab(float l, float a, float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_lab_to_rgb(float l, float a, float b, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_lch(float red, float green, float blue, ref float l, ref float c, ref float h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_lch(float l, float c, float h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_lch_to_rgb(float l, float c, float h, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double al_color_distance_ciede2000(AllegroColor color1, AllegroColor color2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_yuv(float red, float green, float blue, ref float y, ref float u, ref float v);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_yuv(float y, float u, float v);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_yuv_to_rgb(float y, float u, float v, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_color_version();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_color_valid(AllegroColor color);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_oklab(float red, float green, float blue, ref float ol, ref float oa, ref float ob);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_oklab(float l, float a, float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_oklab_to_rgb(float ol, float oa, float ob, ref float red, ref float green, ref float blue);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_rgb_to_linear(float red, float green, float blue, ref float r, ref float g, ref float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate AllegroColor al_color_linear(float r, float g, float b);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_color_linear_to_rgb(float r, float g, float b, ref float red, ref float green, ref float blue);

    #endregion

    public ColorContext()
    {
      AlColorCmyk = LoadFunction<al_color_cmyk>();
      AlColorCmykToRgb = LoadFunction<al_color_cmyk_to_rgb>();
      AlColorHsl = LoadFunction<al_color_hsl>();
      AlColorHslToRgb = LoadFunction<al_color_hsl_to_rgb>();
      AlColorHsv = LoadFunction<al_color_hsv>();
      AlColorHsvToRgb = LoadFunction<al_color_hsv_to_rgb>();
      AlColorHtml = LoadFunction<al_color_html>();
      AlColorHtmlToRgb = LoadFunction<al_color_html_to_rgb>();
      AlColorRgbToHtml = LoadFunction<al_color_rgb_to_html>();
      AlColorName = LoadFunction<al_color_name>();
      AlColorNameToRgb = LoadFunction<al_color_name_to_rgb>();
      AlColorRgbToCmyk = LoadFunction<al_color_rgb_to_cmyk>();
      AlColorRgbToHsl = LoadFunction<al_color_rgb_to_hsl>();
      AlColorRgbToHsv = LoadFunction<al_color_rgb_to_hsv>();
      AlColorRgbToName = LoadFunction<al_color_rgb_to_name>();
      AlColorRgbToXyz = LoadFunction<al_color_rgb_to_xyz>();
      AlColorXyz = LoadFunction<al_color_xyz>();
      AlColorXyzToRgb = LoadFunction<al_color_xyz_to_rgb>();
      AlColorRgbToXyy = LoadFunction<al_color_rgb_to_xyy>();
      AlColorXyy = LoadFunction<al_color_xyy>();
      AlColorXyyToRgb = LoadFunction<al_color_xyy_to_rgb>();
      AlColorRgbToLab = LoadFunction<al_color_rgb_to_lab>();
      AlColorLab = LoadFunction<al_color_lab>();
      AlColorLabToRgb = LoadFunction<al_color_lab_to_rgb>();
      AlColorRgbToLch = LoadFunction<al_color_rgb_to_lch>();
      AlColorLch = LoadFunction<al_color_lch>();
      AlColorLchToRgb = LoadFunction<al_color_lch_to_rgb>();
      AlColorDistanceCiede2000 = LoadFunction<al_color_distance_ciede2000>();
      AlColorRgbToYuv = LoadFunction<al_color_rgb_to_yuv>();
      AlColorYuv = LoadFunction<al_color_yuv>();
      AlColorYuvToRgb = LoadFunction<al_color_yuv_to_rgb>();
      AlGetAllegroColorVersion = LoadFunction<al_get_allegro_color_version>();
      AlIsColorValid = LoadFunction<al_is_color_valid>();
      AlColorRgbToOklab = LoadFunction<al_color_rgb_to_oklab>();
      AlColorOklab = LoadFunction<al_color_oklab>();
      AlColorOklabToRgb = LoadFunction<al_color_oklab_to_rgb>();
      AlColorRgbToLinear = LoadFunction<al_color_rgb_to_linear>();
      AlColorLinear = LoadFunction<al_color_linear>();
      AlColorLinearToRgb = LoadFunction<al_color_linear_to_rgb>();
    }
  }
}
