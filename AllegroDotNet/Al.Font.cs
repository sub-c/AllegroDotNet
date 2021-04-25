using System;
using System.Runtime.InteropServices;
using System.Security;
using AllegroDotNet.Enums;
using AllegroDotNet.Models;
using AllegroDotNet.Native;

namespace AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr LoadFontDelegate(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int size,
            int flags);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate bool TextCallbackDelegate(
            int lineNum,
            [MarshalAs(UnmanagedType.LPStr)] string line,
            int size,
            IntPtr extra);

        public static bool InitFontAddon()
            => al_init_font_addon();

        public static bool IsFontAddonInitialized()
            => al_is_font_addon_initialized();

        public static void ShutdownFontAddon()
            => al_shutdown_font_addon();
        
        public static AllegroFont LoadFont(string filename, int size, LoadFontFlags flags)
        {
            var nativeFont = al_load_font(filename, size, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static void DestroyFont(AllegroFont font)
            => al_destroy_font(font.NativeIntPtr);

        public static bool RegisterFontLoader(string extension, LoadFontDelegate loadFont, int size, LoadFontFlags flags)
            => al_register_font_loader(extension, loadFont, size, (int)flags);

        public static int GetFontLineHeight(AllegroFont font)
            => al_get_font_line_height(font.NativeIntPtr);

        public static int GetFontAscent(AllegroFont font)
            => al_get_font_ascent(font.NativeIntPtr);

        public static int GetFontDescent(AllegroFont font)
            => al_get_font_descent(font.NativeIntPtr);

        public static int GetTextWidth(AllegroFont font, string str)
            => al_get_text_width(font.NativeIntPtr, str);

        public static int GetUStrWidth(AllegroFont font, AllegroUStr uStr)
            => al_get_ustr_width(font.NativeIntPtr, uStr.NativeIntPtr);

        public static void DrawText(AllegroFont font, AllegroColor color, float x, float y, DrawFontFlags flags, string text)
            => al_draw_text(font.NativeIntPtr, color.Native, x, y, (int)flags, text);

        public static void DrawUStr(AllegroFont font, AllegroColor color, float x, float y, DrawFontFlags flags, AllegroUStr uStr)
            => al_draw_ustr(font.NativeIntPtr, color.Native, x, y, (int)flags, uStr.NativeIntPtr);

        public static void DrawJustifiedText(
            AllegroFont font,
            AllegroColor color,
            float x1,
            float x2,
            float y,
            float diff,
            DrawFontFlags flags,
            string text)
            => al_draw_justified_text(font.NativeIntPtr, color.Native, x1, x2, y, diff, (int)flags, text);

        public static void DrawJustifiedUStr(
            AllegroFont font,
            AllegroColor color,
            float x1,
            float x2,
            float y,
            float diff,
            DrawFontFlags flags,
            AllegroUStr uStr)
            => al_draw_justified_ustr(font.NativeIntPtr, color.Native, x1, x2, y, diff, (int)flags, uStr.NativeIntPtr);

        public static void DrawTextF(
            AllegroFont font,
            AllegroColor color,
            float x,
            float y,
            DrawFontFlags flags,
            string format,
            params object[] varArgs)
        {
            throw new NotImplementedException();
        }

        public static void DrawJustifiedTextF(
            AllegroFont font,
            AllegroColor color,
            float x1,
            float x2,
            float y,
            float diff,
            DrawFontFlags flags,
            string format,
            params object[] varArgs)
        {
            throw new NotImplementedException();
        }

        public static void GetTextDimensions(
            AllegroFont font,
            string text,
            ref int bbx,
            ref int bby,
            ref int bbw,
            ref int bbh)
            => al_get_text_dimensions(font.NativeIntPtr, text, ref bbx, ref bby, ref bbw, ref bbh);

        public static void GetUStrDimensions(AllegroFont font, AllegroUStr uStr, ref int bbx, ref int bby, ref int bbw, ref int bbh)
            => al_get_ustr_dimensions(font.NativeIntPtr, uStr.NativeIntPtr, ref bbx, ref bby, ref bbw, ref bbh);

        public static uint GetAllegroFontVersion()
            => al_get_allegro_font_version();

        public static int GetFontRanges(AllegroFont font, int rangesCount, ref int ranges)
            => al_get_font_ranges(font.NativeIntPtr, rangesCount, ref ranges);

        public static void SetFallbackFont(AllegroFont font, AllegroFont fallback)
            => al_set_fallback_font(font.NativeIntPtr, fallback.NativeIntPtr);

        public static AllegroFont GetFallbackFont(AllegroFont font)
        {
            var nativeFont = al_get_fallback_font(font.NativeIntPtr);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static void DrawGlyph(AllegroFont font, AllegroColor color, float x, float y, int codePoint)
            => al_draw_glyph(font.NativeIntPtr, color.Native, x, y, codePoint);

        public static int GetGlyphWidth(AllegroFont font, int codePoint)
            => al_get_glyph_width(font.NativeIntPtr, codePoint);

        public static bool GetGlyphDimensions(AllegroFont font, int codePoint, ref int bbx, ref int bby, ref int bbw, ref int bbh)
            => al_get_glyph_dimensions(font.NativeIntPtr, codePoint, ref bbx, ref bby, ref bbw, ref bbh);

        public static int GetGlyphAdvance(AllegroFont font, int codePoint1, int codePoint2)
            => al_get_glyph_advance(font.NativeIntPtr, codePoint1, codePoint2);

        public static void DrawMultilineText(
            AllegroFont font,
            AllegroColor color,
            float x,
            float y,
            float maxWidth,
            float lineHeight,
            DrawFontFlags flags,
            string text)
            => al_draw_multiline_text(font.NativeIntPtr, color.Native, x, y, maxWidth, lineHeight);

        public static void DrawMultilineUStr(
            AllegroFont font,
            AllegroColor color,
            float x,
            float y,
            float maxWidth,
            float lineHeight,
            DrawFontFlags flags,
            AllegroUStr uStr)
            => al_draw_multiline_ustr(font.NativeIntPtr, color.Native, x, y, maxWidth, lineHeight, (int)flags, uStr.NativeIntPtr);

        public static void DrawMultilineTextF(
            AllegroFont font,
            AllegroColor color,
            float x,
            float y,
            float maxWidth,
            float lineHeight,
            DrawFontFlags flags,
            string format,
            params object[] varArgs)
        {
            throw new NotImplementedException();
        }

        public static void DoMultilineText(
            AllegroFont font,
            float maxWidth,
            string text,
            TextCallbackDelegate callback,
            IntPtr extra)
        {
            throw new NotImplementedException();
        }

        public static void DoMultilineUStr(
            AllegroFont font,
            float maxWidth,
            AllegroUStr uStr,
            TextCallbackDelegate callback,
            IntPtr extra)
        {
            throw new NotImplementedException();
        }

        public static AllegroFont GrabFontFromBitmap(AllegroBitmap bitmap, int rangesN, int[] ranges)
        {
            var nativeFont = al_grab_font_from_bitmap(bitmap.NativeIntPtr, rangesN, ranges);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static AllegroFont LoadBitmapFont(string filename)
        {
            var nativeFont = al_load_bitmap_font(filename);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static AllegroFont LoadBitmapFontFlags(string filename, BitmapLoadFlags flags)
        {
            var nativeFont = al_load_bitmap_font_flags(filename, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static AllegroFont CreateBuiltInFont()
        {
            var nativeFont = al_create_builtin_font();
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static bool InitTtfAddon()
            => al_init_ttf_addon();

        public static bool IsTtfAddonInitialized()
            => al_is_ttf_addon_initialized();

        public static void ShutdownTtfAddon()
            => al_shutdown_ttf_addon();

        public static AllegroFont LoadTtfFont(string filename, int size, LoadTtfFontFlags flags)
        {
            var nativeFont = al_load_ttf_font(filename, size, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static AllegroFont LoadTtfFontF(AllegroFile file, string filename, int size, LoadTtfFontFlags flags)
        {
            var nativeFont = al_load_ttf_font_f(file.NativeIntPtr, filename, size, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static AllegroFont LoadTtfFontStretch(string filename, int w, int h, LoadTtfFontFlags flags)
        {
            var nativeFont = al_load_ttf_font_stretch(filename, w, h, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        public static AllegroFont LoadTtfFontStretchF(AllegroFile file, string filename, int w, int h, LoadTtfFontFlags flags)
        {
            var nativeFont = al_load_ttf_font_stretch_f(file.NativeIntPtr, filename, w, h, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as <see cref="Al.GetAllegroVersion"/>.
        /// </summary>
        /// <returns>The (compiled) version of the addon, in the same format as <see cref="Al.GetAllegroVersion"/>.</returns>
        public static uint GetAllegroTtfVersion()
            => al_get_allegro_ttf_version();

        #region P/Invokes
        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_init_font_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_font_addon_initialized();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_shutdown_font_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_font([MarshalAs(UnmanagedType.LPStr)] string filename, int size, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_destroy_font(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_register_font_loader(
            [MarshalAs(UnmanagedType.LPStr)] string extension,
            LoadFontDelegate load_font,
            int size,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_font_line_height(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_font_ascent(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_font_descent(IntPtr f);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_text_width(IntPtr f, [MarshalAs(UnmanagedType.LPStr)] string str);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_ustr_width(IntPtr f, IntPtr ustr);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        [SuppressUnmanagedCodeSecurity]
        private static extern void al_draw_text(
            IntPtr font,
            NativeAllegroColor color,
            float x,
            float y,
            int flags,
            [MarshalAs(UnmanagedType.LPStr)] string text);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_ustr(
            IntPtr font,
            NativeAllegroColor color,
            float x,
            float y,
            int flags,
            IntPtr ustr);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_justified_text(
            IntPtr font,
            NativeAllegroColor color,
            float x1,
            float x2,
            float y,
            float diff,
            int flags,
            [MarshalAs(UnmanagedType.LPStr)] string text);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_justified_ustr(
            IntPtr font,
            NativeAllegroColor color,
            float x1,
            float x2,
            float y,
            float diff,
            int flags,
            IntPtr ustr);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_textf(
            IntPtr font,
            NativeAllegroColor color,
            float x,
            float y,
            int flags,
            [MarshalAs(UnmanagedType.LPStr)] string format,
            __arglist);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_justified_textf(
            IntPtr font,
            NativeAllegroColor color,
            float x1,
            float x2,
            float y,
            float diff,
            int flags,
            [MarshalAs(UnmanagedType.LPStr)] string format,
            __arglist);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_get_text_dimensions(
            IntPtr f,
            [MarshalAs(UnmanagedType.LPStr)] string text,
            ref int bbx,
            ref int bby,
            ref int bbw,
            ref int bbh);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_get_ustr_dimensions(
            IntPtr font,
            IntPtr ustr,
            ref int bbx,
            ref int bby,
            ref int bbw,
            ref int bbh);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_font_version();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_font_ranges(IntPtr font, int rangesCount, ref int ranges);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_set_fallback_font(IntPtr font, IntPtr fallback);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_get_fallback_font(IntPtr font);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_glyph(IntPtr f, NativeAllegroColor color, float x, float y, int codepoint);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_glyph_width(IntPtr f, int codepoint);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_get_glyph_dimensions(
            IntPtr f,
            int codepoint,
            ref int bbx,
            ref int bby,
            ref int bbw,
            ref int bbh);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern int al_get_glyph_advance(IntPtr f, int codepoint1, int codepoint2);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_multiline_text(
            IntPtr font,
            NativeAllegroColor color,
            float x,
            float y,
            float max_width,
            float line_height);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_multiline_ustr(
            IntPtr font,
            NativeAllegroColor color,
            float x,
            float y,
            float max_width,
            float line_height,
            int flags,
            IntPtr ustr);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_draw_multiline_textf(
            IntPtr font,
            NativeAllegroColor color,
            float x,
            float y,
            float max_width,
            float line_height,
            int flags,
            [MarshalAs(UnmanagedType.LPStr)] string format,
            __arglist);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_do_multiline_text(
            IntPtr font,
            float max_width,
            [MarshalAs(UnmanagedType.LPStr)] string text,
            IntPtr cb,
            IntPtr extra);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_do_multiline_ustr(
            IntPtr font,
            float max_width,
            IntPtr ustr,
            IntPtr cb,
            IntPtr extra);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_grab_font_from_bitmap(IntPtr bmp, int ranges_n, int[] ranges);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_bitmap_font([MarshalAs(UnmanagedType.LPStr)] string fname);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_bitmap_font_flags([MarshalAs(UnmanagedType.LPStr)] string fname, int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_create_builtin_font();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_init_ttf_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern bool al_is_ttf_addon_initialized();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern void al_shutdown_ttf_addon();

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_ttf_font(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int size,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_ttf_font_f(
            IntPtr file,
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int size,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_ttf_font_stretch(
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int w,
            int h,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern IntPtr al_load_ttf_font_stretch_f(
            IntPtr file,
            [MarshalAs(UnmanagedType.LPStr)] string filename,
            int w,
            int h,
            int flags);

        [DllImport(AlConstants.AllegroMonolithDllFilename)]
        private static extern uint al_get_allegro_ttf_version();
        #endregion
    }
}
