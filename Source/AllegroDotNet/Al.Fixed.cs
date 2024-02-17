using SubC.AllegroDotNet.Models;
using SubC.AllegroDotNet.Native;

namespace SubC.AllegroDotNet;

/// <summary>
/// This static class contains the Allegro 5 library methods.
/// </summary>
public static partial class Al
{
  public static readonly AllegroFixed FixToRadR = new() { Fixed = 1608 };
  public static readonly AllegroFixed RadToFixR = new() { Fixed = 2670177 };

  public static AllegroFixed IToFix(int x)
  {
    var fix = Interop.Core.AlIToFix(x);
    return new AllegroFixed { Fixed = fix };
  }

  public static int FixToI(AllegroFixed fix)
  {
    return Interop.Core.AlFixToI(fix.Fixed);
  }

  public static int FixFloor(AllegroFixed fix)
  {
    return Interop.Core.AlFixFloor(fix.Fixed);
  }

  public static int FixCeil(AllegroFixed fix)
  {
    return Interop.Core.AlFixCeil(fix.Fixed);
  }

  public static AllegroFixed FToFix(double x)
  {
    var fix = Interop.Core.AlFToFix(x);
    return new AllegroFixed { Fixed = fix };
  }

  public static double FixToF(AllegroFixed fix)
  {
    return Interop.Core.AlFixToF(fix.Fixed);
  }

  public static AllegroFixed FixMul(AllegroFixed x, AllegroFixed y)
  {
    var fix = Interop.Core.AlFixMul(x.Fixed, y.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixDiv(AllegroFixed x, AllegroFixed y)
  {
    var fix = Interop.Core.AlFixDiv(x.Fixed, y.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixAdd(AllegroFixed x, AllegroFixed y)
  {
    var fix = Interop.Core.AlFixAdd(x.Fixed, y.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixSub(AllegroFixed x, AllegroFixed y)
  {
    var fix = Interop.Core.AlFixSub(x.Fixed, y.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixSin(AllegroFixed x)
  {
    var fix = Interop.Core.AlFixSin(x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixCos(AllegroFixed x)
  {
    var fix = Interop.Core.AlFixCos(x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixTan(AllegroFixed x)
  {
    var fix = Interop.Core.AlFixTan(x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixAsin(AllegroFixed x)
  {
    var fix = Interop.Core.AlFixAsin(x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixAcos(AllegroFixed x)
  {
    var fix = Interop.Core.AlFixAcos(x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixAtan(AllegroFixed x)
  {
    var fix = Interop.Core.AlFixAtan(x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixAtan2(AllegroFixed y, AllegroFixed x)
  {
    var fix = Interop.Core.AlFixAtan2(y.Fixed, x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixSqrt(AllegroFixed x)
  {
    var fix = Interop.Core.AlFixSqrt(x.Fixed);
    return new AllegroFixed { Fixed = fix };
  }

  public static AllegroFixed FixHypot(AllegroFixed x, AllegroFixed y)
  {
    var fix = Interop.Core.AlFixHypot(x.Fixed, y.Fixed);
    return new AllegroFixed { Fixed = fix };
  }
}
