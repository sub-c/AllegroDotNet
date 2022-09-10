using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet
{
  public static partial class Al
  {
    public static AllegroFile? FOpen(string path, FileMode mode)
    {
      var modeString = FileModeToString(mode);
      var nativeMode = Marshal.StringToHGlobalAnsi(modeString);
      var nativePath = Marshal.StringToHGlobalAnsi(path);
      var nativeResult = NativeFunctions.AlFOpen(nativePath, nativeMode);
      Marshal.FreeHGlobal(nativeMode);
      Marshal.FreeHGlobal(nativePath);
      return NativePointerModel.Create<AllegroFile>(nativeResult);
    }

    public static AllegroFile? FOpenInterface(AllegroFileInterface fileInterface, string path, FileMode mode)
    {
      var modeString = FileModeToString(mode);
      var nativePath = Marshal.StringToHGlobalAnsi(path);
      var nativeMode = Marshal.StringToHGlobalAnsi(modeString);
      var nativeResult = NativeFunctions.AlFOpenInterface(ref fileInterface.FileInterface, nativePath, nativeMode);
      Marshal.FreeHGlobal(nativePath);
      Marshal.FreeHGlobal(nativeMode);
      return NativePointerModel.Create<AllegroFile>(nativeResult);
    }

    public static AllegroFile? FOpenSlice(AllegroFile? file, long initialSize, FileMode mode)
    {
      var modeString = FileModeToString(mode);
      var nativeMode = Marshal.StringToHGlobalAnsi(modeString);
      var nativeReturn = NativeFunctions.AlFOpenSlice(NativePointerModel.GetPointer(file), initialSize, nativeMode);
      Marshal.FreeHGlobal(nativeMode);
      return NativePointerModel.Create<AllegroFile>(nativeReturn);
    }

    /// <summary>
    /// Close the given file, writing any buffered output data (if any).
    /// </summary>
    /// <param name="file">The file to close.</param>
    /// <returns>True on success, false on failure. errno is set to indicate the error.</returns>
    public static bool FClose(AllegroFile? file)
    {
      return NativeFunctions.AlFClose(NativePointerModel.GetPointer(file));
    }

    private static string FileModeToString(FileMode mode)
    {
      var modeString = string.Empty;
      if (mode.HasFlag(FileMode.ReadAccess)) modeString += "r";
      if (mode.HasFlag(FileMode.WriteAccess)) modeString += "w";
      if (mode.HasFlag(FileMode.UsingBinary)) modeString += "b";
      if (mode.HasFlag(FileMode.Expandable)) modeString += "e";
      if (mode.HasFlag(FileMode.EnableSeekToEndOfSlice)) modeString += "s";
      if (mode.HasFlag(FileMode.DisableSeekToEndOfSlice)) modeString += "n";
      return modeString;
    }

    public static long FRead(AllegroFile? file, ref byte[] buffer, long size)
    {
      var nativeBuffer = Marshal.AllocHGlobal((int)size);
      var nativeReturn = NativeFunctions.AlFRead(NativePointerModel.GetPointer(file), nativeBuffer, size);
      Marshal.Copy(nativeBuffer, buffer, 0, buffer.Length);
      Marshal.FreeHGlobal(nativeBuffer);
      return nativeReturn;
    }

    public static long FWrite(AllegroFile? file, ref byte[] buffer, long size)
    {
      var nativeBuffer = Marshal.AllocHGlobal((int)size);
      Marshal.Copy(buffer, 0, nativeBuffer, (int)size);
      var nativeReturn = NativeFunctions.AlFWrite(NativePointerModel.GetPointer(file), nativeBuffer, size);
      Marshal.FreeHGlobal(nativeBuffer);
      return nativeReturn;
    }

    public static bool FFlush(AllegroFile? file)
    {
      return NativeFunctions.AlFFlush(NativePointerModel.GetPointer(file));
    }

    public static long FTell(AllegroFile? file)
    {
      return NativeFunctions.AlFTell(NativePointerModel.GetPointer(file));
    }

    public static bool FSeek(AllegroFile? file, long offset, Seek whence)
    {
      return NativeFunctions.AlFSeek(NativePointerModel.GetPointer(file), offset, (int)whence);
    }

    public static bool FEof(AllegroFile? file)
    {
      return NativeFunctions.AlFEof(NativePointerModel.GetPointer(file));
    }

    public static int FError(AllegroFile? file)
    {
      return NativeFunctions.AlFError(NativePointerModel.GetPointer(file));
    }

    public static string FErrMsg(AllegroFile? file)
    {
      var nativeReturn = NativeFunctions.AlFErrMsg(NativePointerModel.GetPointer(file));
      return nativeReturn == IntPtr.Zero ? string.Empty : Marshal.PtrToStringAnsi(nativeReturn);
    }

    public static void FClearErr(AllegroFile? file)
    {
      NativeFunctions.AlFClearErr(NativePointerModel.GetPointer(file));
    }

    public static int FUngetC(AllegroFile? file, int c)
    {
      return NativeFunctions.AlFUngetC(NativePointerModel.GetPointer(file), c);
    }

    public static long FSize(AllegroFile? file)
    {
      return NativeFunctions.AlFSize(NativePointerModel.GetPointer(file));
    }

    public static int FGetC(AllegroFile? file)
    {
      return NativeFunctions.AlFGetC(NativePointerModel.GetPointer(file));
    }

    public static int FPutC(AllegroFile? file, int c)
    {
      return NativeFunctions.AlFPutC(NativePointerModel.GetPointer(file), c);
    }

    public static int FPrintF(AllegroFile? file, string format, params object[] args)
    {
      format = string.Format(format, args);
      var nativeFormat = Marshal.StringToHGlobalAnsi(format);
      var nativeReturn = NativeFunctions.AlFPrintF(NativePointerModel.GetPointer(file), nativeFormat);
      Marshal.FreeHGlobal(nativeFormat);
      return nativeReturn;
    }

    public static short FRead16le(AllegroFile? file)
    {
      return NativeFunctions.AlFRead16le(NativePointerModel.GetPointer(file));
    }

    public static short FRead16be(AllegroFile? file)
    {
      return NativeFunctions.AlFRead16be(NativePointerModel.GetPointer(file));
    }

    public static long FWrite16le(AllegroFile? file, short w)
    {
      return NativeFunctions.AlFWrite16le(NativePointerModel.GetPointer(file), w);
    }

    public static long FWrite16be(AllegroFile? file, short w)
    {
      return NativeFunctions.AlFWrite16be(NativePointerModel.GetPointer(file), w);
    }

    public static int FRead32le(AllegroFile? file)
    {
      return NativeFunctions.AlFRead32le(NativePointerModel.GetPointer(file));
    }

    public static int FRead32be(AllegroFile? file)
    {
      return NativeFunctions.AlFRead32be(NativePointerModel.GetPointer(file));
    }

    public static long FWrite32le(AllegroFile? file, int l)
    {
      return NativeFunctions.AlFWrite32le(NativePointerModel.GetPointer(file), l);
    }

    public static long FWrite32be(AllegroFile? file, int l)
    {
      return NativeFunctions.AlFWrite32be(NativePointerModel.GetPointer(file), l);
    }

    public static string? FGetS(AllegroFile? file, out string buffer, long max)
    {
      var nativeBuffer = Marshal.AllocHGlobal((int)max);
      var nativeReturn = NativeFunctions.AlFGetS(NativePointerModel.GetPointer(file), nativeBuffer, max);
      buffer = nativeReturn == IntPtr.Zero ? string.Empty : Marshal.PtrToStringAnsi(nativeReturn);
      Marshal.FreeHGlobal(nativeBuffer);
      return nativeReturn == IntPtr.Zero ? null : buffer;
    }

    public static AllegroUstr? FGetUstr(AllegroFile? file)
    {
      var nativeReturn = NativeFunctions.AlFGetUstr(NativePointerModel.GetPointer(file));
      return NativePointerModel.Create<AllegroUstr>(nativeReturn);
    }

    public static int FPutS(AllegroFile? file, string text)
    {
      var nativeText = Marshal.StringToHGlobalAnsi(text);
      var nativeReturn = NativeFunctions.AlFPutS(NativePointerModel.GetPointer(file), nativeText);
      Marshal.FreeHGlobal(nativeText);
      return nativeReturn;
    }

    public static AllegroFile? FOpenFd(int fd, FileMode mode)
    {
      var modeText = FileModeToString(mode);
      var nativeMode = Marshal.StringToHGlobalAnsi(modeText);
      var nativeReturn = NativeFunctions.AlFOpenFd(fd, nativeMode);
      Marshal.FreeHGlobal(nativeMode);
      return NativePointerModel.Create<AllegroFile>(nativeReturn);
    }

    public static AllegroFile? MakeTempFile(string template, AllegroPath? path)
    {
      var nativeTemplate = Marshal.StringToHGlobalAnsi(template);
      var nativeReturn = IntPtr.Zero;
      if (path is null)
      {
        var dummyPath = IntPtr.Zero;
        nativeReturn = NativeFunctions.AlMakeTempFile(nativeTemplate, ref dummyPath);
      }
      else
        nativeReturn = NativeFunctions.AlMakeTempFile(nativeTemplate, ref path.NativePointer);
      Marshal.FreeHGlobal(nativeTemplate);
      return NativePointerModel.Create<AllegroFile>(nativeReturn);
    }

    public static void SetNewFileInterface(AllegroFileInterface fileInterface)
    {
      NativeFunctions.AlSetNewFileInterface(ref fileInterface.FileInterface);
    }

    public static void SetStandardFileInterface()
    {
      NativeFunctions.AlSetStandardFileInterface();
    }

    public static AllegroFileInterface GetNewFileInterface()
    {
      var nativeReturn = NativeFunctions.AlGetNewFileInterface();
      return Marshal.PtrToStructure<AllegroFileInterface>(nativeReturn);
    }

    public static AllegroFile? CreateFileHandle(AllegroFileInterface fileInterface, IntPtr userdata)
    {
      var nativeReturn = NativeFunctions.AlCreateFileHandle(ref fileInterface.FileInterface, userdata);
      return NativePointerModel.Create<AllegroFile>(nativeReturn);
    }

    public static IntPtr GetFileUserdata(AllegroFile? file)
    {
      return NativeFunctions.AlGetFileUserdata(NativePointerModel.GetPointer(file));
    }
  }
}
