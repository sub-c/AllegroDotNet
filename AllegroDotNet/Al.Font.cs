using System;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native.Libraries;

namespace SubC.AllegroDotNet
{
    /// <summary>
    /// Allegro game library methods.
    /// </summary>
    public static partial class Al
    {
        /// <summary>
        /// Initialise the font addon.
        /// <para>
        /// Note that if you intend to load bitmap fonts, you will need to initialise the image addon separately
        /// (<see cref="InitImageAddon"/>), unless you are using another library to load images. Similarly, if you
        /// wish to load truetype-fonts, do not forget to also call <see cref="InitTtfAddon"/>.
        /// </para>
        /// </summary>
        /// <returns>
        /// Returns true on success, false on failure. Currently, the function will never return false.
        /// </returns>
        public static bool InitFontAddon() =>
            AllegroLibrary.AlInitFontAddon();

        /// <summary>
        /// Returns true if the font addon is initialized, otherwise returns false.
        /// </summary>
        /// <returns>True if the font addon is initialized, otherwise returns false.</returns>
        public static bool IsFontAddonInitialized() =>
            AllegroLibrary.AlIsFontAddonInitialized();

        /// <summary>
        /// Shut down the font addon. This is done automatically at program exit, but can be called any time the user
        /// wishes as well.
        /// </summary>
        public static void ShutdownFontAddon() =>
            AllegroLibrary.AlShutdownFontAddon();

        /// <summary>
        /// Loads a font from disk. This will use <see cref="LoadBitmapFontFlags(string, BitmapLoadFlags)"/> if you
        /// pass the name of a known bitmap format, or else <see cref="LoadTtfFont(string, int, LoadTtfFontFlags)"/>.
        /// <para>
        /// The flags parameter is passed through to either of those functions. Bitmap and TTF fonts are also affected
        /// by the current bitmap flags at the time the font is loaded.
        /// </para>
        /// </summary>
        /// <param name="filename">The path to the font.</param>
        /// <param name="size">Size of the font to load.</param>
        /// <param name="flags">
        /// The flags used when loading the bitmap; if loading a bitmap font, only bitmap format, premultiplied alpha,
        /// and keep index flags are recognized. If loading a TTF font, only kerning, monochrome, and no auto hint
        /// flags are used.
        /// </param>
        /// <returns>The loaded font instance.</returns>
        public static AllegroFont LoadFont(string filename, int size, LoadFontFlags flags)
        {
            var nativeFont = AllegroLibrary.AlLoadFont(filename, size, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Frees the memory being used by a font structure. Does nothing if passed <c>null</c>.
        /// </summary>
        /// <param name="font">The font to destroy.</param>
        public static void DestroyFont(AllegroFont font)
        {
            var nativeFont = font == null ? IntPtr.Zero : font.NativeIntPtr;
            AllegroLibrary.AlDestroyFont(nativeFont);
        }

        /// <summary>
        /// Informs Allegro of a new font file type, telling it how to load files of this format.
        /// </summary>
        /// <param name="extension">
        /// The extension should include the leading dot (‘.’) character. It will be matched case-insensitively.
        /// </param>
        /// <param name="loadFont">The loadFont argument may be <c>null</c> to unregister an entry.</param>
        /// <returns>
        /// Returns true on success, false on error. Returns false if unregistering an entry that doesn’t exist.
        /// </returns>
        public static bool RegisterFontLoader(string extension, AlConstants.LoadFontDelegate loadFont) =>
            AllegroLibrary.AlRegisterFontLoader(extension, loadFont);

        /// <summary>
        /// Returns the usual height of a line of text in the specified font. For bitmap fonts this is simply the
        /// height of all glyph bitmaps. For truetype fonts it is whatever the font file specifies. In particular,
        /// some special glyphs may be higher than the height returned here.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <returns>The usual height of a line of text in the specified font.</returns>
        public static int GetFontLineHeight(AllegroFont font) =>
            AllegroLibrary.AlGetFontLineHeight(font.NativeIntPtr);

        /// <summary>
        /// Returns the ascent of the specified font.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <returns>The ascent of the font.</returns>
        public static int GetFontAscent(AllegroFont font) =>
            AllegroLibrary.AlGetFontAscent(font.NativeIntPtr);

        /// <summary>
        /// Returns the descent of the specified font.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <returns>The font descent.</returns>
        public static int GetFontDescent(AllegroFont font) =>
            AllegroLibrary.AlGetFontDescent(font.NativeIntPtr);

        /// <summary>
        /// Calculates the length of a string in a particular font, in pixels.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="str">The string of text.</param>
        /// <returns>The width of the given string of text in pixels.</returns>
        public static int GetTextWidth(AllegroFont font, string str) =>
            AllegroLibrary.AlGetTextWidth(font.NativeIntPtr, str);

        /// <summary>
        /// Calculates the length of a string in a particular font, in pixels, using a unicode string.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="uStr">The unicode string of text.</param>
        /// <returns>The width of the given unicode string of text.</returns>
        public static int GetUStrWidth(AllegroFont font, AllegroUStr uStr) =>
            AllegroLibrary.AlGetUstrWidth(font.NativeIntPtr, uStr.NativeIntPtr);

        /// <summary>
        /// Writes the <c>null</c>-terminated string text onto the target bitmap at position x, y, using the specified
        /// font.
        /// <para>
        /// This function does not support newline characters (\n), but you can use
        /// <see cref="DrawMultilineText(AllegroFont, AllegroColor, float, float, float, float, DrawFontFlags, string)"/>
        /// for multi line text output.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="flags">The flags to use when drawing.</param>
        /// <param name="text">The string of text to draw.</param>
        public static void DrawText(AllegroFont font, AllegroColor color, float x, float y, DrawFontFlags flags, string text) =>
            AllegroLibrary.AlDrawText(font.NativeIntPtr, color.Native, x, y, (int)flags, text);

        /// <summary>
        /// Writes the <c>null</c>-terminated uni-code string text onto the target bitmap at position x, y, using the
        /// specified font.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="flags">The flags to use when drawing.</param>
        /// <param name="uStr">The unicode string of text to draw.</param>
        public static void DrawUStr(AllegroFont font, AllegroColor color, float x, float y, DrawFontFlags flags, AllegroUStr uStr) =>
            AllegroLibrary.AlDrawUstr(font.NativeIntPtr, color.Native, x, y, (int)flags, uStr.NativeIntPtr);

        /// <summary>
        /// Writes the <c>null</c>-terminated string text onto the target bitmap at position x, y, justified
        /// to the region x1 - x2, using the specified font.
        /// <para>
        /// The diff parameter is the maximum amount of horizontal space to allow between words. If justisfying the
        /// text would exceed diff pixels, or the string contains less than two words, then the string will be drawn
        /// left aligned.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x1">The starting x position to draw at.</param>
        /// <param name="x2">The maximum x position to draw up to.</param>
        /// <param name="y">The y position.</param>
        /// <param name="diff">The maximum amount of horizontal space to allow between words.</param>
        /// <param name="flags">
        /// Can be <see cref="DrawFontFlags.AlignLeft"/> or <see cref="DrawFontFlags.AlignInteger"/>
        /// </param>
        /// <param name="text">The string of text to draw.</param>
        public static void DrawJustifiedText(AllegroFont font, AllegroColor color, float x1, float x2, float y, float diff, DrawFontFlags flags, string text) =>
            AllegroLibrary.AlDrawJustifiedText(font.NativeIntPtr, color.Native, x1, x2, y, diff, (int)flags, text);

        /// <summary>
        /// Writes the <c>null</c>-terminated uni-code string text onto the target bitmap at position x, y, justified
        /// to the region x1 - x2, using the specified font.
        /// <para>
        /// The diff parameter is the maximum amount of horizontal space to allow between words. If justisfying the
        /// text would exceed diff pixels, or the string contains less than two words, then the string will be drawn
        /// left aligned.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x1">The starting x position to draw at.</param>
        /// <param name="x2">The maximum x position to draw up to.</param>
        /// <param name="y">The y position.</param>
        /// <param name="diff">The maximum amount of horizontal space to allow between words.</param>
        /// <param name="flags">
        /// Can be <see cref="DrawFontFlags.AlignLeft"/> or <see cref="DrawFontFlags.AlignInteger"/>
        /// </param>
        /// <param name="uStr">The unicode string of text to draw.</param>
        public static void DrawJustifiedUStr(AllegroFont font, AllegroColor color, float x1, float x2, float y, float diff, DrawFontFlags flags, AllegroUStr uStr) =>
            AllegroLibrary.AlDrawJustifiedUstr(font.NativeIntPtr, color.Native, x1, x2, y, diff, (int)flags, uStr.NativeIntPtr);

        /// <summary>
        /// Formatted text output, using a printf() style format string.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="flags">The flags to use when drawing.</param>
        /// <param name="format">The format string.</param>
        /// <param name="varArgs">The arguments to put into the string.</param>
        [Obsolete("This method is not implemented, use DrawText().", true)]
        public static void DrawTextF(AllegroFont font, AllegroColor color, float x, float y, DrawFontFlags flags, string format, params object[] varArgs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Formatted justified text output, using a printf() style format string.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x1">The x position to start drawing at.</param>
        /// <param name="x2">The x position to draw up to.</param>
        /// <param name="y">The y position.</param>
        /// <param name="diff">The maximum amount of horizontal space to allow between between words.</param>
        /// <param name="flags">The flags to use when drawing.</param>
        /// <param name="format">The format string.</param>
        /// <param name="varArgs">The arguments to put into the string.</param>
        [Obsolete("This method is not implemented, use DrawJustifiedText().", true)]
        public static void DrawJustifiedTextF(AllegroFont font, AllegroColor color, float x1, float x2, float y, float diff, DrawFontFlags flags, string format, params object[] varArgs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sometimes, the <see cref="GetTextWidth(AllegroFont, string)"/> and
        /// <see cref="GetFontLineHeight(AllegroFont)"/> functions are not enough for exact text placement, so this
        /// function returns some additional information. Note that glyphs may go to the left and upwards of the X,
        /// in which case x and y will have negative values.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="text">The text string.</param>
        /// <param name="bbx">Upper left corner of the bounding box.</param>
        /// <param name="bby">Upper left corner of the bounding box.</param>
        /// <param name="bbw">Dimensions of the bounding box width.</param>
        /// <param name="bbh">Dimensions of the bounding box height.</param>
        public static void GetTextDimensions(AllegroFont font, string text, ref int bbx, ref int bby, ref int bbw, ref int bbh) =>
            AllegroLibrary.AlGetTextDimensions(font.NativeIntPtr, text, ref bbx, ref bby, ref bbw, ref bbh);

        /// <summary>
        /// Sometimes, the <see cref="GetTextWidth(AllegroFont, string)"/> and
        /// <see cref="GetFontLineHeight(AllegroFont)"/> functions are not enough for exact text placement, so this
        /// function returns some additional information. Note that glyphs may go to the left and upwards of the X,
        /// in which case x and y will have negative values.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="uStr">The unicode text string.</param>
        /// <param name="bbx">Upper left corner of the bounding box.</param>
        /// <param name="bby">Upper left corner of the bounding box.</param>
        /// <param name="bbw">Dimensions of the bounding box width.</param>
        /// <param name="bbh">Dimensions of the bounding box height.</param>
        public static void GetUStrDimensions(AllegroFont font, AllegroUStr uStr, ref int bbx, ref int bby, ref int bbw, ref int bbh) =>
            AllegroLibrary.AlGetUstrDimensions(font.NativeIntPtr, uStr.NativeIntPtr, ref bbx, ref bby, ref bbw, ref bbh);

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as <see cref="GetAllegroVersion"/>.
        /// </summary>
        /// <returns>The compiled version of the font addon.</returns>
        public static uint GetAllegroFontVersion() =>
            AllegroLibrary.AlGetAllegroFontVersion();

        /// <summary>
        /// Gets information about all glyphs contained in a font, as a list of ranges. Ranges have the same format
        /// as with <see cref="GrabFontFromBitmap(AllegroBitmap, int, int[])"/>.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="rangesCount">Maximum amount of ranges to be returned.</param>
        /// <param name="ranges">An array with room for <c>rangesCount</c> * 2 elements.</param>
        /// <returns>The number of ranges contained in the font.</returns>
        public static int GetFontRanges(AllegroFont font, int rangesCount, ref int ranges) =>
            AllegroLibrary.AlGetFontRanges(font.NativeIntPtr, rangesCount, ref ranges);

        /// <summary>
        /// Sets a font which is used instead if a character is not present. Can be chained, but make sure there is no
        /// loop as that would crash the application! Pass <c>null</c> to remove a fallback font again.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="fallback">The font instance to fall back to.</param>
        public static void SetFallbackFont(AllegroFont font, AllegroFont fallback) =>
            AllegroLibrary.AlSetFallbackFont(font.NativeIntPtr, fallback.NativeIntPtr);

        /// <summary>
        /// Retrieves the fallback font for this font or <c>null</c>.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <returns>The fallback font or null if none was set.</returns>
        public static AllegroFont GetFallbackFont(AllegroFont font)
        {
            var nativeFont = AllegroLibrary.AlGetFallbackFont(font.NativeIntPtr);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Draws the glyph that corresponds with codepoint in the given color using the given font. If font
        /// does not have such a glyph, nothing will be drawn.
        /// <para>
        /// To draw a string as left to right horizontal text you will need to use al_get_glyph_advance to determine
        /// the position of each glyph. For drawing strings in other directions, such as top to down, use
        /// <see cref="GetGlyphDimensions(AllegroFont, int, ref int, ref int, ref int, ref int)"/> to determine the
        /// size and position of each glyph.
        /// </para>
        /// <para>
        /// If you have to draw many glyphs at the same time, use <see cref="HoldBitmapDrawing(bool)"/> with true as
        /// the parameter, before drawing the glyphs, and then call <see cref="HoldBitmapDrawing(bool)"/> again with
        /// false as a parameter when done drawing the glyphs to further enhance performance.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="codePoint">The glyph codepoint.</param>
        public static void DrawGlyph(AllegroFont font, AllegroColor color, float x, float y, int codePoint) =>
            AllegroLibrary.AlDrawGlyph(font.NativeIntPtr, color.Native, x, y, codePoint);

        /// <summary>
        /// This function returns the width in pixels of the glyph that corresponds with codepoint in the font font.
        /// Returns zero if the font does not have such a glyph.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="codePoint">The glyph codepoint.</param>
        /// <returns>The glyph width.</returns>
        public static int GetGlyphWidth(AllegroFont font, int codePoint) =>
            AllegroLibrary.AlGetGlyphWidth(font.NativeIntPtr, codePoint);

        /// <summary>
        /// Sometimes, the <see cref="GetGlyphWidth(AllegroFont, int)"/> or
        /// <see cref="GetGlyphAdvance(AllegroFont, int, int)"/> functions are not enough for exact glyph placement,
        /// so this function returns some additional information, particularly if you want to draw the font vertically.
        /// <para>
        /// The function itself returns true if the character was present in font and false if the character was not
        /// present in font.
        /// </para>
        /// <para>
        /// These values are the same as
        /// <see cref="GetTextDimensions(AllegroFont, string, ref int, ref int, ref int, ref int)"/> would return for
        /// a string of a single character equal to the glyph passed to this function. Note that glyphs may go to the
        /// left and upwards of the X, in which case x and y will have negative values.
        /// </para>
        /// <para>
        /// If you want to draw a string verticallly, for Japanese or as a game effect, then you should leave bby + bbh
        /// space between the glyphs in the y direction for a regular placement.
        /// </para>
        /// <para>
        /// If you want to draw a string horizontally in an extra compact way, then you should leave bbx + bbw space
        /// between the glyphs in the x direction for a compact placement.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="codePoint">The glyph code point.</param>
        /// <param name="bbx">The bounding box upper-left position.</param>
        /// <param name="bby">The bounding box upper-left position.</param>
        /// <param name="bbw">The bounding box width.</param>
        /// <param name="bbh">The bounding box height.</param>
        /// <returns>True if the character was present in font and false if the character was not.</returns>
        public static bool GetGlyphDimensions(AllegroFont font, int codePoint, ref int bbx, ref int bby, ref int bbw, ref int bbh) =>
            AllegroLibrary.AlGetGlyphDimensions(font.NativeIntPtr, codePoint, ref bbx, ref bby, ref bbw, ref bbh);

        /// <summary>
        /// This function returns by how much the x position should be advanced for left to right text drawing when
        /// the glyph that corresponds to codepoint1 has been drawn, and the glyph that corresponds to codepoint2
        /// will be the next to be drawn. This takes into consideration the horizontal advance width of the glyph
        /// that corresponds with codepoint1 as well as the kerning between the glyphs of codepoint1 and codepoint2.
        /// <para>
        /// Kerning is the process of adjusting the spacing between glyphs in a font, to obtain a more visually
        /// pleasing result. Kerning adjusts the space between two individual glyphs with an offset determined
        /// by the author of the font.
        /// </para>
        /// <para>
        /// If you pass ALLEGRO_NO_KERNING as codepoint1 then <see cref="GetGlyphAdvance(AllegroFont, int, int)"/>
        /// will return 0. this can be useful when drawing the first character of a string in a loop.
        /// </para>
        /// <para>
        /// Pass ALLEGRO_NO_KERNING as codepoint2 to get the horizontal advance width of the glyph that corresponds
        /// to codepoint1 without taking any kerning into consideration. This can be used, for example, when drawing
        /// the last character of a string in a loop.
        /// </para>
        /// <para>
        /// This function will return zero if the glyph of codepoint1 is not present in the font. If the glyph of
        /// codepoint2 is not present in the font, the horizontal advance width of the glyph that corresponds to
        /// codepoint1 without taking any kerning into consideration is returned.
        /// </para>
        /// <para>
        /// When drawing a string one glyph at the time from the left to the right with kerning, the x position of the
        /// glyph should be incremented by the result of al_get_glyph_advance applied to the previous glyph drawn and
        /// the next glyph to draw.
        /// </para>
        /// <para>
        /// Note that the return value of this function is a recommended advance for optimal readability for left to
        /// right text determined by the author of the font. However, if you like, you may want to draw the glyphs of
        /// the font narrower or wider to each other than what al_get_glyph_advance returns for style or effect.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="codePoint1">The first code point.</param>
        /// <param name="codePoint2">The second code point.</param>
        /// <returns>How much the x position should be advanced when drawing left to right after codepoint 1.</returns>
        public static int GetGlyphAdvance(AllegroFont font, int codePoint1, int codePoint2) =>
            AllegroLibrary.AlGetGlyphAdvance(font.NativeIntPtr, codePoint1, codePoint2);

        /// <summary>
        /// Like <see cref="DrawText(AllegroFont, AllegroColor, float, float, DrawFontFlags, string)"/>, but this
        /// function supports drawing multiple lines of text. It will break text in lines based on its contents and
        /// the maxWidth parameter. The lines are then layed out vertically depending on the lineHeight parameter and
        /// drawn each as if <see cref="DrawText(AllegroFont, AllegroColor, float, float, DrawFontFlags, string)"/>
        /// was called on them.
        /// <para>
        /// A newline \n in the text will cause a “hard” line break after its occurrence in the string. The text after
        /// a hard break is placed on a new line. Carriage return \r is not supported, will not cause a line break,
        /// and will likely be drawn as a square or a space depending on the font.
        /// </para>
        /// <para>
        /// The maxWidth parameter controls the maximum desired width of the lines. This function will try to introduce
        /// a “soft” line break after the longest possible series of words that will fit in maxLength when drawn with
        /// the given font. A “soft” line break can occur either on a space or tab (\t) character.
        /// </para>
        /// <para>
        /// However, it is possible that maxWidth is too small, or the words in text are too long to fit maxWidth when
        /// drawn with font. In that case, the word that is too wide will simply be drawn completely on a line by
        /// itself. If you don’t want the text that overflows maxWidth to be visible, then use
        /// <see cref="SetClippingRectangle(int, int, int, int)"/> to clip it off and hide it.
        /// </para>
        /// <para>
        /// The lines text was split into will each be drawn using the font, x, color and flags parameters, vertically
        /// starting at y and with a distance of lineHeight between them. If line_height is zero (0), the value
        /// returned by calling <see cref="GetFontLineHeight(AllegroFont)"/> on font will be used as a default instead.
        /// </para>
        /// <para>
        /// The flags ALLEGRO_ALIGN_LEFT, ALLEGRO_ALIGN_CENTRE, ALLEGRO_ALIGN_RIGHT and ALLEGRO_ALIGN_INTEGER will be
        /// honoured by this function.
        /// </para>
        /// <para>
        /// If you want to calculate the size of what this function will draw without actually drawing it, or if you
        /// need a complex and/or custom layout, you can use
        /// <see cref="DoMultilineText(AllegroFont, float, string, AlConstants.TextCallbackDelegate, IntPtr)"/>.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="maxWidth">The maximum width for lines, in pixels.</param>
        /// <param name="lineHeight">The height for each line.</param>
        /// <param name="flags">The flags to use when drawing.</param>
        /// <param name="text">The text string to draw.</param>
        public static void DrawMultilineText(
            AllegroFont font,
            AllegroColor color,
            float x,
            float y,
            float maxWidth,
            float lineHeight,
            DrawFontFlags flags,
            string text) =>
            AllegroLibrary.AlDrawMultilineText(font.NativeIntPtr, color.Native, x, y, maxWidth, lineHeight, (int)flags, text);

        /// <summary>
        /// Like <see cref="DrawText(AllegroFont, AllegroColor, float, float, DrawFontFlags, string)"/>, but this
        /// function supports drawing multiple lines of text. It will break text in lines based on its contents and
        /// the maxWidth parameter. The lines are then layed out vertically depending on the lineHeight parameter and
        /// drawn each as if <see cref="DrawText(AllegroFont, AllegroColor, float, float, DrawFontFlags, string)"/>
        /// was called on them.
        /// <para>
        /// A newline \n in the text will cause a “hard” line break after its occurrence in the string. The text after
        /// a hard break is placed on a new line. Carriage return \r is not supported, will not cause a line break,
        /// and will likely be drawn as a square or a space depending on the font.
        /// </para>
        /// <para>
        /// The maxWidth parameter controls the maximum desired width of the lines. This function will try to introduce
        /// a “soft” line break after the longest possible series of words that will fit in maxLength when drawn with
        /// the given font. A “soft” line break can occur either on a space or tab (\t) character.
        /// </para>
        /// <para>
        /// However, it is possible that maxWidth is too small, or the words in text are too long to fit maxWidth when
        /// drawn with font. In that case, the word that is too wide will simply be drawn completely on a line by
        /// itself. If you don’t want the text that overflows maxWidth to be visible, then use
        /// <see cref="SetClippingRectangle(int, int, int, int)"/> to clip it off and hide it.
        /// </para>
        /// <para>
        /// The lines text was split into will each be drawn using the font, x, color and flags parameters, vertically
        /// starting at y and with a distance of lineHeight between them. If line_height is zero (0), the value
        /// returned by calling <see cref="GetFontLineHeight(AllegroFont)"/> on font will be used as a default instead.
        /// </para>
        /// <para>
        /// The flags ALLEGRO_ALIGN_LEFT, ALLEGRO_ALIGN_CENTRE, ALLEGRO_ALIGN_RIGHT and ALLEGRO_ALIGN_INTEGER will be
        /// honoured by this function.
        /// </para>
        /// <para>
        /// If you want to calculate the size of what this function will draw without actually drawing it, or if you
        /// need a complex and/or custom layout, you can use
        /// <see cref="DoMultilineText(AllegroFont, float, string, AlConstants.TextCallbackDelegate, IntPtr)"/>.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="maxWidth">The maximum width for lines, in pixels.</param>
        /// <param name="lineHeight">The height for each line.</param>
        /// <param name="flags">The flags to use when drawing.</param>
        /// <param name="uStr">The unicode string to draw.</param>
        public static void DrawMultilineUStr(
            AllegroFont font,
            AllegroColor color,
            float x,
            float y,
            float maxWidth,
            float lineHeight,
            DrawFontFlags flags,
            AllegroUStr uStr) =>
            AllegroLibrary.AlDrawMultilineUstr(font.NativeIntPtr, color.Native, x, y, maxWidth, lineHeight, (int)flags, uStr.NativeIntPtr);

        /// <summary>
        /// Formatted text output, using a printf() style format string. All parameters have the same meaning as with
        /// <see cref="DrawMultilineText(AllegroFont, AllegroColor, float, float, float, float, DrawFontFlags, string)"/>
        /// otherwise.
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="color">The color to draw with.</param>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="maxWidth">The maximum width for lines, in pixels.</param>
        /// <param name="lineHeight">The height for each line.</param>
        /// <param name="flags">The flags to use when drawing.</param>
        /// <param name="format">The format string.</param>
        /// <param name="varArgs">The parameters to interpolate.</param>
        [Obsolete("This method is not implemented, use DrawMultilineText().", true)]
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

        /// <summary>
        /// This function processes the text and splits it into lines as 
        /// <see cref="DrawMultilineText(AllegroFont, AllegroColor, float, float, float, float, DrawFontFlags, string)"/>
        /// would, and then calls the callback cb once for every line. This is useful for custom drawing of multiline
        /// text, or for calculating the size of multiline text ahead of time. See the documentation on
        /// <see cref="DrawMultilineText(AllegroFont, AllegroColor, float, float, float, float, DrawFontFlags, string)"/>
        /// for an explanation of the splitting algorithm.
        /// <para>
        /// For every line that this function splits text into the callback cb will be called once with the following
        /// parameters: 
        /// <para>line_num - the number of the line starting from zero and counting up</para>
        /// <para>line - a pointer to the beginning character of the line(see below)</para>
        /// <para>size - the size of the line(0 for empty lines)</para>
        /// <para>extra - the same pointer that was passed to al_do_multiline_text</para>
        /// </para>
        /// <para>
        /// Note that line is not guaranteed to be a <c>null</c>-terminated string, but will merely point to a
        /// character within text or to an empty string in case of an empty line. If you need a NUL-terminated
        /// string, you will have to copy line to a buffer and <c>null</c>-terminate it yourself. You will also have to
        /// make your own copy if you need the contents of line after cb has returned, as line is not guaranteed
        /// to be valid after that.
        /// </para>
        /// <para>
        /// If the callback cb returns false, al_do_multiline_text will stop immediately, otherwise it will continue
        /// on to the next line.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="maxWidth">The maximum width to draw within.</param>
        /// <param name="text">The string of text.</param>
        /// <param name="callback">The callback method.</param>
        /// <param name="extra">Extra data to pass to the callback; <see cref="IntPtr.Zero"/> for none.</param>
        [Obsolete("This method is not implemented.", true)]
        public static void DoMultilineText(AllegroFont font, float maxWidth, string text, AlConstants.TextCallbackDelegate callback, IntPtr extra)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function processes the text and splits it into lines as 
        /// <see cref="DrawMultilineText(AllegroFont, AllegroColor, float, float, float, float, DrawFontFlags, string)"/>
        /// would, and then calls the callback cb once for every line. This is useful for custom drawing of multiline
        /// text, or for calculating the size of multiline text ahead of time. See the documentation on
        /// <see cref="DrawMultilineText(AllegroFont, AllegroColor, float, float, float, float, DrawFontFlags, string)"/>
        /// for an explanation of the splitting algorithm.
        /// <para>
        /// For every line that this function splits text into the callback cb will be called once with the following
        /// parameters: 
        /// <para>line_num - the number of the line starting from zero and counting up</para>
        /// <para>line - a pointer to the beginning character of the line(see below)</para>
        /// <para>size - the size of the line(0 for empty lines)</para>
        /// <para>extra - the same pointer that was passed to al_do_multiline_text</para>
        /// </para>
        /// <para>
        /// Note that line is not guaranteed to be a <c>null</c>-terminated string, but will merely point to a
        /// character within text or to an empty string in case of an empty line. If you need a NUL-terminated
        /// string, you will have to copy line to a buffer and <c>null</c>-terminate it yourself. You will also have to
        /// make your own copy if you need the contents of line after cb has returned, as line is not guaranteed
        /// to be valid after that.
        /// </para>
        /// <para>
        /// If the callback cb returns false, al_do_multiline_text will stop immediately, otherwise it will continue
        /// on to the next line.
        /// </para>
        /// </summary>
        /// <param name="font">The font instance.</param>
        /// <param name="maxWidth">The maximum width to draw within.</param>
        /// <param name="uStr">The unicode string of text.</param>
        /// <param name="callback">The callback method.</param>
        /// <param name="extra">Extra data to pass to the callback; <see cref="IntPtr.Zero"/> for none.</param>
        [Obsolete("This method is not implemented.", true)]
        public static void DoMultilineUStr(AllegroFont font, float maxWidth, AllegroUStr uStr, AlConstants.TextCallbackDelegate callback, IntPtr extra)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new font from an Allegro bitmap. You can delete the bitmap after the function returns as the
        /// font will contain a copy for itself.
        /// </summary>
        /// <param name="bitmap">The bitmap to create a font from.</param>
        /// <param name="rangesN">The unicode ranges in the bitmap.</param>
        /// <param name="ranges">'n' pairs of first and last unicode point to map glyphs for each range.</param>
        /// <returns>The created font instance on success, <c>null</c> on error.</returns>
        public static AllegroFont GrabFontFromBitmap(AllegroBitmap bitmap, int rangesN, int[] ranges)
        {
            var nativeFont = AllegroLibrary.AlGrabFontFromBitmap(bitmap.NativeIntPtr, rangesN, ranges);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Load a bitmap font from a file. This is done by first calling
        /// <see cref="LoadBitmapFlags(string, BitmapLoadFlags)"/> and then
        /// <see cref="GrabFontFromBitmap(AllegroBitmap, int, int[])"/>.
        /// </summary>
        /// <param name="filename">The filename to load the bitmap font from.</param>
        /// <returns>The created font instance on success, <c>null</c> on error.</returns>
        public static AllegroFont LoadBitmapFont(string filename)
        {
            var nativeFont = AllegroLibrary.AlLoadBitmapFont(filename);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Like <see cref="LoadBitmapFont(string)"/> but additionally takes a flags parameter which is a bitfield
        /// containing a combination of the following: ALLEGRO_NO_PREMULTIPLIED_ALPHA
        /// </summary>
        /// <param name="filename">The filename to load the bitmap font from.</param>
        /// <param name="flags">The flags to use when loading the bitmap.</param>
        /// <returns>The created font instance on success, <c>null</c> on error.</returns>
        public static AllegroFont LoadBitmapFontFlags(string filename, BitmapLoadFlags flags)
        {
            var nativeFont = AllegroLibrary.AlLoadBitmapFontFlags(filename, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Creates a monochrome bitmap font (8x8 pixels per character). This font is primarily intended to be
        /// used for displaying information in environments or during early runtime states where no external
        /// font data is available or loaded (e.g. for debugging).
        /// </summary>
        /// <returns><c>null</c> on an error, otherwise the font instance.</returns>
        public static AllegroFont CreateBuiltInFont()
        {
            var nativeFont = AllegroLibrary.AlCreateBuiltinFont();
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Call this after <see cref="InitFontAddon"/> to make <see cref="LoadFont(string, int, LoadFontFlags)"/>
        /// recognize “.ttf” and other formats supported by <see cref="LoadTtfFont(string, int, LoadTtfFontFlags)"/>.
        /// </summary>
        /// <returns></returns>
        public static bool InitTtfAddon() =>
            AllegroLibrary.AlInitTtfAddon();

        /// <summary>
        /// Returns true if the TTF addon is initialized, otherwise returns false.
        /// </summary>
        /// <returns>True on success, otherwise false.</returns>
        public static bool IsTtfAddonInitialized() =>
            AllegroLibrary.AlIsTtfAddonInitialized();

        /// <summary>
        /// Unloads the ttf addon again. You normally don’t need to call this.
        /// </summary>
        public static void ShutdownTtfAddon() =>
            AllegroLibrary.AlShutdownTtfAddon();

        /// <summary>
        /// Loads a TrueType font from a file using the FreeType library. Quoting from the FreeType FAQ this means
        /// support for many different font formats: TrueType, OpenType, Type1, CID, CFF, Windows FON/FNT, X11 PCF,
        /// and others.
        /// <para>
        /// The size parameter determines the size the font will be rendered at, specified in pixels. The standard
        /// font size is measured in units per EM, if you instead want to specify the size as the total height of
        /// glyphs in pixels, pass it as a negative value.
        /// </para>
        /// <para>
        /// Note: If you want to display text at multiple sizes, load the font multiple times with different size
        /// parameters.
        /// </para>
        /// </summary>
        /// <param name="filename">The filename of the font.</param>
        /// <param name="size">The size to load the font.</param>
        /// <param name="flags">The flags to use when loading the font.</param>
        /// <returns>The font instance on success, otherwise null.</returns>
        public static AllegroFont LoadTtfFont(string filename, int size, LoadTtfFontFlags flags)
        {
            var nativeFont = AllegroLibrary.AlLoadTtfFont(filename, size, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Like <see cref="LoadTtfFont(string, int, LoadTtfFontFlags)"/>, but the font is read from the file handle.
        /// The filename is only used to find possible additional files next to a font file.
        /// <para>
        /// Note: The file handle is owned by the returned <see cref="AllegroFont"/> object and must not be freed by
        /// the caller, as FreeType expects to be able to read from it at a later time.
        /// </para>
        /// </summary>
        /// <param name="file">The Allegro File instance.</param>
        /// <param name="filename">The filename used to find possible additional files next to a font file.</param>
        /// <param name="size">The size of the font to load.</param>
        /// <param name="flags">The flags to use when loading the font.</param>
        /// <returns>The font instance on success, otherwise null.</returns>
        public static AllegroFont LoadTtfFontF(AllegroFile file, string filename, int size, LoadTtfFontFlags flags)
        {
            var nativeFont = AllegroLibrary.AlLoadTtfFontF(file.NativeIntPtr, filename, size, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Like <see cref="LoadTtfFont(string, int, LoadTtfFontFlags)"/>, except it takes separate width and height
        /// parameters instead of a single size parameter.
        /// <para>
        /// If the height is a positive value, and the width zero or positive, then font will be stretched according
        /// to those parameters. The width must not be negative if the height is positive.
        /// </para>
        /// <para>
        /// As with <see cref="LoadTtfFont(string, int, LoadTtfFontFlags)"/>, the height may be a negative value to
        /// specify the total height in pixels. Then the width must also be a negative value, or zero.
        /// </para>
        /// </summary>
        /// <param name="filename">The filename of the font.</param>
        /// <param name="w">The width of the font to load.</param>
        /// <param name="h">The height of the fotn to load.</param>
        /// <param name="flags">The flags to use when loading the font.</param>
        /// <returns>
        /// <c>null</c> if the height is positive while width is negative, or if the height is negative while the
        /// width is positive.
        /// </returns>
        public static AllegroFont LoadTtfFontStretch(string filename, int w, int h, LoadTtfFontFlags flags)
        {
            var nativeFont = AllegroLibrary.AlLoadTtfFontStretch(filename, w, h, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Like <see cref="LoadTtfFont(string, int, LoadTtfFontFlags)"/>, except it takes separate width and height
        /// parameters instead of a single size parameter.
        /// <para>
        /// If the height is a positive value, and the width zero or positive, then font will be stretched according
        /// to those parameters. The width must not be negative if the height is positive.
        /// </para>
        /// <para>
        /// As with <see cref="LoadTtfFont(string, int, LoadTtfFontFlags)"/>, the height may be a negative value to
        /// specify the total height in pixels. Then the width must also be a negative value, or zero.
        /// </para>
        /// </summary>
        /// <param name="file">The Allegro File to load from.</param>
        /// <param name="filename">The filename used to find possible additional files next to a font file.</param>
        /// <param name="w">The width of the font to load.</param>
        /// <param name="h">The height of the font to load.</param>
        /// <param name="flags">The flags to use when loading the font.</param>
        /// <returns>The font instance on success, otherwise <c>null</c>.</returns>
        public static AllegroFont LoadTtfFontStretchF(AllegroFile file, string filename, int w, int h, LoadTtfFontFlags flags)
        {
            var nativeFont = AllegroLibrary.AlLoadTtfFontStretchF(file.NativeIntPtr, filename, w, h, (int)flags);
            return nativeFont == IntPtr.Zero ? null : new AllegroFont { NativeIntPtr = nativeFont };
        }

        /// <summary>
        /// Returns the (compiled) version of the addon, in the same format as <see cref="Al.GetAllegroVersion"/>.
        /// </summary>
        /// <returns>The (compiled) version of the addon, in the same format as <see cref="Al.GetAllegroVersion"/>.</returns>
        public static uint GetAllegroTtfVersion() =>
            AllegroLibrary.AlGetAllegroTtfVersion();
    }
}
