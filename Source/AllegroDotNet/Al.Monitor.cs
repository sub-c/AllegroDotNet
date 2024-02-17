using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;
using System;
using System.Collections.Generic;
using System.Text;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static int GetNewDisplayAdapter()
  {
    return Interop.Core.AlGetNewDisplayAdapter();
  }

  public static void SetNewDisplayAdapter(int adapter)
  {
    Interop.Core.AlSetNewDisplayAdapter(adapter);
  }

  public static bool GetMonitorInfo(int adapter, out AllegroMonitorInfo info)
  {
    info = new();
    return Interop.Core.AlGetMonitorInfo(adapter, ref info) != 0;
  }

  public static int GetMonitorDpi(int adapter)
  {
    return Interop.Core.AlGetMonitorDpi(adapter);
  }

  public static int GetNumVideoAdapters()
  {
    return Interop.Core.AlGetNumVideoAdapters();
  }
}
