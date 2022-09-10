using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroFileInterface
  {
    public NativeDelegates.FileInterfaceFOpen FOpen
    {
      get => FileInterface.FOpen;
      set => FileInterface.FOpen = value;
    }

    public NativeDelegates.FileInterfaceFClose FClose
    {
      get => FileInterface.FClose;
      set => FileInterface.FClose = value;
    }

    public NativeDelegates.FileInterfaceFRead FRead
    {
      get => FileInterface.FRead;
      set => FileInterface.FRead = value;
    }

    public NativeDelegates.FileInterfaceFWrite FWrite
    {
      get => FileInterface.FWrite;
      set => FileInterface.FWrite = value;
    }

    public NativeDelegates.FileInterfaceFFlush FFlush
    {
      get => FileInterface.FFlush;
      set => FileInterface.FFlush = value;
    }

    public NativeDelegates.FileInterfaceFTell FTell
    {
      get => FileInterface.FTell;
      set => FileInterface.FTell = value;
    }

    public NativeDelegates.FileInterfaceFSeek FSeek
    {
      get => FileInterface.FSeek;
      set => FileInterface.FSeek = value;
    }

    public NativeDelegates.FileInterfaceFEof FEof
    {
      get => FileInterface.FEof;
      set => FileInterface.FEof = value;
    }

    public NativeDelegates.FileInterfaceFError FError
    {
      get => FileInterface.FError;
      set => FileInterface.FError = value;
    }

    public NativeDelegates.FileInterfaceFErrMsg FErrMsg
    {
      get => FileInterface.FErrMsg;
      set => FileInterface.FErrMsg = value;
    }

    public NativeDelegates.FileInterfaceFClearErr FClearErr
    {
      get => FileInterface.FClearErr;
      set => FileInterface.FClearErr = value;
    }

    public NativeDelegates.FileInterfaceFunGetC FunGetC
    {
      get => FileInterface.FunGetC;
      set => FileInterface.FunGetC = value;
    }

    public NativeDelegates.FileInterfaceFSize FSize
    {
      get => FileInterface.FSize;
      set => FileInterface.FSize = value;
    }

    internal NativeAllegroFileInterface FileInterface;

    [StructLayout(LayoutKind.Sequential)]
    internal struct NativeAllegroFileInterface
    {
      public NativeDelegates.FileInterfaceFOpen FOpen;
      public NativeDelegates.FileInterfaceFClose FClose;
      public NativeDelegates.FileInterfaceFRead FRead;
      public NativeDelegates.FileInterfaceFWrite FWrite;
      public NativeDelegates.FileInterfaceFFlush FFlush;
      public NativeDelegates.FileInterfaceFTell FTell;
      public NativeDelegates.FileInterfaceFSeek FSeek;
      public NativeDelegates.FileInterfaceFEof FEof;
      public NativeDelegates.FileInterfaceFError FError;
      public NativeDelegates.FileInterfaceFErrMsg FErrMsg;
      public NativeDelegates.FileInterfaceFClearErr FClearErr;
      public NativeDelegates.FileInterfaceFunGetC FunGetC;
      public NativeDelegates.FileInterfaceFSize FSize;
    }
  }
}
