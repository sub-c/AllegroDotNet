using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using static SubC.AllegroDotNet.Native.NativeDelegates;
using System;

namespace SubC.AllegroDotNet.Extensions
{
  public static class AllegroFontExtensions
  {
    public static void DestroyFont(this AllegroFont? font)
      => Al.DestroyFont(font);

    public static int GetFontLineHeight(this AllegroFont? font)
      => Al.GetFontLineHeight(font);

    public static int GetFontAscent(this AllegroFont? font)
      => Al.GetFontAscent(font);

    public static int GetFontDescent(this AllegroFont? font)
      => Al.GetFontDescent(font);

    public static int GetTextWidth(this AllegroFont? font, string text)
      => Al.GetTextWidth(font, text);

    public static int GetUstrWidth(this AllegroFont? font, AllegroUstr? ustr)
      => Al.GetUstrWidth(font, ustr);

    public static void DrawText(this AllegroFont? font, AllegroColor color, float x, float y, FontAlignFlags flags, string text)
      => Al.DrawText(font, color, x, y, flags, text);

    public static void DrawUstr(this AllegroFont? font, AllegroColor color, float x, float y, FontAlignFlags flags, AllegroUstr? ustr)
      => Al.DrawUstr(font, color, x, y, flags, ustr);

    public static void DrawJustifiedText(this AllegroFont? font, AllegroColor color, float x1, float x2, float y, float diff, FontAlignFlags flags, string text)
      => Al.DrawJustifiedText(font, color, x1, x2, y, diff, flags, text);

    public static void DrawJustifiedUstr(this AllegroFont? font, AllegroColor color, float x1, float x2, float y, float diff, FontAlignFlags flags, AllegroUstr? ustr)
      => Al.DrawJustifiedUstr(font, color, x1, x2, y, diff, flags, ustr);

    public static void DrawTextF(this AllegroFont? font, AllegroColor color, float x, float y, FontAlignFlags flags, string format, params object[] args)
      => Al.DrawTextF(font, color, x, y, flags, format, args);

    public static void DrawJustifiedTextf(this AllegroFont? font, AllegroColor color, float x1, float x2, float y, float diff, FontAlignFlags flags, string format, params object[] args)
      => Al.DrawJustifiedTextF(font, color, x1, x2, y, diff, flags, format, args);

    public static void GetTextDimensions(this AllegroFont? font, string text, out int x, out int y, out int width, out int height)
      => Al.GetTextDimensions(font, text, out x, out y, out width, out height);

    public static void GetUstrDimensions(this AllegroFont? font, AllegroUstr? ustr, out int x, out int y, out int width, out int height)
      => Al.GetUstrDimensions(font, ustr, out x, out y, out width, out height);

    public static int GetFontRanges(this AllegroFont? font, int rangesCount, ref int[] ranges)
      => Al.GetFontRanges(font, rangesCount, ref ranges);

    public static void SetFallbackFont(this AllegroFont? font, AllegroFont? fallback)
      => Al.SetFallbackFont(font, fallback);

    public static AllegroFont? GetFallbackFont(this AllegroFont? font)
      => Al.GetFallbackFont(font);

    public static void DrawGlyph(this AllegroFont? font, AllegroColor color, float x, float y, int codePoint)
      => Al.DrawGlyph(font, color, x, y, codePoint);

    public static int GetGlyphWidth(this AllegroFont? font, int codePoint)
      => Al.GetGlyphWidth(font, codePoint);

    public static bool GetGlyphDimensions(this AllegroFont? font, int codePoint, out int x, out int y, out int width, out int height)
      => Al.GetGlyphDimensions(font, codePoint, out x, out y, out width, out height);

    public static int GetGlyphAdvance(this AllegroFont? font, int codePoint1, int codePoint2)
      => Al.GetGlyphAdvance(font, codePoint1, codePoint2);

    public static void DrawMultilineText(this AllegroFont? font, AllegroColor color, float x, float y, float maxWidth, float lineHeight, FontAlignFlags flags, string text)
      => Al.DrawMultilineText(font, color, x, y, maxWidth, lineHeight, flags, text);

    public static void DrawMultilineUstr(this AllegroFont? font, AllegroColor color, float x, float y, float maxWidth, float lineHeight, FontAlignFlags flags, AllegroUstr? ustr)
      => Al.DrawMultilineUstr(font, color, x, y, maxWidth, lineHeight, flags, ustr);

    public static void DrawMultilineTextF(this AllegroFont? font, AllegroColor color, float x, float y, float maxWidth, float lineHeight, FontAlignFlags flags, string format, params object[] args)
      => Al.DrawMultilineTextF(font, color, x, y, maxWidth, lineHeight, flags, format, args);

    public static void DoMultilineText(this AllegroFont? font, float maxWidth, string text, DoMultilineText callback, IntPtr extra)
      => Al.DoMultilineText(font, maxWidth, text, callback, extra);

    public static void DoMultilineUstr(this AllegroFont? font, float maxWidth, AllegroUstr? ustr, DoMultilineUstr callback, IntPtr extra)
      => Al.DoMultilineUstr(font, maxWidth, ustr, callback, extra);
  }
}
