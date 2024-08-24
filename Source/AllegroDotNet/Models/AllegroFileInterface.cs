using SubC.AllegroDotNet.Native;
using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroFileInterface
{
    public Delegates.FileInterfaceFOpen FOpen
    {
        readonly get => fopen;
        set => fopen = value;
    }

    public Delegates.FileInterfaceFClose FClose
    {
        readonly get => fclose;
        set => fclose = value;
    }

    public Delegates.FileInterfaceFRead FRead
    {
        readonly get => fread;
        set => fread = value;
    }

    public Delegates.FileInterfaceFWrite FWrite
    {
        readonly get => fwrite;
        set => fwrite = value;
    }

    public Delegates.FileInterfaceFFlush FFlush
    {
        readonly get => fflush;
        set => fflush = value;
    }

    public Delegates.FileInterfaceFTell FTell
    {
        readonly get => ftell;
        set => ftell = value;
    }

    public Delegates.FileInterfaceFSeek FSeek
    {
        readonly get => fseek;
        set => fseek = value;
    }

    public Delegates.FileInterfaceFEof FEof
    {
        readonly get => feof;
        set => feof = value;
    }

    public Delegates.FileInterfaceFError FError
    {
        readonly get => ferror;
        set => ferror = value;
    }

    public Delegates.FileInterfaceFErrMsg FErrMsg
    {
        readonly get => ferrMsg;
        set => ferrMsg = value;
    }

    public Delegates.FileInterfaceFClearErr FClearErr
    {
        readonly get => fclearerr;
        set => fclearerr = value;
    }

    public Delegates.FileInterfaceFunGetC FunGetC
    {
        readonly get => fungetc;
        set => fungetc = value;
    }

    public Delegates.FileInterfaceFSize FSize
    {
        readonly get => fsize;
        set => fsize = value;
    }

    private Delegates.FileInterfaceFOpen fopen;
    private Delegates.FileInterfaceFClose fclose;
    private Delegates.FileInterfaceFRead fread;
    private Delegates.FileInterfaceFWrite fwrite;
    private Delegates.FileInterfaceFFlush fflush;
    private Delegates.FileInterfaceFTell ftell;
    private Delegates.FileInterfaceFSeek fseek;
    private Delegates.FileInterfaceFEof feof;
    private Delegates.FileInterfaceFError ferror;
    private Delegates.FileInterfaceFErrMsg ferrMsg;
    private Delegates.FileInterfaceFClearErr fclearerr;
    private Delegates.FileInterfaceFunGetC fungetc;
    private Delegates.FileInterfaceFSize fsize;
}
