using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models;

[StructLayout(LayoutKind.Sequential)]
public struct AllegroMenuInfo
{
  public IntPtr Caption
  {
    readonly get => caption;
    set => caption = value;
  }

  public ushort ID
  {
    readonly get => id;
    set => id = value;
  }

  public int Flags
  {
    readonly get => flags;
    set => flags = value;
  }

  public IntPtr Icon
  {
    readonly get => icon;
    set => icon = value;
  }

  private IntPtr caption;
  private ushort id;
  private int flags;
  private IntPtr icon;
}
