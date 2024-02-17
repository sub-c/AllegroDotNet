using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static bool InitFontAddon()
  {
    return Interop.Font.AlInitFontAddon() != 0;
  }

  public static bool IsFontAddonInitialized()
  {
    return Interop.Font.AlIsFontAddonInitialized() != 0;
  }

  public static void ShutdownFontAddon()
  {
    Interop.Font.AlShutdownFontAddon();
  }

  public static AllegroFont? LoadFont(string filename, int size, LoadFontFlags flags)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Font.AlLoadFont(nativeFilename.Pointer, size, (int)flags);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static void DestroyFont(AllegroFont? font)
  {
    Interop.Font.AlDestroyFont(NativePointer.Get(font));
  }

  public static bool RegisterFontLoader(string extension, Delegates.RegisterFontLoaderDelegate? loadFont)
  {
    using var nativeExtension = new CStringAnsi(extension);
    return Interop.Font.AlRegisterFontLoader(nativeExtension.Pointer, loadFont) != 0;
  }

  public static int GetFontLineHeight(AllegroFont? font)
  {
    return Interop.Font.AlGetFontLineHeight(NativePointer.Get(font));
  }

  public static int GetFontAscent(AllegroFont? font)
  {
    return Interop.Font.AlGetFontAscent(NativePointer.Get(font));
  }

  public static int GetFontDescent(AllegroFont? font)
  {
    return Interop.Font.AlGetFontDescent(NativePointer.Get(font));
  }

  public static int GetTextWidth(AllegroFont? font, string text)
  {
    using var nativeText = new CStringAnsi(text);
    return Interop.Font.AlGetTextWidth(NativePointer.Get(font), nativeText.Pointer);
  }

  public static int GetUstrWidth(AllegroFont? font, AllegroUstr? ustr)
  {
    return Interop.Font.AlGetUstrWidth(NativePointer.Get(font), NativePointer.Get(ustr));
  }

  public static void DrawText(
    AllegroFont? font, 
    AllegroColor color, 
    float x, 
    float y, 
    FontAlignFlags flags, 
    string text)
  {
    using var nativeText = new CStringAnsi(text);
    Interop.Font.AlDrawText(NativePointer.Get(font), color, x, y, (int)flags, nativeText.Pointer);
  }

  public static void DrawUstr(
    AllegroFont? font,
    AllegroColor color,
    float x,
    float y,
    FontAlignFlags flags,
    AllegroUstr? ustr)
  {
    Interop.Font.AlDrawUstr(NativePointer.Get(font), color, x, y, (int)flags, NativePointer.Get(ustr));
  }

  public static void DrawJustifiedText(
    AllegroFont? font,
    AllegroColor color,
    float x1,
    float x2,
    float y,
    float diff,
    FontAlignFlags flags,
    string text)
  {
    using var nativeText = new CStringAnsi(text);
    Interop.Font.AlDrawJustifiedText(
      NativePointer.Get(font), 
      color, 
      x1, 
      x2, 
      y, 
      diff, 
      (int)flags, 
      nativeText.Pointer);
  }

  public static void DrawJustifiedUstr(
    AllegroFont? font,
    AllegroColor color,
    float x1,
    float x2,
    float y,
    float diff,
    FontAlignFlags flags,
    AllegroUstr? ustr)
  {
    Interop.Font.AlDrawJustifiedUstr(
      NativePointer.Get(font),
      color,
      x1,
      x2,
      y,
      diff, 
      (int)flags,
      NativePointer.Get(ustr));
  }

  public static void GetTextDimensions(
    AllegroFont? font,
    string text,
    ref int bbx,
    ref int bby,
    ref int bbw,
    ref int bbh)
  {
    using var nativeText = new CStringAnsi(text);
    Interop.Font.AlGetTextDimensions(
      NativePointer.Get(font),
      nativeText.Pointer,
      ref bbx,
      ref bby,
      ref bbw,
      ref bbh);
  }

  public static void GetUstrDimensions(
    AllegroFont? font,
    AllegroUstr? ustr,
    ref int bbx,
    ref int bby,
    ref int bbw,
    ref int bbh)
  {
    Interop.Font.AlGetUstrDimensions(
      NativePointer.Get(font),
      NativePointer.Get(ustr),
      ref bbx,
      ref bby,
      ref bbw,
      ref bbh);
  }

  public static uint GetAllegroFontVersion()
  {
    return Interop.Font.AlGetAllegroFontVersion();
  }

  public static int GetFontRanges(AllegroFont? font, int rangesCount, out int[] ranges)
  {
    ranges = new int[rangesCount * 2];
    return Interop.Font.AlGetFontRanges(NativePointer.Get(font), rangesCount, ranges);
  }

  public static void SetFallbackFont(AllegroFont? font, AllegroFont? fallback)
  {
    Interop.Font.AlSetFallbackFont(NativePointer.Get(font), NativePointer.Get(fallback));
  }

  public static AllegroFont? GetFallbackFont(AllegroFont? font)
  {
    var pointer = Interop.Font.AlGetFallbackFont(NativePointer.Get(font));
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static void DrawGlyph(AllegroFont? font, AllegroColor color, float x, float y, int codePoint)
  {
    Interop.Font.AlDrawGlyph(NativePointer.Get(font), color, x, y, codePoint);
  }

  public static bool GetGlyphDimensions(AllegroFont? font, int codePoint, ref int bbx, ref int bby, ref int bbw, ref int bbh)
  {
    return Interop.Font.AlGetGlyphDimensions(NativePointer.Get(font), codePoint, ref bbx, ref bby, ref bbw, ref bbh) != 0;
  }

  public static int GetGlyphAdvance(AllegroFont? font, int codePoint1, int codePoint2)
  {
    return Interop.Font.AlGetGlyphAdvance(NativePointer.Get(font), codePoint1, codePoint2);
  }

  public static void DrawMultilineText(
    AllegroFont? font,
    AllegroColor color,
    float x,
    float y,
    float maxWidth,
    float lineHeight,
    FontAlignFlags flags,
    string text)
  {
    using var nativeText = new CStringAnsi(text);
    Interop.Font.AlDrawMultilineText(
      NativePointer.Get(font),
      color,
      x,
      y,
      maxWidth,
      lineHeight,
      (int)flags,
      nativeText.Pointer);
  }

  public static void DrawMultilineUstr(
    AllegroFont? font,
    AllegroColor color,
    float x,
    float y,
    float maxWidth,
    float lineHeight,
    FontAlignFlags flags,
    AllegroUstr? ustr)
  {
    Interop.Font.AlDrawMultilineUstr(NativePointer.Get(font), color, x, y, maxWidth, lineHeight, (int)flags, NativePointer.Get(ustr));
  }

  public static void DoMultilineText(
    AllegroFont? font,
    float maxWidth,
    string text,
    Delegates.DoMultilineTextCallbackDelegate? callback,
    IntPtr extra)
  {
    using var nativeText = new CStringAnsi(text);
    Interop.Font.AlDoMultilineText(NativePointer.Get(font), maxWidth, nativeText.Pointer, callback, extra);
  }

  public static void DoMultilineUstr(
    AllegroFont? font,
    float maxWidth,
    AllegroUstr? ustr,
    Delegates.DoMultilineUstrCallbackDelegate? callback,
    IntPtr extra)
  {
    Interop.Font.AlDoMultilineUstr(NativePointer.Get(font), maxWidth, NativePointer.Get(ustr), callback, extra);
  }

  public static AllegroFont? GrabFontFromBitmap(AllegroBitmap? bitmap, int rangesN, int[] ranges)
  {
    var pointer = Interop.Font.AlGrabFontFromBitmap(NativePointer.Get(bitmap), rangesN, ranges);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static AllegroFont? LoadBitmapFont(string filename)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Font.AlLoadBitmapFont(nativeFilename.Pointer);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static AllegroFont? LoadBitmapFontFlags(string filename, BitmapFlags flags)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Font.AlLoadBitmapFontFlags(nativeFilename.Pointer, (int)flags);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static AllegroFont? CreateBuiltinFont()
  {
    var pointer = Interop.Font.AlCreateBuiltinFont();
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static bool InitTtfAddon()
  {
    return Interop.Font.AlInitTtfAddon() != 0;
  }

  public static bool IsTtfAddonInitialized()
  {
    return Interop.Font.AlIsTtfAddonInitialized() != 0;
  }

  public static void ShutdownTtfAddon()
  {
    Interop.Font.AlShutdownTtfAddon();
  }

  public static AllegroFont? LoadTtfFont(string filename, int size, LoadFontFlags flags)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Font.AlLoadTtfFont(nativeFilename.Pointer, size, (int)flags);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static AllegroFont? LoadTtfFontF(AllegroFile? file, string filename, int size, LoadFontFlags flags)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Font.AlLoadTtfFontF(NativePointer.Get(file), nativeFilename.Pointer, size, (int)flags);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static AllegroFont? LoadTtfFontStretch(string filename, int width, int height, LoadFontFlags flags)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Font.AlLoadTtfFontStretch(nativeFilename.Pointer, width, height, (int)flags);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static AllegroFont? LoadTtfFontStretchF(AllegroFile? file, string filename, int width, int height, LoadFontFlags flags)
  {
    using var nativeFilename = new CStringAnsi(filename);
    var pointer = Interop.Font.AlLoadTtfFontStretchF(NativePointer.Get(file), nativeFilename.Pointer, width, height, (int)flags);
    return NativePointer.Create<AllegroFont>(pointer);
  }

  public static uint GetAllegroTtfVersion()
  {
    return Interop.Font.AlGetAllegroTtfVersion();
  }
}
