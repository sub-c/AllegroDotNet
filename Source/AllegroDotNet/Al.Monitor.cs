using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

public static partial class Al
{
  public static int GetNewDisplayAdapter()
  {
    return NativeFunctions.AlGetNewDisplayAdapter();
  }

  public static void SetNewDisplayAdapter(int adapter)
  {
    NativeFunctions.AlSetNewDisplayAdapter(adapter);
  }

  public static bool GetMonitorInfo(int adapter, out AllegroMonitorInfo monitorInfo)
  {
    monitorInfo = new();
    return NativeFunctions.AlGetMonitorInfo(adapter, ref monitorInfo.MonitorInfo);
  }

  public static int GetMonitorDpi(int adapter)
  {
    return NativeFunctions.AlGetMonitorDpi(adapter);
  }

  public static int GetNumVideoAdapters()
  {
    return NativeFunctions.AlGetNumVideoAdapters();
  }

  public static int GetMonitorRefreshRate(int adapter)
  {
    return NativeFunctions.AlGetMonitorRefreshRate(adapter);
  }
}
