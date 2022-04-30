using System.Runtime.InteropServices;

namespace SubC.AllegroDotNet.Models
{
  public sealed class AllegroMonitorInfo
  {
    public int X1
    {
      get => MonitorInfo.x1;
      set => MonitorInfo.x1 = value;
    }

    public int Y1
    {
      get => MonitorInfo.y1;
      set => MonitorInfo.y1 = value;
    }

    public int X2
    {
      get => MonitorInfo.x2;
      set => MonitorInfo.x2 = value;
    }

    public int Y2
    {
      get => MonitorInfo.y2;
      set => MonitorInfo.y2 = value;
    }

    internal NativeMonitorInfo MonitorInfo;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NativeMonitorInfo
    {
      public int x1;
      public int y1;
      public int x2;
      public int y2;
    }
  }
}