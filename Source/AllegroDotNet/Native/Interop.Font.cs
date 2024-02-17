using SubC.AllegroDotNet.Models;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Native;

internal static partial class Interop
{
  public static FontContext Font => _fontContext ??= new();

  private static FontContext? _fontContext;

  public sealed class FontContext
  {
    #region Font Routines

    public al_init_font_addon AlInitFontAddon { get; }
    public al_is_font_addon_initialized AlIsFontAddonInitialized { get; }
    public al_shutdown_font_addon AlShutdownFontAddon { get; }
    public al_load_font AlLoadFont { get; }
    public al_destroy_font AlDestroyFont { get; }
    public al_register_font_loader AlRegisterFontLoader { get; }
    public al_get_font_line_height AlGetFontLineHeight { get; }
    public al_get_font_ascent AlGetFontAscent { get; }
    public al_get_font_descent AlGetFontDescent { get; }
    public al_get_text_width AlGetTextWidth { get; }
    public al_get_ustr_width AlGetUstrWidth { get; }
    public al_draw_text AlDrawText { get; }
    public al_draw_ustr AlDrawUstr { get; }
    public al_draw_justified_text AlDrawJustifiedText { get; }
    public al_draw_justified_ustr AlDrawJustifiedUstr { get; }
    public al_get_text_dimensions AlGetTextDimensions { get; }
    public al_get_ustr_dimensions AlGetUstrDimensions { get; }
    public al_get_allegro_font_version AlGetAllegroFontVersion { get; }
    public al_get_font_ranges AlGetFontRanges { get; }
    public al_set_fallback_font AlSetFallbackFont { get; }
    public al_get_fallback_font AlGetFallbackFont { get; }
    public al_draw_glyph AlDrawGlyph { get; }
    public al_get_glyph_width AlDrawGlyphWidth { get; }
    public al_get_glyph_dimensions AlGetGlyphDimensions { get; }
    public al_get_glyph_advance AlGetGlyphAdvance { get; }
    public al_draw_multiline_text AlDrawMultilineText { get; }
    public al_draw_multiline_ustr AlDrawMultilineUstr { get; }
    public al_do_multiline_text AlDoMultilineText { get; }
    public al_do_multiline_ustr AlDoMultilineUstr { get; }
    public al_grab_font_from_bitmap AlGrabFontFromBitmap { get; }
    public al_load_bitmap_font AlLoadBitmapFont { get; }
    public al_load_bitmap_font_flags AlLoadBitmapFontFlags { get; }
    public al_create_builtin_font AlCreateBuiltinFont { get; }
    public al_init_ttf_addon AlInitTtfAddon { get; }
    public al_is_ttf_addon_initialized AlIsTtfAddonInitialized { get; }
    public al_shutdown_ttf_addon AlShutdownTtfAddon { get; }
    public al_load_ttf_font AlLoadTtfFont { get; }
    public al_load_ttf_font_f AlLoadTtfFontF { get; }
    public al_load_ttf_font_stretch AlLoadTtfFontStretch { get; }
    public al_load_ttf_font_stretch_f AlLoadTtfFontStretchF { get; }
    public al_get_allegro_ttf_version AlGetAllegroTtfVersion { get; }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_init_font_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_font_addon_initialized();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_font_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_font(IntPtr filename, int size, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_destroy_font(IntPtr font);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_register_font_loader(IntPtr extension, Delegates.RegisterFontLoaderDelegate? load_font);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_line_height(IntPtr font);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_ascent(IntPtr font);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_descent(IntPtr font);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_text_width(IntPtr font, IntPtr str);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_ustr_width(IntPtr font, IntPtr ustr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_text(IntPtr font, AllegroColor color, float x, float y, int flags, IntPtr text);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_ustr(IntPtr font, AllegroColor color, float x, float y, int flags, IntPtr ustr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_justified_text(
      IntPtr font,
      AllegroColor color,
      float x1,
      float x2,
      float y,
      float diff,
      int flags,
      IntPtr text);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_justified_ustr(
      IntPtr font,
      AllegroColor color,
      float x1,
      float x2,
      float y,
      float diff,
      int flags,
      IntPtr ustr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_text_dimensions(IntPtr font, IntPtr text, ref int x, ref int y, ref int w, ref int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_get_ustr_dimensions(IntPtr font, IntPtr ustr, ref int x, ref int y, ref int w, ref int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_font_version();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_font_ranges(IntPtr font, int ranges_count, int[] ranges);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_set_fallback_font(IntPtr font, IntPtr fallback);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_get_fallback_font(IntPtr font);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_glyph(IntPtr font, AllegroColor color, float x, float y, int codepoint);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_glyph_width(IntPtr font, int codepoint);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_get_glyph_dimensions(IntPtr font, int codepoint, ref int x, ref int y, ref int w, ref int h);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int al_get_glyph_advance(IntPtr font, int codepoint1, int codepoint2);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_multiline_text(
      IntPtr font,
      AllegroColor color,
      float x,
      float y,
      float max_width,
      float line_height,
      int flags,
      IntPtr text);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_draw_multiline_ustr(
      IntPtr font,
      AllegroColor color,
      float x,
      float y,
      float max_width,
      float line_height,
      int flags,
      IntPtr ustr);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_do_multiline_text(
      IntPtr font,
      float max_width,
      IntPtr text,
      Delegates.DoMultilineTextCallbackDelegate? cb,
      IntPtr extra);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_do_multiline_ustr(
      IntPtr font,
      float max_width,
      IntPtr ustr,
      Delegates.DoMultilineUstrCallbackDelegate? cb,
      IntPtr extra);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_grab_font_from_bitmap(IntPtr bmp, int ranges_n, int[] ranges);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_font(IntPtr filename);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_bitmap_font_flags(IntPtr filename, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_create_builtin_font();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_init_ttf_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte al_is_ttf_addon_initialized();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void al_shutdown_ttf_addon();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font(IntPtr filename, int size, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font_f(IntPtr file, IntPtr filename, int size, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font_stretch(IntPtr filename, int w, int h, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr al_load_ttf_font_stretch_f(IntPtr file, IntPtr filename, int w, int h, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint al_get_allegro_ttf_version();

    #endregion

    public FontContext()
    {
      AlInitFontAddon = LoadFunction<al_init_font_addon>();
      AlIsFontAddonInitialized = LoadFunction<al_is_font_addon_initialized>();
      AlShutdownFontAddon = LoadFunction<al_shutdown_font_addon>();
      AlLoadFont = LoadFunction<al_load_font>();
      AlDestroyFont = LoadFunction<al_destroy_font>();
      AlRegisterFontLoader = LoadFunction<al_register_font_loader>();
      AlGetFontLineHeight = LoadFunction<al_get_font_line_height>();
      AlGetFontAscent = LoadFunction<al_get_font_ascent>();
      AlGetFontDescent = LoadFunction<al_get_font_descent>();
      AlGetTextWidth = LoadFunction<al_get_text_width>();
      AlGetUstrWidth = LoadFunction<al_get_ustr_width>();
      AlDrawText = LoadFunction<al_draw_text>();
      AlDrawUstr = LoadFunction<al_draw_ustr>();
      AlDrawJustifiedText = LoadFunction<al_draw_justified_text>();
      AlDrawJustifiedUstr = LoadFunction<al_draw_justified_ustr>();
      AlGetTextDimensions = LoadFunction<al_get_text_dimensions>();
      AlGetUstrDimensions = LoadFunction<al_get_ustr_dimensions>();
      AlGetAllegroFontVersion = LoadFunction<al_get_allegro_font_version>();
      AlGetFontRanges = LoadFunction<al_get_font_ranges>();
      AlSetFallbackFont = LoadFunction<al_set_fallback_font>();
      AlGetFallbackFont = LoadFunction<al_get_fallback_font>();
      AlDrawGlyph = LoadFunction<al_draw_glyph>();
      AlDrawGlyphWidth = LoadFunction<al_get_glyph_width>();
      AlGetGlyphDimensions = LoadFunction<al_get_glyph_dimensions>();
      AlGetGlyphAdvance = LoadFunction<al_get_glyph_advance>();
      AlDrawMultilineText = LoadFunction<al_draw_multiline_text>();
      AlDrawMultilineUstr = LoadFunction<al_draw_multiline_ustr>();
      AlDoMultilineText = LoadFunction<al_do_multiline_text>();
      AlDoMultilineUstr = LoadFunction<al_do_multiline_ustr>();
      AlGrabFontFromBitmap = LoadFunction<al_grab_font_from_bitmap>();
      AlLoadBitmapFont = LoadFunction<al_load_bitmap_font>();
      AlLoadBitmapFontFlags = LoadFunction<al_load_bitmap_font_flags>();
      AlCreateBuiltinFont = LoadFunction<al_create_builtin_font>();
      AlInitTtfAddon = LoadFunction<al_init_ttf_addon>();
      AlIsTtfAddonInitialized = LoadFunction<al_is_ttf_addon_initialized>();
      AlShutdownTtfAddon = LoadFunction<al_shutdown_ttf_addon>();
      AlLoadTtfFont = LoadFunction<al_load_ttf_font>();
      AlLoadTtfFontF = LoadFunction<al_load_ttf_font_f>();
      AlLoadTtfFontStretch = LoadFunction<al_load_ttf_font_stretch>();
      AlLoadTtfFontStretchF = LoadFunction<al_load_ttf_font_stretch_f>();
      AlGetAllegroTtfVersion = LoadFunction<al_get_allegro_ttf_version>();
    }
  }
}
