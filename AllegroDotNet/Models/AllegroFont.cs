using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet.Models
{
    /// <summary>
    /// A handle identifying any kind of font. Usually you will create it with al_load_font which supports loading
    /// all kinds of TrueType fonts supported by the FreeType library. If you instead pass the filename of a bitmap
    /// file, it will be loaded with al_load_bitmap and a font in Allegro’s bitmap font format will be created from
    /// it with al_grab_font_from_bitmap.
    /// </summary>
    public sealed class AllegroFont : NativePointerWrapper
    {
        internal AllegroFont()
        {
        }
    }
}
