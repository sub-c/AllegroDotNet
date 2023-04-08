using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;
using static SubC.AllegroDotNet.Native.NativeDelegates;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static bool InitFontAddon()
  {
    return NativeFunctions.AlInitFontAddon();
  }

  public static bool IsFontAddonInitialized()
  {
    return NativeFunctions.AlIsFontAddonInitialized();
  }

  public static void ShutdownFontAddon()
  {
    NativeFunctions.AlShutdownFontAddon();
  }

  public static AllegroFont? LoadFont(string filename, int size, LoadFontFlags flags)
  {
    var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
    var result = NativeFunctions.AlLoadFont(nativeFilename, size, (int)flags);
    Marshal.FreeHGlobal(nativeFilename);
    return NativePointerModel.Create<AllegroFont>(result);
  }

  public static void DestroyFont(AllegroFont? font)
  {
    NativeFunctions.AlDestroyFont(NativePointerModel.GetPointer(font));
  }

  public static bool RegisterFontLoader(string extension, RegisterFontLoader loader)
  {
    var nativeExtension = Marshal.StringToHGlobalAnsi(extension);
    var result = NativeFunctions.AlRegisterFontLoader(nativeExtension, loader);
    Marshal.FreeHGlobal(nativeExtension);
    return result;
  }

  public static int GetFontLineHeight(AllegroFont? font)
  {
    return NativeFunctions.AlGetFontLineHeight(NativePointerModel.GetPointer(font));
  }

  public static int GetFontAscent(AllegroFont? font)
  {
    return NativeFunctions.AlGetFontAscent(NativePointerModel.GetPointer(font));
  }

  public static int GetFontDescent(AllegroFont? font)
  {
    return NativeFunctions.AlGetFontDescent(NativePointerModel.GetPointer(font));
  }

  public static int GetTextWidth(AllegroFont? font, string text)
  {
    var nativeText = Marshal.StringToHGlobalAnsi(text);
    var result = NativeFunctions.AlGetTextWidth(NativePointerModel.GetPointer(font), nativeText);
    Marshal.FreeHGlobal(nativeText);
    return result;
  }

  public static int GetUstrWidth(AllegroFont? font, AllegroUstr? ustr)
  {
    return NativeFunctions.AlGetUstrWidth(NativePointerModel.GetPointer(font), NativePointerModel.GetPointer(ustr));
  }

  public static void DrawText(AllegroFont? font, AllegroColor color, float x, float y, FontAlignFlags flags, string text)
  {
    var nativeText = Marshal.StringToHGlobalAnsi(text);
    NativeFunctions.AlDrawText(NativePointerModel.GetPointer(font), color, x, y, (int)flags, nativeText);
    Marshal.FreeHGlobal(nativeText);
  }

  public static void DrawUstr(AllegroFont? font, AllegroColor color, float x, float y, FontAlignFlags flags, AllegroUstr? ustr)
  {
    NativeFunctions.AlDrawUstr(NativePointerModel.GetPointer(font), color, x, y, (int)flags, NativePointerModel.GetPointer(ustr));
  }

  public static void DrawJustifiedText(AllegroFont? font, AllegroColor color, float x1, float x2, float y, float diff, FontAlignFlags flags, string text)
  {
    var nativeText = Marshal.StringToHGlobalAnsi(text);
    NativeFunctions.AlDrawJustifiedText(NativePointerModel.GetPointer(font), color, x1, x2, y, diff, (int)flags, nativeText);
    Marshal.FreeHGlobal(nativeText);
  }

  public static void DrawJustifiedUstr(AllegroFont? font, AllegroColor color, float x1, float x2, float y, float diff, FontAlignFlags flags, AllegroUstr? ustr)
  {
    NativeFunctions.AlDrawJustifiedUstr(NativePointerModel.GetPointer(font), color, x1, x2, y, diff, (int)flags, NativePointerModel.GetPointer(ustr));
  }

  public static void DrawTextF(AllegroFont? font, AllegroColor color, float x, float y, FontAlignFlags flags, string format, params object[] args)
  {
    format = string.Format(format, args);
    DrawText(font, color, x, y, flags, format);
  }

  public static void DrawJustifiedTextF(AllegroFont? font, AllegroColor color, float x1, float x2, float y, float diff, FontAlignFlags flags, string format, params object[] args)
  {
    format = string.Format(format, args);
    DrawJustifiedText(font, color, x1, x2, y, diff, flags, format);
  }

  public static void GetTextDimensions(AllegroFont? font, string text, out int x, out int y, out int width, out int height)
  {
    x = y = width = height = 0;
    var nativeText = Marshal.StringToHGlobalAnsi(text);
    NativeFunctions.AlGetTextDimensions(NativePointerModel.GetPointer(font), nativeText, ref x, ref y, ref width, ref height);
    Marshal.FreeHGlobal(nativeText);
  }

  public static void GetUstrDimensions(AllegroFont? font, AllegroUstr? ustr, out int x, out int y, out int width, out int height)
  {
    x = y = width = height = 0;
    NativeFunctions.AlGetUstrDimensions(NativePointerModel.GetPointer(font), NativePointerModel.GetPointer(ustr), ref x, ref y, ref width, ref height);
  }

  public static uint GetAllegroFontVersion()
  {
    return NativeFunctions.AlGetAllegroFontVersion();
  }

  public static int GetFontRanges(AllegroFont? font, int rangeCount, ref int[] ranges)
  {
    return NativeFunctions.AlGetFontRanges(NativePointerModel.GetPointer(font), rangeCount, ref ranges);
  }

  public static void SetFallbackFont(AllegroFont? font, AllegroFont? fallback)
  {
    NativeFunctions.AlSetFallbackFont(NativePointerModel.GetPointer(font), NativePointerModel.GetPointer(fallback));
  }

  public static AllegroFont? GetFallbackFont(AllegroFont? font)
  {
    var result = NativeFunctions.AlGetFallbackFont(NativePointerModel.GetPointer(font));
    return NativePointerModel.Create<AllegroFont>(result);
  }

  public static void DrawGlyph(AllegroFont? font, AllegroColor color, float x, float y, int codePoint)
  {
    NativeFunctions.AlDrawGlyph(NativePointerModel.GetPointer(font), color, x, y, codePoint);
  }

  public static int GetGlyphWidth(AllegroFont? font, int codePoint)
  {
    return NativeFunctions.AlGetGlyphWidth(NativePointerModel.GetPointer(font), codePoint);
  }

  public static bool GetGlyphDimensions(AllegroFont? font, int codePoint, out int x, out int y, out int width, out int height)
  {
    x = y = width = height = 0;
    return NativeFunctions.AlGetGlyphDimensions(NativePointerModel.GetPointer(font), codePoint, ref x, ref y, ref width, ref height);
  }

  public static int GetGlyphAdvance(AllegroFont? font, int codePoint1, int codePoint2)
  {
    return NativeFunctions.AlGetGlyphAdvance(NativePointerModel.GetPointer(font), codePoint1, codePoint2);
  }

  public static void DrawMultilineText(AllegroFont? font, AllegroColor color, float x, float y, float maxWidth, float lineHeight, FontAlignFlags flags, string text)
  {
    var nativeText = Marshal.StringToHGlobalAnsi(text);
    NativeFunctions.AlDrawMultilineText(NativePointerModel.GetPointer(font), color, x, y, maxWidth, lineHeight, (int)flags, nativeText);
    Marshal.FreeHGlobal(nativeText);
  }

  public static void DrawMultilineUstr(AllegroFont? font, AllegroColor color, float x, float y, float maxWidth, float lineHeight, FontAlignFlags flags, AllegroUstr? ustr)
  {
    NativeFunctions.AlDrawMultilineUstr(NativePointerModel.GetPointer(font), color, x, y, maxWidth, lineHeight, (int)flags, NativePointerModel.GetPointer(ustr));
  }

  public static void DrawMultilineTextF(AllegroFont? font, AllegroColor color, float x, float y, float maxWidth, float lineHeight, FontAlignFlags flags, string format, params object[] args)
  {
    format = string.Format(format, args);
    DrawMultilineText(font, color, x, y, maxWidth, lineHeight, flags, format);
  }

  public static void DoMultilineText(AllegroFont? font, float maxWidth, string text, DoMultilineText callback, IntPtr extra)
  {
    var nativeText = Marshal.StringToHGlobalAnsi(text);
    NativeFunctions.AlDoMultilineText(NativePointerModel.GetPointer(font), maxWidth, nativeText, callback, extra);
    Marshal.FreeHGlobal(nativeText);
  }

  public static void DoMultilineUstr(AllegroFont? font, float maxWidth, AllegroUstr? ustr, DoMultilineUstr callback, IntPtr extra)
  {
    NativeFunctions.AlDoMultilineUstr(NativePointerModel.GetPointer(font), maxWidth, NativePointerModel.GetPointer(ustr), callback, extra);
  }

  public static AllegroFont? GrabFontFromBitmap(AllegroBitmap? bitmap, int rangeCount, int[] ranges)
  {
    var result = NativeFunctions.AlGrabFontFromBitmap(NativePointerModel.GetPointer(bitmap), rangeCount, ranges);
    return NativePointerModel.Create<AllegroFont>(result);
  }

  public static AllegroFont? LoadBitmapFont(string filename)
  {
    var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
    var result = NativeFunctions.AlLoadBitmapFont(nativeFilename);
    Marshal.FreeHGlobal(nativeFilename);
    return NativePointerModel.Create<AllegroFont>(result);
  }

  public static AllegroFont? LoadBitmapFontFlags(string filename, LoadFontFlags flags)
  {
    var nativeFilename = Marshal.StringToHGlobalAnsi(filename);
    var result = NativeFunctions.AlLoadBitmapFontFlags(nativeFilename, (int)flags);
    Marshal.FreeHGlobal(nativeFilename);
    return NativePointerModel.Create<AllegroFont>(result);
  }

  public static AllegroFont? CreateBuiltinFont()
  {
    var result = NativeFunctions.AlCreateBuiltinFont();
    return NativePointerModel.Create<AllegroFont>(result);
  }
}
