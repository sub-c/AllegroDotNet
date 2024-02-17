using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static AllegroFile? FOpen(string path, string mode)
  {
    using var nativePath = new CStringAnsi(path);
    using var nativeMode = new CStringAnsi(mode);
    var pointer = Interop.Core.AlFOpen(nativePath.Pointer, nativeMode.Pointer);
    return NativePointer.Create<AllegroFile>(pointer);
  }

  public static void FOpenInterface()
  {
    throw new NotImplementedException();
  }

  public static AllegroFile? FOpenSlice(AllegroFile? file, long initialSize, string mode)
  {
    using var nativeMode = new CStringAnsi(mode);
    var pointer = Interop.Core.AlFOpenSlice(NativePointer.Get(file), initialSize, nativeMode.Pointer);
    return NativePointer.Create<AllegroFile>(pointer);
  }

  public static bool FClose(AllegroFile? file)
  {
    return Interop.Core.AlFClose(NativePointer.Get(file)) != 0;
  }

  public static long FRead(AllegroFile? file, byte[] pointer, long size)
  {
    return Interop.Core.AlFRead(NativePointer.Get(file), pointer, size);
  }

  public static long FWrite(AllegroFile? file, byte[] pointer, long size)
  {
    return Interop.Core.AlFWrite(NativePointer.Get(file), pointer, size);
  }

  public static bool FFlush(AllegroFile? file)
  {
    return Interop.Core.AlFFlush(NativePointer.Get(file)) != 0;
  }

  public static long FTell(AllegroFile? file)
  {
    return Interop.Core.AlFTell(NativePointer.Get(file));
  }

  public static bool FSeek(AllegroFile? file, long offset, int whence)
  {
    return Interop.Core.AlFSeek(NativePointer.Get(file), offset, whence) != 0;
  }

  public static bool FEof(AllegroFile? file)
  {
    return Interop.Core.AlFEof(NativePointer.Get(file)) != 0;
  }

  public static int FError(AllegroFile? file)
  {
    return Interop.Core.AlFError(NativePointer.Get(file));
  }

  public static string? FErrMsg(AllegroFile? file)
  {
    var pointer = Interop.Core.AlFErrMsg(NativePointer.Get(file));
    return CStringAnsi.ToCSharpString(pointer);
  }

  public static void FClearErr(AllegroFile? file)
  {
    Interop.Core.AlFClearErr(NativePointer.Get(file));
  }

  public static int FUngetC(AllegroFile? file, int c)
  {
    return Interop.Core.AlFUngetC(NativePointer.Get(file), c);
  }

  public static long FSize(AllegroFile? file)
  {
    return Interop.Core.AlFSize(NativePointer.Get(file));
  }

  public static int FGetC(AllegroFile? file)
  {
    return Interop.Core.AlFGetC(NativePointer.Get(file));
  }

  public static int FPutC(AllegroFile? file, int c)
  {
    return Interop.Core.AlFPutC(NativePointer.Get(file), c);
  }

  public static short FRead16LE(AllegroFile? file)
  {
    return Interop.Core.AlFRead16LE(NativePointer.Get(file));
  }

  public static short FRead16BE(AllegroFile? file)
  {
    return Interop.Core.AlFRead16BE(NativePointer.Get(file));
  }

  public static long FWrite16LE(AllegroFile? file, short w)
  {
    return Interop.Core.AlFWrite16LE(NativePointer.Get(file), w);
  }

  public static long FWrite16BE(AllegroFile? file, short w)
  {
    return Interop.Core.AlFWrite16BE(NativePointer.Get(file), w);
  }

  public static int FRead32LE(AllegroFile? file)
  {
    return Interop.Core.AlFRead32LE(NativePointer.Get(file));
  }

  public static int FRead32BE(AllegroFile? file)
  {
    return Interop.Core.AlFRead32BE(NativePointer.Get(file));
  }

  public static long FWrite32LE(AllegroFile? file, int l)
  {
    return Interop.Core.AlFWrite32LE(NativePointer.Get(file), l);
  }

  public static long FWrite32BE(AllegroFile? file, int l)
  {
    return Interop.Core.AlFWrite32BE(NativePointer.Get(file), l);
  }

  public static IntPtr FGetS(AllegroFile? file, IntPtr buffer, long max)
  {
    return Interop.Core.AlFGetS(NativePointer.Get(file), buffer, max);
  }

  public static AllegroUstr? FGetUstr(AllegroFile? file)
  {
    var pointer = Interop.Core.AlFGetUstr(NativePointer.Get(file));
    return NativePointer.Create<AllegroUstr>(pointer);
  }

  public static int FPutS(AllegroFile? file, string p)
  {
    using var nativeP = new CStringAnsi(p);
    return Interop.Core.AlFPutS(NativePointer.Get(file), nativeP.Pointer);
  }

  public static AllegroFile? FOpenFd(int fd, string mode)
  {
    using var nativeMode = new CStringAnsi(mode);
    var pointer = Interop.Core.AlFOpenFd(fd, nativeMode.Pointer);
    return NativePointer.Create<AllegroFile>(pointer);
  }

  public static AllegroFile? MakeTempFile(string template, out string retPath)
  {
    throw new NotImplementedException();
  }

  public static void SetNewFileInterface(AllegroFileInterface fileInterface)
  {
    Interop.Core.AlSetNewFileInterface(ref fileInterface);
  }

  public static void SetStandardFileInterface()
  {
    Interop.Core.AlSetStandardFileInterface();
  }

  public static AllegroFileInterface? GetNewFileInterface()
  {
    var pointer = Interop.Core.AlGetNewFileInterface();
    return pointer == IntPtr.Zero
      ? null
      : Marshal.PtrToStructure<AllegroFileInterface>(pointer);
  }

  public static AllegroFile? CreateFileHandle(AllegroFileInterface driver, IntPtr userData)
  {
    var pointer = Interop.Core.AlCreateFileHandle(ref driver, userData);
    return NativePointer.Create<AllegroFile>(pointer);
  }

  public static IntPtr GetFileUserdata(AllegroFile? file)
  {
    return Interop.Core.AlGetFileUserdata(NativePointer.Get(file));
  }
}
