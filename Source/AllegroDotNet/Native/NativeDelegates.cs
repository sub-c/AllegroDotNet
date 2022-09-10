using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using System;

namespace SubC.AllegroDotNet.Native
{
  public static class NativeDelegates
  {
    public delegate int AtExitDelegate(VoidDelegate voidDelegate);

    public delegate IntPtr DetachedThreadProcess(IntPtr arg);

    public delegate bool DoMultilineText(int line_num, IntPtr line, int size, IntPtr extra);

    public delegate bool DoMultilineUstr(int line_num, IntPtr line, IntPtr extra);

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

    public delegate FsEntryResult ForEachFsEntry(IntPtr dir, IntPtr extra);

    public delegate IntPtr MemoryInterfaceCalloc(UIntPtr count, UIntPtr n, int line, IntPtr file, IntPtr func);

    public delegate IntPtr MemoryInterfaceFree(IntPtr ptr, int line, IntPtr file, IntPtr func);

    public delegate IntPtr MemoryInterfaceMalloc(UIntPtr n, int line, IntPtr file, IntPtr func);

    public delegate IntPtr MemoryInterfaceRealloc(IntPtr ptr, UIntPtr n, int line, IntPtr file, IntPtr func);

    public delegate void MixerPostprocessCallback(IntPtr buf, uint samples, IntPtr data);

    public delegate IntPtr ThreadProcess(IntPtr thread, IntPtr arg);

    public delegate void RegisterAssertHandler(IntPtr expr, IntPtr file, int line, IntPtr func);

    public delegate IntPtr RegisterAudioStreamLoader(IntPtr filename, long buffer_count, uint samples);

    public delegate IntPtr RegisterAudioStreamLoaderF(IntPtr fp, long buffer_count, uint samples);

    public delegate bool RegisterBitmapIdentifier(IntPtr f);

    public delegate IntPtr RegisterBitmapLoader(IntPtr filename, int flags);

    public delegate IntPtr RegisterBitmapLoaderF(IntPtr fp, int flags);

    public delegate bool RegisterBitmapSaver(IntPtr filename, IntPtr bmp);

    public delegate bool RegisterBitmapSaverF(IntPtr fp, IntPtr bmp);

    public delegate IntPtr RegisterFontLoader(IntPtr filename, int size, int flags);

    public delegate bool RegisterSampleIdentifier(IntPtr fp);

    public delegate IntPtr RegisterSampleLoader(IntPtr filename);

    public delegate IntPtr RegisterSampleLoaderF(IntPtr fp);

    public delegate bool RegisterSampleSaver(IntPtr filename, IntPtr spl);

    public delegate bool RegisterSampleSaverF(IntPtr fp, IntPtr spl);

    public delegate void RegisterTraceHandler(IntPtr logMessage);

    public delegate void UserEventDelegate(ref AllegroEvent.NativeAllegroUserEvent userEvent);

    public delegate void VoidDelegate();
  }
}