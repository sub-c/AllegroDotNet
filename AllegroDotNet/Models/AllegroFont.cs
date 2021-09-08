using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// A handle identifying any kind of font. Usually you will create it with
    /// <see cref="Al.LoadFont(string, int, Enums.LoadFontFlags)"/> which supports loading all kinds of TrueType fonts
    /// supported by the FreeType library. If you instead pass the filename of a bitmap file, it will be loaded with
    /// <see cref="Al.LoadBitmap(string)"/> and a font in Allegro’s bitmap font format will be created from it with 
    /// <see cref="Al.GrabFontFromBitmap(AllegroBitmap, int, int[])"/>.
    /// </summary>
    public sealed class AllegroFont : NativePointerWrapper
    {
        internal AllegroFont()
        {
        }
    }
}
