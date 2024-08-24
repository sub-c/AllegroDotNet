using SubC.AllegroDotNet.Models;

namespace SubC.AllegroDotNet.Native;

/// <summary>
/// This static class contains the delegates used by Allegro 5 functions.
/// </summary>
public static class Delegates
{
    /// <summary>
    /// The delegate used as the at exit function.
    /// </summary>
    public delegate int AtExitDelegate(VoidDelegate voidDelegate);

    /// <summary>
    /// The delegate used as the bitmap identifier using an <see cref="AllegroFile"/>.
    /// </summary>
    public delegate byte BitmapIdentifierDelegate(IntPtr allegroFile);

    /// <summary>
    /// The delegate used to load a bitmap from a given filename.
    /// </summary>
    public delegate IntPtr BitmapLoaderDelegate(IntPtr filename, int flags);

    /// <summary>
    /// The delegate used to load a bitmap from a given <see cref="AllegroFile"/>.
    /// </summary>
    public delegate IntPtr BitmapLoaderFDelegate(IntPtr allegroFile, int flags);

    /// <summary>
    /// The delegate used to save a bitmap to a given filename.
    /// </summary>
    public delegate byte BitmapSaverDelegate(IntPtr filename, IntPtr bitmap);

    /// <summary>
    /// The delegate used to save a bitmap to a given <see cref="AllegroFile"/>.
    /// </summary>
    public delegate byte BitmapSaverFDelegate(IntPtr allegroFile, IntPtr bitmap);

    public delegate void Direct3DDeviceRelease(IntPtr display);

    public delegate void Direct3DDeviceRestore(IntPtr display);

    /// <summary>
    /// The delegate used as a callback when performing <see cref="Al.DoMultilineText"/>.
    /// </summary>
    public delegate byte DoMultilineTextCallbackDelegate(int lineNum, IntPtr line, int size, IntPtr extra);

    /// <summary>
    /// The delegate used as a callback when performing <see cref="Al.DoMultilineUstr"/>.
    /// </summary>
    public delegate byte DoMultilineUstrCallbackDelegate(int lineNum, IntPtr line, IntPtr extra);

    public delegate void DrawPrimitiveSoftLineDraw(UIntPtr ptr, int i1, int i2);

    public delegate void DrawPrimitiveSoftTriangleDraw(UIntPtr ptr, int i1, int i2, int i3);

    public delegate void DrawPrimitiveSoftTriangleFirst(UIntPtr ptr, int i1, int i2, int i3, int i4);

    public delegate void DrawPrimitiveSoftLineFirst(UIntPtr ptr, int i1, int i2, ref AllegroVertex p1, ref AllegroVertex p2);

    public delegate void DrawPrimitiveSoftTriangleInit(UIntPtr ptr, ref AllegroVertex p1, ref AllegroVertex p2, ref AllegroVertex p3);

    public delegate void DrawPrimitiveStep(UIntPtr ptr, int i);

    public delegate IntPtr FileInterfaceFOpen(IntPtr path, IntPtr mode);

    public delegate bool FileInterfaceFClose(IntPtr handle);

    public delegate long FileInterfaceFRead(IntPtr f, IntPtr ptr, long size);

    public delegate long FileInterfaceFWrite(IntPtr f, IntPtr ptr, long size);

    public delegate bool FileInterfaceFFlush(IntPtr f);

    public delegate long FileInterfaceFTell(IntPtr f);

    public delegate bool FileInterfaceFSeek(IntPtr f, long offset, int whence);

    public delegate bool FileInterfaceFEof(IntPtr f);

    public delegate int FileInterfaceFError(IntPtr f);

    public delegate IntPtr FileInterfaceFErrMsg(IntPtr f);

    public delegate void FileInterfaceFClearErr(IntPtr f);

    public delegate int FileInterfaceFunGetC(IntPtr f, int c);

    public delegate int FileInterfaceFSize(IntPtr f);

    public delegate int ForEachFsCallback(IntPtr dir, IntPtr extra);

    public delegate IntPtr MemoryInterfaceCalloc(UIntPtr count, UIntPtr n, int line, IntPtr file, IntPtr func);

    public delegate void MemoryInterfaceFree(IntPtr ptr, int line, IntPtr file, IntPtr func);

    public delegate IntPtr MemoryInterfaceMalloc(UIntPtr n, int line, IntPtr file, IntPtr func);

    public delegate IntPtr MemoryInterfaceRealloc(IntPtr ptr, UIntPtr n, int line, IntPtr file, IntPtr func);

    /// <summary>
    /// The delegate used to handle asserts.
    /// </summary>
    public delegate void RegisterAssertHandlerDelegate(IntPtr expr, IntPtr file, int line, IntPtr func);

    /// <summary>
    /// The delegate used to register an audio stream loader.
    /// </summary>
    public delegate IntPtr RegisterAudioStreamLoader(IntPtr filename, long buffer_count, uint samples);

    /// <summary>
    /// The delegate used to register an audio stream loader using an <see cref="AllegroFile"/>.
    /// </summary>
    public delegate IntPtr RegisterAudioStreamFLoader(IntPtr fp, long buffer_count, uint samples);

    /// <summary>
    /// The delegate used to register a font loader.
    /// </summary>
    public delegate IntPtr RegisterFontLoaderDelegate(IntPtr filename, int size, int flags);

    /// <summary>
    /// The delegate used to register a sample identifier.
    /// </summary>
    public delegate byte RegisterSampleIdentifierDelegate(IntPtr fp);

    /// <summary>
    /// The delegate used to register a sample loader.
    /// </summary>
    public delegate IntPtr RegisterSampleLoaderDelegate(IntPtr filename);

    /// <summary>
    /// The delegate used to register a sample loader using an <see cref="AllegroFile"/>.
    /// </summary>
    public delegate IntPtr RegisterSampleLoaderFDelegate(IntPtr filename);

    /// <summary>
    /// The delegate used to register a sample saver.
    /// </summary>
    public delegate byte RegisterSampleSaverDelegate(IntPtr filename, IntPtr spl);

    /// <summary>
    /// The delegate used to register a sample saver using an <see cref="AllegroFile"/>.
    /// </summary>
    public delegate byte RegisterSampleSaverFDelegate(IntPtr fp, IntPtr spl);

    /// <summary>
    /// The delegate used to handle traces.
    /// </summary>
    public delegate void RegisterTraceHandlerDelegate(IntPtr message);

    /// <summary>
    /// The delegate used to handle mixer post process callbacks.
    /// </summary>
    public delegate void SetMixerPostProcessCallbackDelegate(IntPtr buf, uint samples, IntPtr data);

    public delegate IntPtr ThreadDetachedExecutionDelegate(IntPtr arg);

    public delegate IntPtr ThreadExecutionDelegate(IntPtr thread, IntPtr arg);

    public delegate void TriangulatePolygonEmitTriangle(int i1, int i2, int i3, IntPtr data);

    /// <summary>
    /// The delegate used to deconstruct/free data from a user event.
    /// </summary>
    public delegate void UserEventDeconstructor(IntPtr userEvent);

    /// <summary>
    /// The delegate invoked without parameters or a return value.
    /// </summary>
    public delegate void VoidDelegate();

    public delegate byte WindowsCallbackDelegate(IntPtr display, uint message, UIntPtr wparam, IntPtr lparam, IntPtr lresult, IntPtr userdata);
}
